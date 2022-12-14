namespace GestaoHospilar
{
    public class Contratado : IRecebedor
    {
        public string Identificador { get; set; }

        public List<Pagamento> Pagamentos { get; set; }

        public Contratado(string identificador)
        {
            Identificador = identificador;
            Pagamentos = new List<Pagamento>();
        }
        
        //Implementar rega de negócio conforme especificação
        public decimal CalcularPagamento()
        {
            decimal salario = 200;
            Pagamentos.Add(new Pagamento { Mes = DateTime.Now.Month, Salario = salario});
            return salario;
        }
    }
}