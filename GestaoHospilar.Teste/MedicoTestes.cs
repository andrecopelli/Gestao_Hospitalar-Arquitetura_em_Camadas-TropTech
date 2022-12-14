namespace GestaoHospilar.Teste;

public class MedicoTestes
{
    const string identificacao = "CRM-123456";
    const decimal valorHora = 300;
    Membro _medico;

    [SetUp]
    public void SetUp()
    {
        _medico = new Medico(identificacao);
    }

    [Test]
    public void Medico_inicializa()
    {
        Assert.That(_medico.Identificador, Is.EqualTo(identificacao));
        Assert.That(_medico.ValorHora, Is.EqualTo(valorHora));
        Assert.That(_medico.HorasTrabalhadas, Is.EqualTo(0));
        Assert.That(_medico.Pagamentos.Count, Is.EqualTo(0));
    }

    [Test]
    public void Medico_calculo_salario_180_horas()
    {
        _medico.HorasTrabalhadas = 180;
        var salario = _medico.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(54_000));
    }

    [Test]
    public void Medico_calculo_salario_200_horas()
    {
        _medico.HorasTrabalhadas = 200;
        var salario = _medico.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(66_000));
    }

    [Test]
    public void Medico_calculo_salario_260_horas()
    {
        _medico.HorasTrabalhadas = 260;
        var salario = _medico.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(105_000));
    }

    [Test]
    public void Medico_calculo_salario_301_horas()
    {
        _medico.HorasTrabalhadas = 301;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            _medico.CalcularPagamento();
        });
    }

    [Test]
    public void Medico_registra_pagamento_200_horas()
    {
        _medico.HorasTrabalhadas = 200;
        var salario = _medico.CalcularPagamento();

        Assert.That(_medico.Pagamentos.Count, Is.EqualTo(1));
        Assert.That(_medico.Pagamentos[0].Mes, Is.EqualTo(DateTime.Now.Month));
        Assert.That(_medico.Pagamentos[0].Salario, Is.EqualTo(salario));
    }

    [Test]
    public void Medico_zera_horas_apos_calculo_salario()
    {
        _medico.HorasTrabalhadas = 200;
        var salario = _medico.CalcularPagamento();

        Assert.That(_medico.HorasTrabalhadas, Is.EqualTo(0));
    }
}