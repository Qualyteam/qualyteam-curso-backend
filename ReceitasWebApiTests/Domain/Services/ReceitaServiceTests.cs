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

        [Fact]
        public void Insert_TituloNotNull()
        {
            var novaReceita = new Receita()
            {
                Titulo = ""
            };

            _service.Insert(novaReceita);

            _context.Receitas
                .Should()
                .HaveCount(0);

            /*var receitaDoBanco = _context.Receitas.FirstOrDefault();
            receitaDoBanco.Titulo.Should().NotBeNul*/
        }

        // [Fact]
        // public void Insert_TituloMenorQue60Caracteres()
        // {
        //     var novaReceita = new Receita()
        //     {
        //         Titulo = "1234567890123456789012345678901234567890123456789012345678901234567890"
        //     };

        //     _service.Insert(novaReceita);

        //     _context.Receitas
        //         .Should()
        //         .HaveCount(0);

        //     /*var receitaDoBanco = _context.Receitas.FirstOrDefault();
        //     receitaDoBanco.Titulo.Should().NotBeNul*/
        // }
    }
}