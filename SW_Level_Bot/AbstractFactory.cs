using System;
using System.Collections.Generic;

namespace SW_Level_Bot
{
    internal abstract class AbstractFactory<TKey, TValue>
    {
        protected abstract Dictionary<TKey, Func<TValue>> Dict { get; }

        public virtual TValue Create(TKey key)
        {
            return Dict.TryGetValue(key, out var retValue)
                ? retValue()
                : throw new ArgumentException($"No value for {nameof(TKey)}.");
        }
    }
}