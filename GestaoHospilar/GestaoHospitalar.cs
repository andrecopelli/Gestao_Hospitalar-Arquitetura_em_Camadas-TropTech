namespace GestaoHospilar;
public class GestaoHospitalar
{
    public PagavelHospital PagavelHospitalar { get; set; }

    public GestaoHospitalar()
    {
        PagavelHospitalar = new PagavelHospital();
    }

    public void InformarHoras(int horasTrabalhadas, string identificacao)
    {
        var membro = PagavelHospitalar.Buscar(identificacao);

        if(membro is Membro){
            Membro membroConvertido = (Membro)membro;
            membroConvertido.HorasTrabalhadas = horasTrabalhadas;
        }        
    }

    public void PagarRecebedores()
    {
        foreach (var item in PagavelHospitalar.Recebedores)
            item.CalcularPagamento();
    }
    
    public List<Pagamento> ExibirPagamentos(string identificacao)
    {
        var recebedor = PagavelHospitalar.Buscar(identificacao);

        return recebedor.Pagamentos;
    }
}
