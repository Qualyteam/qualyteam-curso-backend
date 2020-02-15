using System.Threading.Tasks;
using System;
using ReceitasWebApi.Domain.Entities;
using ReceitasWebApi.Domain.Services;
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
        public async Task Insert(Receita receita)
        {
             

            string titulo = receita.Titulo;            
            
            
            if (String.IsNullOrEmpty(titulo)) {
                throw new System.Exception("Error, titulo não pode ser null");
            } else {
               _context.Receitas.Add(receita);

                await _context.SaveChangesAsync();
            }
        }
    }
}