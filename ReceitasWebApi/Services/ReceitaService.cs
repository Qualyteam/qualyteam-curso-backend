using System.Threading.Tasks;
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
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
        }
    }
}