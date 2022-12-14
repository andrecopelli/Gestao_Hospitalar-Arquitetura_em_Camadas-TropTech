namespace GestaoHospilar
{
    public abstract class Membro: IRecebedor
    {
        const int primeiraFaixa = 180;
        const int segundaFaixa = 200;

        public decimal ValorHora { get; protected set; }
        public int HorasTrabalhadas { get; set; }
        public string Identificador { get; set; }

        public List<Pagamento> Pagamentos { get; set; }

        public Membro()
        {
            HorasTrabalhadas = 0;
            Pagamentos = new List<Pagamento>();
        }

        public virtual decimal CalcularPagamento()
        {
            decimal salario = 0;
            
            if (HorasTrabalhadas > 0 && HorasTrabalhadas <= primeiraFaixa)
                salario = ValorHora * HorasTrabalhadas;
            else if (HorasTrabalhadas > primeiraFaixa && HorasTrabalhadas <= segundaFaixa)
            {
                salario = ValorHora * primeiraFaixa;
                salario += (ValorHora * 2) * (HorasTrabalhadas - primeiraFaixa);
            }
            else
                throw new ArgumentOutOfRangeException("Horas Trabalhadas deve ser entre 0 e 200");

            Pagamentos.Add(new Pagamento { Mes = DateTime.Now.Month, Salario = salario});
            HorasTrabalhadas = 0;
            return salario;
        }
    }
}