namespace GestaoHospilar
{
    public interface IRecebedor
    {
        public string Identificador { get; protected set; }

        public List<Pagamento> Pagamentos { get; set; }
        
        decimal CalcularPagamento();
    }
}