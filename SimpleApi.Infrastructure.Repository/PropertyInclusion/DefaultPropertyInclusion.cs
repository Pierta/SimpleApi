using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimpleApi.Infrastructure.PropertyInclusion
{
    public class DefaultPropertyInclusion<T> : IPropertyInclusion<T> where T : class
    {
        public IQueryable<T> IncludeAllVirtualProperties(DbSet<T> Entities)
        {
            return Entities.AsQueryable();
        }
    }
}