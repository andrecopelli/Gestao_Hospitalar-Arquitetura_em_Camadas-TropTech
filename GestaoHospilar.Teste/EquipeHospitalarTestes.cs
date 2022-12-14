namespace GestaoHospilar.Teste;

public class EquipeHospitalarTestes
{
    PagavelHospital _pagavelHospital;

    [SetUp]
    public void SetUp()
    {
        _pagavelHospital = new PagavelHospital();
    }

    [Test]
    public void EquipeHospitalar_inicializa()
    {
        Assert.That(_pagavelHospital.Recebedores.Count, Is.EqualTo(0));
    }

    [Test]
    public void EquipeHospitalar_adiciona_medico()
    {
        _pagavelHospital.Adicionar(new Medico("CRM-123456"));

        Assert.That(_pagavelHospital.Recebedores.Count, Is.EqualTo(1));
    }

    [Test]
    public void EquipeHospitalar_adiciona_contratado()
    {
        _pagavelHospital.Adicionar(new Contratado("EMP-123456"));

        Assert.That(_pagavelHospital.Recebedores.Count, Is.EqualTo(1));
    }

    [Test]
    public void EquipeHospitalar_nao_adiciona_mesmo_medico()
    {
        _pagavelHospital.Adicionar(new Medico("CRM-123456"));
        
        Assert.Throws<Exception>( () => {
            _pagavelHospital.Adicionar(new Medico("CRM-123456"));
        });
    }

    [Test]
    public void EquipeHospitalar_nao_adiciona_mesmo_contratado()
    {
        _pagavelHospital.Adicionar(new Contratado("EMP-123456"));
        
        Assert.Throws<Exception>( () => {
            _pagavelHospital.Adicionar(new Contratado("EMP-123456"));
        });
    }

    [Test]
    public void EquipeHospitalar_remove_medico()
    {
        _pagavelHospital.Adicionar(new Medico("CRM-123456"));
        _pagavelHospital.Remover("CRM-123456");

        Assert.That(_pagavelHospital.Recebedores.Count, Is.EqualTo(0));
    }

    [Test]
    public void EquipeHospitalar_remove_contratado()
    {
        _pagavelHospital.Adicionar(new Contratado("EMP-123456"));
        _pagavelHospital.Remover("EMP-123456");

        Assert.That(_pagavelHospital.Recebedores.Count, Is.EqualTo(0));
    }

    [Test]
    public void EquipeHospitalar_nao_remove_medico_inesxistente()
    {        
        Assert.Throws<Exception>( () => {
            _pagavelHospital.Remover("CRM-123456");
        });
    }

    [Test]
    public void EquipeHospitalar_buscar_medico()
    {
        var medico = new Medico("CRM-123456");
        _pagavelHospital.Adicionar(medico);
        var membro = _pagavelHospital.Buscar("CRM-123456");

        Assert.That(medico.Identificador, Is.EqualTo(membro.Identificador));
    }

    [Test]
    public void EquipeHospitalar_buscar_contratado()
    {
        var contratado = new Contratado("EMP-123456");
        _pagavelHospital.Adicionar(contratado);
        var recebedor = _pagavelHospital.Buscar("EMP-123456");

        Assert.That(contratado.Identificador, Is.EqualTo(recebedor.Identificador));
    }

    [Test]
    public void EquipeHospitalar_busca_medico_inesxistente()
    {        
        Assert.Throws<Exception>( () => {
            _pagavelHospital.Buscar("CRM-123456");
        });
    }
}