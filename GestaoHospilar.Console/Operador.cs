using System;
using System.Collections.Generic;
using GestaoHospilar;

namespace GestaoHospilar.Tela
{
    public static class Operador
    {
        private static GestaoHospitalar _gestao = new GestaoHospitalar();

        internal static string MenuPrincipal()
        {
            System.Console.Clear();

            string header = "=========== Bem-Vindo a Gestao Hospitalar ===========";
            string opcao0 = "[1] Cadastrar colaborador";
            string opcao1 = "[2] Remover colaborador";
            string opcao2 = "[3] Informar horas trabalhadas";
            string opcao3 = "[4] Pagar colaboradores";
            string opcao4 = "[5] Exibir salarios pagos";

            System.Console.WriteLine($"{header}\n\n{opcao0}\n{opcao1}\n{opcao2}\n{opcao3}\n{opcao4}\n");

            var opcaoEscolhida = System.Console.ReadLine();

            if (opcaoEscolhida != "1"
                && opcaoEscolhida != "2"
                && opcaoEscolhida != "3"
                && opcaoEscolhida != "4"
                && opcaoEscolhida != "5")
            {
                System.Console.WriteLine("Opção Inválida.\nClique em qualquer tecla para continuar");
                System.Console.ReadKey();

                return MenuPrincipal();
            }

            return opcaoEscolhida;
        }

        internal static void CadastrarColaborador()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== CADASTRO DE COLABORADOR ===========");
            string header = "Escolha o tipo de colaborador:";
            string opcao0 = "[1] Médico(a)";
            string opcao1 = "[2] Enfermeiro(a)";
            string opcao2 = "[3] Administrador(a)";
            string opcao3 = "[4] Contratado(a)";

            System.Console.WriteLine($"{header}\n\n{opcao0}\n{opcao1}\n{opcao2}\n{opcao3}\n");

            var opcao = System.Console.ReadLine();

            System.Console.WriteLine("Informe a identificação do colaborador:\n");

            var identificacao = System.Console.ReadLine();

            MostrarBarraCarregamento();

            IRecebedor membro = new Administrador("default");
            switch (opcao)
            {
                case "1":
                    membro = new Medico(identificacao);
                    break;
                case "2":
                    membro = new Enfermeiro(identificacao);
                    break;
                case "3":
                    membro = new Administrador(identificacao);
                    break;
                case "4":
                    membro = new Contratado(identificacao);
                    break;
                default:
                    System.Console.WriteLine("Opção Inválida:");
                    System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                    System.Console.ReadKey();
                    CadastrarColaborador();
                    break;
            }

            try
            {
                _gestao.PagavelHospitalar.Adicionar(membro);

                System.Console.WriteLine($"Colaborador {identificacao} cadastrado com sucesso!");
                System.Console.WriteLine("Gostaria de cadastrar outro? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    CadastrarColaborador();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");

                System.Console.ReadKey();
                CadastrarColaborador();
                return;
            }
        }

        internal static void RemoverColaborador()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== REMOVER COLABORADOR ===========");

            System.Console.WriteLine("\nDigite a identificação do colaborador que deseja remover:\n");
            var Identificador = System.Console.ReadLine();

            MostrarBarraCarregamento();

            try
            {
                _gestao.PagavelHospitalar.Remover(Identificador);

                System.Console.WriteLine("Exclusão realizada com sucesso!");

                System.Console.WriteLine("\nGostaria de dar entrada em outro? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    RemoverColaborador();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                RemoverColaborador();
                return;
            }
        }

        internal static void InformarHoras()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== PAGAR COLABORADORES ===========");

            System.Console.WriteLine("\nDigite a identificação do colaborador que deseja pagar:\n");
            var identificador = System.Console.ReadLine();

            System.Console.WriteLine("\nDigite as horas trabalhadas pelo colaborador:\n");
            var horasTrabalhadas = Convert.ToInt32(System.Console.ReadLine());

            MostrarBarraCarregamento();

            try
            {
                _gestao.InformarHoras(horasTrabalhadas, identificador);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                InformarHoras();
                return;
            }
        }

        internal static void PagarColaboradores()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== PAGAR COLABORADORES ===========");

            MostrarBarraCarregamento();

            try
            {
                _gestao.PagarRecebedores();

                System.Console.WriteLine("Pagamento realizado com sucesso!\n");

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                PagarColaboradores();
                return;
            }
        }

        internal static void ExibirSalariosPagos()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== EXIBIR SALÁRIOS PAGOS ===========");

            System.Console.WriteLine("\nDigite a identificação do colaborador que exibir o salário:\n");
            var identificador = System.Console.ReadLine();

            MostrarBarraCarregamento();

            try
            {
                var listaPagamentos = _gestao.ExibirPagamentos(identificador);
                var membro = _gestao.PagavelHospitalar.Buscar(identificador);
                System.Console.WriteLine($"Colaborador: {membro.Identificador}");

                foreach (var pagamento in listaPagamentos)
                    System.Console.WriteLine(pagamento);

                System.Console.WriteLine("\nGostaria exibir outros pagamentos? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    ExibirSalariosPagos();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                RemoverColaborador();
                return;
            }
        }

        private static void MostrarBarraCarregamento()
        {
            for (int i = 0; i < 1; i++)
            {
                System.Console.Clear();
                System.Console.Write("Por favor, aguarde");

                for (int y = 0; y < 3; y++)
                {
                    System.Threading.Thread.Sleep(300);
                    System.Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
            }

            System.Console.Clear();
        }
    }
}