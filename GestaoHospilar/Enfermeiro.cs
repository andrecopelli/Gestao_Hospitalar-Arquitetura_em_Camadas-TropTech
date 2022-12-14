namespace GestaoHospilar
{
    public class Enfermeiro : Membro
    {
        const decimal valorHora = 40;

        public Enfermeiro(string identificacao)
        {
            this.Identificador = identificacao;
            this.ValorHora = valorHora;
        }
    }
}