# Validador de Bandeira de Cartão de Crédito

Programa simples em C# para identificar a bandeira (Visa, MasterCard, Elo, American Express, Discover, Hipercard ou desconhecida) de um número de cartão e validar o número pelo algoritmo de Luhn. As regras de identificação seguem os prefixos mostrados na imagem `base.png`.

## O que faz
- Recebe um número de cartão (entrada pelo console).
- Remove caracteres não numéricos.
- Identifica a bandeira usando os prefixos/intervalos da imagem (ex.: Visa começa com 4; MasterCard 51–55 ou 2221–2720; AmEx 34/37; Discover 6011, 65, 644–649; Hipercard 6062; exemplos de Elo 4011/4312/4389).
- Valida o número usando o algoritmo de Luhn.
- Exibe o número detectado, a bandeira e se passar/não o Luhn.

## Requisitos
- .NET SDK (compatível com o projeto).
- Código atual não faz OCR da imagem; a `base.png` é apenas referência visual para os prefixos.

## Como executar
1. Abra o terminal na pasta do projeto:
2. Execute:
   dotnet run
3. Cole ou digite o número do cartão quando solicitado e pressione Enter.

## Arquivos principais
- Program.cs — lógica de extração de dígitos, detecção de bandeira e validação Luhn.
- base.png — imagem usada como referência para os prefixos (não é processada automaticamente).

## Extensões sugeridas
- Adicionar verificação de comprimento por bandeira (ex.: AmEx 15 dígitos).
- Incluir mais intervalos/prefixos para Elo e outras bandeiras.
- Integrar OCR (Tesseract/OpenCV) para ler `base.png` ou imagens de cartões diretamente.

## Observações
- O programa identifica a bandeira apenas a partir dos prefixos; resultados empíricos dependem do número informado.
- Não armazene ou compartilhe números reais de cartão em ambientes inseguros.
- README GERADO POR IA!