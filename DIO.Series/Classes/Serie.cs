using System;

namespace DIO.Series {
    class Serie : EntidadeBase {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; } 
        private bool Excluido { get; set; }


        public Serie (int id, Genero genero, string titulo, string descricao, int ano) {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public string RetornaTitulo() {
            return Titulo;
        }
        public int RetornaId() {
            return Id;
        }
        public void Excluir() {
            Excluido = true;
        }
        public override string ToString() {
            return "Gênero:" + Genero + Environment.NewLine +
                "Título: " + Titulo + Environment.NewLine +
                "Descrição: " + Descricao + Environment.NewLine +
                "Ano de Início: " + Ano;
        }
    }
}
