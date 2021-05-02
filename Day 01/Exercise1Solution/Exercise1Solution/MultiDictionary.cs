using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Exercise1Solution
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>
    {
        private Dictionary<K, LinkedList<V>> _internalDictionary;


        public MultiDictionary()
        {
            _internalDictionary = new Dictionary<K, LinkedList<V>>();
        }

        public IEnumerable<K> Keys
        {
            get
            {
                return _internalDictionary.Keys;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                var list = new List<V>();
                foreach (var key in _internalDictionary.Keys)
                {
                    foreach (var item in _internalDictionary[key])
                    {
                        list.Add(item);
                    }
                }

                return list;
            }
        }

        public int Count
        {
            get
            {
                return Values.Count();
            }
        }

        public IEnumerable<V> this[K key]
        {
            get
            {
                return _internalDictionary[key];
            }
        }

        public void Add(K key, V value)
        {
            if (!_internalDictionary.ContainsKey(key))
            {
                _internalDictionary.Add(key, new LinkedList<V>());
            }

            _internalDictionary[key].AddLast(value);
        }

        public void Clear()
        {
            _internalDictionary.Clear();
        }

        public bool Contains(K key, V value)
        {
            if (!_internalDictionary.ContainsKey(key)) return false;
            var list = _internalDictionary[key];

            return list.Contains(value);
        }

        public bool ContainsKey(K key)
        {
            return _internalDictionary.ContainsKey(key);
        }

        public bool Remove(K key)
        {
            return _internalDictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            if (!_internalDictionary.ContainsKey(key))
                throw new KeyNotFoundException();

            var list = _internalDictionary[key];

            var res = list.Remove(value);

            if (list.Count == 0)
                _internalDictionary.Remove(key);

            return res;
        }
    }
}
