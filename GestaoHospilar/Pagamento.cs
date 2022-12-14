namespace GestaoHospilar
{
    public class Pagamento
    {
        public int Mes { get; set; }

        public decimal Salario { get; set; }

        public override string ToString()
        {
            return String.Format($"---------------------\n") + String.Format($" SALÁRIO: {Salario}");
        }
    }
}