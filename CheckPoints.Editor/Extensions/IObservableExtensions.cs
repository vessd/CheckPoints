using CheckPoints.Logic.Common;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace CheckPoints.Editor.Extensions
{
    public static class IObservableExtensions
    {
        public static IObservable<IEnumerable<T>> AddOrUpdate<T>(this IObservable<IEnumerable<T>> source, SourceCache<T, long> sourceCache)
            where T : Entity => source.Do(sourceCache.AddOrUpdate);
    }
}
