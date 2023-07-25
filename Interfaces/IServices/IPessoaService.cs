using JucaSystem.Dto;
using JucaSystem.Models;
using System.Collections.Generic;

namespace JucaSystem.Interfaces.IServices
{
    public interface IPessoaService
    {
        List<Pessoa> GetPessoaById(int pessoaId);
        bool InserirNovaPessoa(PessoaDto pessoaModel);
        Pessoa UpdatePessoa(Pessoa pessoa);
        bool DeletePessoa(int pessoaId);
    }
}
