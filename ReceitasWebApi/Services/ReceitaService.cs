using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
using ReceitasWebApi.Domain.ViewModel;
using ReceitasWebApi.Infrastructure;

namespace ReceitasWebApi.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly Context _context;
        public ReceitaService(Context context)
        {
            _context = context;
        }

        public async Task<ReceitaViewModel[]> GetAll()
        {
            return await _context.Receitas
                .Select(receita =>
                    new ReceitaViewModel()
                )
                .ToArrayAsync();
        }

        public async Task<ReceitaViewModel> GetOne(Guid id)
        => await _context.Receitas
        .Where(receita => receita.Id == id)
        .Select(receita => new ReceitaViewModel()
        {
            Id = receita.Id,
            Title = receita.Titulo,
            Description = receita.Descricao,
            Ingredients = receita.Ingredientes,
            Preparation = receita.MetodoDePreparo,
            ImageUrl = receita.ImagemUrl
        })
        .FirstOrDefaultAsync();

        public async Task Insert(Receita receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
        }
    }
}