using System;

namespace GestaoHospilar.Tela
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var opcaoEscolhida = Operador.MenuPrincipal();

                switch (opcaoEscolhida)
                {
                    case "1":
                        Operador.CadastrarColaborador();
                        break;
                    case "2":
                        Operador.RemoverColaborador();
                        break;
                    case "3":
                        Operador.InformarHoras();
                        break;
                    case "4":
                        Operador.PagarColaboradores();
                        break;
                    case "5":
                        Operador.ExibirSalariosPagos();
                        break;
                }

            }
        }
    }
}
