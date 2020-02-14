using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
using ReceitasWebApi.Infrastructure;
using ReceitasWebApi.Services;
using Xunit;

namespace ReceitasWebApiTests.Domain.Services
{
    public class ReceitaServiceTests
    {
        Context _context;
        IReceitaService _service;

        public ReceitaServiceTests()
        {
            var options = new DbContextOptionsBuilder<Context>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            _context = new Context(options);
            _service = new ReceitaService(_context);
        }

        [Fact]
        public void Insert_DeveInserirUmaReceita()
        {
            var novaReceita = new Receita()
            {
                Titulo = "Titulo",
                Descricao = "Descricao",
                Ingredientes = "Ingredientes",
                Preparacao = "Preparacao",
                UrlDaImagem = "UrlDaImagem"
            };

            _service.Insert(novaReceita);

            _context.Receitas.Should().HaveCount(1);
            var receitasBanco = _context.Receitas.FirstOrDefault();
            receitasBanco.Titulo.Should().Be(novaReceita.Titulo);
            receitasBanco.Descricao.Should().Be(novaReceita.Descricao);
            receitasBanco.Ingredientes.Should().Be(novaReceita.Ingredientes);
            receitasBanco.Preparacao.Should().Be(novaReceita.Preparacao);
            receitasBanco.UrlDaImagem.Should().Be(novaReceita.UrlDaImagem);
        }
    }
}