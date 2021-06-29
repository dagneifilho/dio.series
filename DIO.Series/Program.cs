using System;

namespace DIO.Series {
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args) {

            string opcaoUsuario = ObterOpcaoUsuario().ToUpper();
            while (opcaoUsuario != "X") {
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
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario().ToUpper();
            }
        }
        private static void ListarSeries(){
            Console.WriteLine("Listar Séries");
            Console.WriteLine();
            var lista = repositorio.Lista();
            if (lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista){
                string excluido = (serie.RetornaExcluido() ? "Excluido" : "Disponível");
                Console.WriteLine($"ID {serie.RetornaId()} - {serie.RetornaTitulo()} - {excluido}");
            }
        }
        
        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();
            int id = repositorio.ProximoId();
            Serie novaSerie = new Serie(id,(Genero)entradaGenero,entradaTitulo, entradaDescricao, entradaAno);
            repositorio.Insere(novaSerie);
        } 
        
        private static void AtualizarSerie(){
            Console.Write("Digite o Id da série: ");
            Console.WriteLine();
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();
            Serie serieAtualizada = new Serie(indiceSerie, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            
            repositorio.Atualiza(indiceSerie, serieAtualizada);
        }

        private static void ExcluirSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
            Console.WriteLine();
        }

        private static void VizualizarSerie(){
            Console.Write("Digite o Id da série: ");
            Console.WriteLine();
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
        
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
