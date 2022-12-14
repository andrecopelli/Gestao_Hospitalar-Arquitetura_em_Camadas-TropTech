namespace GestaoHospilar.Teste
{
    public class ContratadoTeste
    {
        const string identificacao = "EMP-123456";
        Contratado _contratado;

        [SetUp]
        public void SetUp()
        {
            _contratado = new Contratado(identificacao);
        }

        [Test]
        public void Contratado_inicializa()
        {
            Assert.That(_contratado.Identificador, Is.EqualTo(identificacao));
            Assert.That(_contratado.Pagamentos.Count, Is.EqualTo(0));
        }

        [Test]
        public void Contratado_registra_pagamento()
        {
            var salario = _contratado.CalcularPagamento();

            Assert.That(_contratado.Pagamentos.Count, Is.EqualTo(1));
            Assert.That(_contratado.Pagamentos[0].Mes, Is.EqualTo(DateTime.Now.Month));
            Assert.That(_contratado.Pagamentos[0].Salario, Is.EqualTo(salario));
        }
    }
}