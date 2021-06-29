using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series {
    class SerieRepositorio : IRepositorio<Serie> {
        private List<Serie> listaSerie = new List<Serie>();

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
