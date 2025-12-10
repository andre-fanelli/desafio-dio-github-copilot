using System;

class Program
{
    static void Main()
    {
        Console.Write("Informe o número do cartão (ou cole aqui): ");
        var input = Console.ReadLine() ?? "";
        var digits = GetOnlyDigits(input);

        if (string.IsNullOrEmpty(digits))
        {
            Console.WriteLine("Nenhum dígito fornecido.");
            return;
        }

        var brand = GetBrand(digits);
        var luhnValid = IsValidLuhn(digits);

        Console.WriteLine($"Número detectado: {digits}");
        Console.WriteLine($"Bandeira: {brand}");
        Console.WriteLine($"Validação Luhn: {(luhnValid ? "VÁLIDO" : "INVÁLIDO")}");
    }

    static string GetOnlyDigits(string s)
    {
        var chars = new System.Text.StringBuilder();
        foreach (var c in s)
            if (char.IsDigit(c)) chars.Append(c);
        return chars.ToString();
    }

    static string GetBrand(string digits)
    {
        if (digits.StartsWith("4")) // imagem: Visa começa com 4
            return "Visa";

        // Mastercard: 51-55 ou 2221-2720
        if (digits.Length >= 2)
        {
            if (int.TryParse(digits.Substring(0, 2), out int first2))
            {
                if (first2 >= 51 && first2 <= 55) return "MasterCard";
            }
        }
        if (digits.Length >= 4 && int.TryParse(digits.Substring(0, 4), out int first4))
        {
            if (first4 >= 2221 && first4 <= 2720) return "MasterCard";
        }

        // American Express: 34 ou 37
        if (digits.StartsWith("34") || digits.StartsWith("37"))
            return "American Express";

        // Discover: 6011, 65, ou 644-649
        if (digits.StartsWith("6011") || digits.StartsWith("65"))
            return "Discover";
        if (digits.Length >= 3 && int.TryParse(digits.Substring(0, 3), out int first3))
        {
            if (first3 >= 644 && first3 <= 649) return "Discover";
        }

        // Hipercard: geralmente começa com 6062 (conforme imagem)
        if (digits.StartsWith("6062"))
            return "Hipercard";

        // Elo: imagem mostra exemplos como 4011, 4312, 4389 (entre outros)
        var eloExamples = new[] { "4011", "4312", "4389" };
        foreach (var p in eloExamples)
            if (digits.StartsWith(p)) return "Elo";

        return "Desconhecida";
    }

    static bool IsValidLuhn(string number)
    {
        int sum = 0;
        bool alternate = false;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(number[i])) return false;
            int n = number[i] - '0';
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        return sum % 10 == 0;
    }
}