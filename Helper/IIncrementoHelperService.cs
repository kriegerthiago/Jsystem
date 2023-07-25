using System.Linq.Expressions;
using System.Linq;
using System;

namespace JucaSystem.Helper
{
    public interface IIncrementoHelperService
    {
        int ValidaIncremento<TEntidade, TCampo>(IQueryable<TEntidade> entidade, Expression<Func<TEntidade, TCampo>> campo) where TEntidade : class;
    }
}
