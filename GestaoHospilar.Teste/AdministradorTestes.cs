namespace GestaoHospilar.Teste;

public class AdministradorTestes
{
    const string identificacao = "ADM-123456";
    const decimal valorHora = 110;
    Membro _administrador;

    [SetUp]
    public void SetUp()
    {
        _administrador = new Administrador(identificacao);
    }

    [Test]
    public void Administrador_inicializa()
    {
        Assert.That(_administrador.Identificador, Is.EqualTo(identificacao));
        Assert.That(_administrador.ValorHora, Is.EqualTo(valorHora));
        Assert.That(_administrador.HorasTrabalhadas, Is.EqualTo(0));
        Assert.That(_administrador.Pagamentos.Count, Is.EqualTo(0));
    }

    [Test]
    public void Administrador_calculo_salario_180_horas()
    {
        _administrador.HorasTrabalhadas = 180;
        var salario = _administrador.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(19_800));
    }

    [Test]
    public void Administrador_calculo_salario_200_horas()
    {
        _administrador.HorasTrabalhadas = 200;
        var salario = _administrador.CalcularPagamento();

        Assert.That(salario, Is.EqualTo(24_200));
    }

    [Test]
    public void Administrador_calculo_salario_301_horas()
    {
        _administrador.HorasTrabalhadas = 301;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            _administrador.CalcularPagamento();
        });
    }

    [Test]
    public void Administrador_registra_pagamento_200_horas()
    {
        _administrador.HorasTrabalhadas = 200;
        var salario = _administrador.CalcularPagamento();

        Assert.That(_administrador.Pagamentos.Count, Is.EqualTo(1));
        Assert.That(_administrador.Pagamentos[0].Mes, Is.EqualTo(DateTime.Now.Month));
        Assert.That(_administrador.Pagamentos[0].Salario, Is.EqualTo(salario));
    }

    [Test]
    public void Administrador_zera_horas_apos_calculo_salario()
    {
        _administrador.HorasTrabalhadas = 200;
        var salario = _administrador.CalcularPagamento();

        Assert.That(_administrador.HorasTrabalhadas, Is.EqualTo(0));
    }
}