namespace FintechBank.App;

public class EmprestimoService
{
    public decimal CalcularValorParcela(
        decimal valorTotal,
        int parcelas,
        int scoreCredito)
    {
        if (parcelas <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(parcelas),
                "O número de parcelas deve ser maior que zero.");
        }

        decimal fatorJuros = scoreCredito switch
        {
            >= 700 => 1.05m,
            >= 500 => 1.12m,
            _ => 1.20m
        };

        decimal valorComJuros = valorTotal * fatorJuros;

        return valorComJuros / parcelas;
    }

    public bool AprovarEmprestimo(
        decimal rendaMensal,
        decimal valorParcela)
    {
        return valorParcela <= rendaMensal * 0.30m;
    }
}