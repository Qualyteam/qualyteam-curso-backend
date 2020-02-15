using System.Threading.Tasks;
using ReceitasWebApi.Domain.Entities;

namespace ReceitasWebApi.Domain.Services
{
    public interface IReceitaService
    {
        Task Insert(Receita receita);
    }
}