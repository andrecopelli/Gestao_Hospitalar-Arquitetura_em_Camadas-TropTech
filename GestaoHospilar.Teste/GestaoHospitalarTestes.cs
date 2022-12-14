using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using GestaoHospilar;

namespace GestaoHospilar.Teste
{
    public class GestaoHospitalarTestes
    {
        private GestaoHospitalar _gestaoHospitalar;

        [SetUp]
        public void Setup()
        {
            _gestaoHospitalar = new GestaoHospitalar();
        }

        [Test]
        public void Informar_Pagamento_Medicos_Teste()
        {
            var identificador = "CRM-123456";
            var medico = new Medico(identificador);
            _gestaoHospitalar.PagavelHospitalar.Adicionar(medico);
            var horasTrabalhadas = 180;
           
            _gestaoHospitalar.InformarHoras(horasTrabalhadas, identificador);

            var membro = _gestaoHospitalar.PagavelHospitalar.Buscar(identificador);
            Membro membroConvertido = (Membro)membro;            
            Assert.AreEqual(horasTrabalhadas, membroConvertido.HorasTrabalhadas);
        }

        [Test]
        public void Pagar_Colaboradores_Medicos_Teste()
        {
            var identificador = "CRM-123456";
            var medico = new Medico(identificador);
            _gestaoHospitalar.PagavelHospitalar.Adicionar(medico);
            var horasTrabalhadas = 180;
            _gestaoHospitalar.InformarHoras(horasTrabalhadas, identificador);

            _gestaoHospitalar.PagarRecebedores();

            var numeroPagamentosEsperados = 1;
            var membro = _gestaoHospitalar.PagavelHospitalar.Buscar(identificador);
            Assert.AreEqual(numeroPagamentosEsperados, membro.Pagamentos.Count);
        }

        [Test]
        public void Pagar_Colaboradores_Contratados_Teste()
        {
            var identificador = "EMP-123456";
            var contratado = new Contratado(identificador);
            _gestaoHospitalar.PagavelHospitalar.Adicionar(contratado);         

            _gestaoHospitalar.PagarRecebedores();

            var numeroPagamentosEsperados = 1;
            var recebedor = _gestaoHospitalar.PagavelHospitalar.Buscar(identificador);
            Assert.AreEqual(numeroPagamentosEsperados, recebedor.Pagamentos.Count);
        }
    }
}