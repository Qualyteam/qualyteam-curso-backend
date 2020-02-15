using System.Linq;
using FluentAssertions;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
using ReceitasWebApi.Infrastructure;
using Xunit;

namespace ReceitasWebApiTests.Domain.Services
{
    public class ReceitaServiceTests
    {
        IReceitaService _service;
        Context _context;

        [Fact]
        public void Insert_DeveSalvarUmaReceita()
        {
            var novaReceita = new Receita()
            {
                Titulo = "Feijoada"
            };

            _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(1);

            var receitaDoBanco = _context.Receitas.FirstOrDefault();
            receitaDoBanco.Titulo.Should().Be(novaReceita.Titulo);
        }
    }
}