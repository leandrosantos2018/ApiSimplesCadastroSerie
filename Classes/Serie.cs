using Dio.Series.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Series
{
    class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }

        private String Titulo { get; set; }

        private String Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, String titulo,String descricao,int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }
        public override string ToString()
        {
            String retorno = "";
            retorno += "Genero" + this.Genero + Environment.NewLine;
            retorno += "Titulo" + this.Titulo + Environment.NewLine;
            retorno += "Descricao" + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Está Excluido: " + this.Excluido;

            return retorno;
        }

        public String retornoTitulo()
        {
            return this.Titulo;
        }
        
        public int retornoId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

    }
}
