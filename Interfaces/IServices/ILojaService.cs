using JucaSystem.Dto;
using JucaSystem.Models;

namespace JucaSystem.Interfaces.IServices
{
    public interface ILojaService
    {
        Loja GetLojaById(int id);
        bool InserirNovaLoja(LojaDto lojaModel);
        Loja UpdateLoja(Loja lojaModel);
        bool DeleteLoja(int id);
    }
}
