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
        IReceitaService _service;
        Context _context;

        public ReceitaServiceTests()
        {
            var option = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new Context(option);
            _service = new ReceitaService(_context);
        }

        [Fact]
        public void Insert_DeveSalvarUmaReceita()
        {
            var novaReceita = new Receita(null);
            _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(1);

            var receitaDoBanco = _context.Receitas.FirstOrDefault();
            receitaDoBanco.Titulo.Should().Be(novaReceita.Titulo);
        }

        [Fact]
        public async void GetAll_DeveRetornarTodasAsReceitas()
        {
            var feijoada = new Receita("Feijoada")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredientes",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            var burguer = new Receita("Burguer")
            {
                ImagemUrl = "ImagemUrl",
                Ingredientes = "Ingredientes",
                Descricao = "Descricao",
                MetodoDePreparo = "MetodoDePreparo",
            };

            _context.Receitas.AddRange(feijoada, burguer);
            _context.SaveChanges();

            var retorno = await _service.GetAll();
            retorno.Should().HaveCount(2);
            var feijoadaDoRetorno = retorno
                .FirstOrDefault(receita =>
                receita.Title == feijoada.Titulo
            );
            feijoadaDoRetorno.Should().NotBeNull();

        }
    }
}