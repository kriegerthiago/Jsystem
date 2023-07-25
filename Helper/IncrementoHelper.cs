using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JucaSystem.Helper
{
    public class IncrementoHelper : IIncrementoHelperService
    {
        public int ValidaIncremento<TEntidade, TCampo>(IQueryable<TEntidade> entidade, Expression<Func<TEntidade, TCampo>> campo) where TEntidade : class
        {
            try
            {
                if (entidade.Count() > 0)
                {
                    var incremento = entidade.Max(campo);
                    return Convert.ToInt32(incremento) + 1;

                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
