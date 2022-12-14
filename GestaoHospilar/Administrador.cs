namespace GestaoHospilar
{
    public class Administrador : Membro
    {
        const decimal valorHora = 110;

        public Administrador(string identificacao)
        {
            this.Identificador = identificacao;
            this.ValorHora = valorHora;
        }
    }
}