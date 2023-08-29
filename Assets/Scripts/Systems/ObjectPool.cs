using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class ObjectPool<T>
    {
        private readonly Func<T> _preloadFunc;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;
        
        private Queue<T> pool = new Queue<T>();
        private List<T> active = new List<T>();

        public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
        {
            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;
            if (preloadFunc is null)
            {
                Debug.LogError("Preload function is null");
                return;
            }

            for (int i = 0; i < preloadCount; i++)
            {
                Return(_preloadFunc());
            }
        }

        public T Get()
        {
            T item = pool.Count > 0 ? pool.Dequeue() : _preloadFunc();
            _getAction(item);
            active.Add(item);
            
            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            pool.Enqueue(item);
            active.Remove(item);
        }
        
        public void ReturnLastActive()
        {
            List<T> reversedUnitsList = new List<T>();

            for (int i = 0; i < active.Count; i++)
            {
                reversedUnitsList.Add(active[i]);
            }
            
            Return(reversedUnitsList[reversedUnitsList.Count - 1]);
        }

        public void ReturnAll()
        {
            foreach (T item in active.ToArray())
            {
                Return(item);
            }
        }

    }
}