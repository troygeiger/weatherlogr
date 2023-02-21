using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => queryable.FirstOrDefault(), cancellationToken);
        }

        public static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, T? defaultValue, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => queryable.FirstOrDefault(defaultValue), cancellationToken);
        }

        public static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => queryable.FirstOrDefault(predicate), cancellationToken);
        }
    }
}