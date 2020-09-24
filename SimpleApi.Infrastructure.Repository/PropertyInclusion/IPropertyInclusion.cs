using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimpleApi.Infrastructure.PropertyInclusion
{
    public interface IPropertyInclusion<T> where T : class
    {
        IQueryable<T> IncludeAllVirtualProperties(DbSet<T> Entities);
    }
}