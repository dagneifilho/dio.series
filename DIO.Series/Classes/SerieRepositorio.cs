using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.IO;

namespace DIO.Series {
    class SerieRepositorio : IRepositorio<Serie> {
        private List<Serie> listaSerie = new List<Serie>();
        public SerieRepositorio() {
            if (File.Exists("series.txt")) {
                //Implementar leitura do arquivo
                try {
                    using (StreamReader sr = File.OpenText("series.txt")) {
                        while (!sr.EndOfStream) {
                            //Formato da linha: id,titulo,genero,descricao,ano,excluido
                            string[] linha = sr.ReadLine().Split(',');
                            int id = int.Parse(linha[0]);
                            string titulo = linha[1];
                            int genero = int.Parse(linha[2]);
                            string descricao = linha[3];
                            int ano = int.Parse(linha[4]);
                            bool excluido = bool.Parse(linha[5]);

                            Serie novaSerie = new Serie(id, (Genero)genero, titulo, descricao, ano, excluido);
                            listaSerie.Add(novaSerie);
                        }
                    }
                } catch(IOException e) {
                    Console.WriteLine("Ocorreu um erro.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void AdicionaSerie(Serie serie) {
            try {
                //Formato da linha: id,titulo,genero,descricao,ano,excluido
                string linha = "" + serie.RetornaId() + "," + serie.RetornaTitulo() + "," + serie.RetornaGenero() + "," + serie.RetornaDescricao() + "," + serie.RetornaAno() +
                    "," + serie.RetornaExcluido();
                using (StreamWriter sw = File.AppendText("series.txt")) {
                    sw.WriteLine(linha);
                }
            } catch (IOException e) {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(e.Message);
            }
        }
        private  void ReescreverArquivo() {
            try {
                foreach (Serie serie in listaSerie) { 
                    string linha = "" + serie.RetornaId() + "," + serie.RetornaTitulo() + "," + serie.RetornaGenero() + "," + serie.RetornaDescricao() + "," + serie.RetornaAno() +
                    "," + serie.RetornaExcluido();
                    using (StreamWriter sw = new StreamWriter("series.txt", false)) {
                        sw.WriteLine(linha);
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("Ocorreu um erro.");
                Console.WriteLine(e.Message);
            }
        }
        public List<Serie> Lista() {
            return listaSerie;
        }
        public void Atualiza(int id, Serie entidade) {
            //Para que a serie atualizada fique na mesma posição do que a anterior, resolvi limpar o arquivo e reescrever as séries novamente.
            listaSerie[id] = entidade;
            ReescreverArquivo();

        }
        public void Exclui(int id) {
            //Para mudar o status de excluido também é necessário reescrever o arquivo.
            listaSerie[id].Excluir();
            ReescreverArquivo();
        }
        public void Insere(Serie objeto) {
            listaSerie.Add(objeto);
            AdicionaSerie(objeto);
        }
        public int ProximoId() {
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id) {
            return listaSerie[id];
        }
    }
}
