using System;

namespace ReceitasWebApi.Domain.Entities
{
    public class Receita : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacao { get; set; }
        public string UrlDaImagem { get; set; }
    }
}