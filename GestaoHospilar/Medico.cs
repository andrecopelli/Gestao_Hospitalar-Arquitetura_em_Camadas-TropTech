namespace GestaoHospilar
{
    public class Medico : Membro
    {
        const int primeiraFaixa = 180;
        const int segundaFaixa = 250;
        const int limiteFaixa = 300;
        const decimal valorHora = 300;


        public Medico(string identificacao)
        {
            this.Identificador = identificacao;
            this.ValorHora = valorHora;
        }

        public override decimal CalcularPagamento()
        {
            decimal salario = 0;
            
            if (HorasTrabalhadas > 0 && HorasTrabalhadas <= primeiraFaixa)
                salario = ValorHora * HorasTrabalhadas;
            else if (HorasTrabalhadas > primeiraFaixa && HorasTrabalhadas <= segundaFaixa)
            {
                salario = ValorHora * primeiraFaixa;
                salario += (ValorHora * 2) * (HorasTrabalhadas - primeiraFaixa);
            }
            else if (HorasTrabalhadas > segundaFaixa && HorasTrabalhadas <= limiteFaixa)
            {
                salario = ValorHora * primeiraFaixa;
                salario += (ValorHora * 2) * (segundaFaixa - primeiraFaixa);
                salario += (ValorHora * 3) * (HorasTrabalhadas - segundaFaixa);
            }
            else
                throw new ArgumentOutOfRangeException("Horas Trabalhadas deve ser entre 0 e 300");

            Pagamentos.Add(new Pagamento { Mes = DateTime.Now.Month, Salario = salario});
            HorasTrabalhadas = 0;
            return salario;
        }
    }
}