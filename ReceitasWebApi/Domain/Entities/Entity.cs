using System;

namespace ReceitasWebApi.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}