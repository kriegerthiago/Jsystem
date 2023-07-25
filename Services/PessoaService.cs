using JucaSystem.Dto;
using JucaSystem.Helper;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JucaSystem.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly Context _context;
        private readonly IIncrementoHelperService _incrementoHelpService;

        public PessoaService(Context context, IIncrementoHelperService incrementoHelperService)
        {
            _context = context;
            _incrementoHelpService = incrementoHelperService;
        }


        public List<Pessoa> GetPessoaById(int pessoaId)
        {
            try
            {
                return _context.Pessoas.Where(p => p.PessoaId == pessoaId).ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool InserirNovaPessoa(PessoaDto pessoaModel)
        {
            try
            {
                var pessoaId = _incrementoHelpService.ValidaIncremento(_context.Pessoas, p => p.PessoaId);
                var objPessoa = new Pessoa()
                {
                    PessoaId = pessoaId,
                    DescricaoNome = pessoaModel.DescricaoNome,
                    DescricaoObservacaoReferencia = pessoaModel.DescricaoObservacaoReferencia,
                    NumeroDDD = pessoaModel.NumeroDDD,
                    NumeroTelefone = pessoaModel.NumeroTelefone
                };

                _context.Pessoas.Add(objPessoa);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public Pessoa UpdatePessoa(Pessoa pessoaModel)
        {
            var entidade = _context.Pessoas.AsNoTracking().Where(p => p.PessoaId == pessoaModel.PessoaId).FirstOrDefault();

            var objPessoa = new Pessoa()
            {
                PessoaId = entidade.PessoaId,
                DescricaoNome = pessoaModel.DescricaoNome,
                DescricaoObservacaoReferencia = pessoaModel.DescricaoObservacaoReferencia,
                NumeroDDD = pessoaModel.NumeroDDD,
                NumeroTelefone = pessoaModel.NumeroTelefone
            };

            _context.Update(objPessoa);
            _context.SaveChanges();

            return objPessoa;
        }


        public bool DeletePessoa(int pessoaId)
        {
            try
            {
                var pessoa = _context.Pessoas.Where(p => p.PessoaId == pessoaId).FirstOrDefault();
                _context.Remove(pessoa);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}



