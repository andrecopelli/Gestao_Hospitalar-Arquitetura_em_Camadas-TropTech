namespace GestaoHospilar.Teste;

public class EnfermeiroTestes
{
    const string identificacao = "COREN-123456";
    const decimal valorHora = 40;
    Membro _enfermeiro;

    [SetUp]
    public void SetUp()
    {
        _enfermeiro = new Enfermeiro(identificacao);
    }

    [Test]
    public void Enfermeiro_inicializa()
    {
        Assert.That(_enfermeiro.Identificador, Is.EqualTo(identificacao));
        Assert.That(_enfermeiro.ValorHora, Is.EqualTo(valorHora));
        Assert.That(_enfermeiro.HorasTrabalhadas, Is.EqualTo(0));
        Assert.That(_enfermeiro.Pagamentos.Count, Is.EqualTo(0));
    }

    [Test]
    public void Enfermeiro_calculo_salario_180_horas()
    {
        _enfermeiro.HorasTrabalhadas = 180;
        var salario = _enfermeiro.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(7_200));
    }

    [Test]
    public void Enfermeiro_calculo_salario_200_horas()
    {
        _enfermeiro.HorasTrabalhadas = 200;
        var salario = _enfermeiro.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(8_800));
    }

    [Test]
    public void Enfermeiro_calculo_salario_301_horas()
    {
        _enfermeiro.HorasTrabalhadas = 301;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            _enfermeiro.CalcularPagamento();
        });
    }

    [Test]
    public void Enfermeiro_registra_pagamento_200_horas()
    {
        _enfermeiro.HorasTrabalhadas = 200;
        var salario = _enfermeiro.CalcularPagamento();

        Assert.That(_enfermeiro.Pagamentos.Count, Is.EqualTo(1));
        Assert.That(_enfermeiro.Pagamentos[0].Mes, Is.EqualTo(DateTime.Now.Month));
        Assert.That(_enfermeiro.Pagamentos[0].Salario, Is.EqualTo(salario));
    }

    [Test]
    public void Enfermeiro_zera_horas_apos_calculo_salario()
    {
        _enfermeiro.HorasTrabalhadas = 200;
        var salario = _enfermeiro.CalcularPagamento();

        Assert.That(_enfermeiro.HorasTrabalhadas, Is.EqualTo(0));
    }
}