using System;
//09:04

namespace DIO.Series {
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args) {

            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X") {
                switch (opcaoUsuario) {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();

                    default:
                        throw new ArgumentOutOfRangeException();


                }
            }
        }
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries;");
            Console.WriteLine("2 - Inserir nova série;");
            Console.WriteLine("3 - Atualizar série;");
            Console.WriteLine("4 - Excluir série;");
            Console.WriteLine("5 - Visualizar série;");
            Console.WriteLine("C - Limpar tela;");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;

        }    
    }
}
