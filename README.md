# FintechBank

Aplicação de exemplo com regras básicas de conta corrente e empréstimos,
acompanhadas por testes unitários parametrizados em xUnit.

## Requisitos

- .NET SDK 10
- Git

## Regras de negócio

- **Conta corrente (`ContaCorrenteService`)**: não cobra manutenção de clientes
  especiais ou contas com saldo a partir de R$ 5.000. Para saldo a partir de
  R$ 1.000, cobra 0,5% do saldo; abaixo disso, cobra R$ 25. Também valida
  saques, aceitando valores não negativos até o saldo somado ao limite.
- **Empréstimo (`EmprestimoService`)**: calcula parcelas com juros simples
  conforme o score: 5% para score a partir de 700, 12% a partir de 500 e 20%
  abaixo de 500. O total com juros é dividido pelo número de parcelas, que
  deve ser maior que zero. Aprova a parcela quando ela não ultrapassa 30% da
  renda mensal.

## Clonar e compilar

No terminal, execute:

```bash
git clone https://github.com/lufilipe123/fintech-bank-xunit.git
cd fintech-bank-xunit
dotnet build FintechBank.slnx
```

## Executar os testes

Na raiz do repositório, rode:

```bash
dotnet test
```

Os testes estão em `FintechBank.Tests`. Cada classe de serviço tem testes
`[Theory]` com múltiplos `[InlineData]`, executando o mesmo teste para
combinações distintas de entradas e resultados esperados:

- `ContaCorrenteServiceTests`: taxas de manutenção e validação de saques.
- `EmprestimoServiceTests`: juros por score e aprovação pela margem
  consignável.