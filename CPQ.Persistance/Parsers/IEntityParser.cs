using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace CPQ.Persistance.Parsers
{
    public interface IEntityParser<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Parse(EntityCollection collection);
    }
}
