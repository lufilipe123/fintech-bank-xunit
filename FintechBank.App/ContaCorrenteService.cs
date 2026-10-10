namespace FintechBank.App;

public class ContaCorrenteService
{
    public decimal CalcularTaxaManutencao(
        decimal saldo,
        bool clienteEspecial)
    {
        if (clienteEspecial || saldo >= 5000.00m)
        {
            return 0.00m;
        }

        if (saldo >= 1000.00m)
        {
            return saldo * 0.005m;
        }

        return 25.00m;
    }

    public bool ValidarSaque(
        decimal saldo,
        decimal limite,
        decimal valorSaque)
    {
        return valorSaque >= 0
            && valorSaque <= saldo + limite;
    }
}