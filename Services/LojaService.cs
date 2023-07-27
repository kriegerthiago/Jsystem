using JucaSystem.Dto;
using JucaSystem.Helper;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Linq;

namespace JucaSystem.Services
{
    public class LojaService : ILojaService
    {
        private readonly Context _context;
        private readonly IIncrementoHelperService _incrementoHelpService;

        public LojaService(Context context, IIncrementoHelperService incrementoHelperService)
        {
            _context = context;
            _incrementoHelpService = incrementoHelperService;
        }

        public Loja GetLojaById(int id)
        {
            try
            {
                var loja = _context.Lojas.Where(p => p.LojaId == id).FirstOrDefault();
                if (loja != null)
                    return loja;
                else
                    return null;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public bool InserirNovaLoja(LojaDto lojaModel)
        {
            var lojaId = _incrementoHelpService.ValidaIncremento(_context.Lojas, p => p.LojaId);

            var objLoja = new Loja()
            {
                LojaId = lojaId,
                DescricaoEndereco = lojaModel.DescricaoEndereco,
                DescricaoNome = lojaModel.DescricaoNome
            };
            _context.Lojas.Add(objLoja);
            _context.SaveChanges();
            return true;
        }


        public Loja UpdateLoja(Loja lojaModel)
        {
            try
            {
                var loja = _context.Lojas.AsNoTracking().Where(p => p.LojaId == lojaModel.LojaId).FirstOrDefault();

                var objLojaAlteracao = new Loja()
                {
                    DescricaoEndereco = lojaModel.DescricaoEndereco,
                    DescricaoNome = lojaModel.DescricaoEndereco,
                    LojaId = loja.LojaId
                };
                _context.Lojas.Update(objLojaAlteracao);
                _context.SaveChanges();

                return objLojaAlteracao;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteLoja(int id)
        {
            try
            {
                var loja = _context.Lojas.AsNoTracking().Where(p => p.LojaId == id).FirstOrDefault();

                _context.Lojas.Remove(loja);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

