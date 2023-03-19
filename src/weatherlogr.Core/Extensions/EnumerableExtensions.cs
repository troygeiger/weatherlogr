using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherlogr.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WithCancellation<T>(this IEnumerable<T> en, CancellationToken token)
        {
            foreach (var item in en)
            {
                token.ThrowIfCancellationRequested();
                yield return item;
            }
        }

        public static Task<T[]> ToArrayAsync<T>(this IEnumerable<T> en) => ToArrayAsync<T>(en, CancellationToken.None);

        public static Task<T[]> ToArrayAsync<T>(this IEnumerable<T> en, CancellationToken token)
        {
            return Task.Run(() =>
            {
                List<T> items = new List<T>();
                foreach(T item in en)
                {
                    if (token.IsCancellationRequested) break;
                    items.Add(item);
                }
                return items.ToArray();
            });
        }
    }
}
