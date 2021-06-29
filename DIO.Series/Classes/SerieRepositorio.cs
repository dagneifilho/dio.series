using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.IO;

namespace DIO.Series {
    class SerieRepositorio : IRepositorio<Serie> {
        private List<Serie> listaSerie = new List<Serie>();
        public SerieRepositorio(){
            if (File.Exists("series.txt")){
                //Implementar leitura do arquivo
            }
        }
        
        private static void AdicionaSerie(Serie serie){
            try {
                string linha = ""+serie.RetornaId()+","+serie.RetornaTitulo()+"";
              

            } catch(IOException e){
                Console.WriteLine("An error occurred.");
                Console.WriteLine(e.Message);
            }
        }
        public List<Serie> Lista() {
            return listaSerie;
        }
        public void Atualiza (int id, Serie entidade) {
            listaSerie[id] = entidade;
        }
        public void Exclui (int id) {
            listaSerie[id].Excluir();
        }
        public void Insere (Serie objeto) {
            listaSerie.Add(objeto);
        }
        public int ProximoId() {
            return listaSerie.Count;
        }
        public Serie RetornaPorId (int id) {
            return listaSerie[id];
        }

        
    }
}
