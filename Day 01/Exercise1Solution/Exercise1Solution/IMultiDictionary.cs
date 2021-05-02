using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1Solution
{
    public interface IMultiDictionary<K, V>
    {
        void Add(K key, V value);

        bool Remove(K key);

        bool Remove(K key, V value);

        void Clear();

        bool ContainsKey(K key);

        bool Contains(K key, V value);

        IEnumerable<K> Keys { get; }

        IEnumerable<V> Values { get; }

        int Count { get; }

    }
}
