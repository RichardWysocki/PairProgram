using System;
using System.Collections.Generic;

namespace WebApplication.Library.Interface
{
    public class Subject : ISubject
    {
        private List<IObserver> _observer;

        public Subject()
        {
            _observer = new List<IObserver>();
        }
        public void Add(IObserver o)
        {
            _observer.Add(o);
        }

        public void Remove(IObserver o)
        {
            _observer.Remove(o);
        }

        public void NotifyObserver()
        {
            foreach (IObserver x in _observer)
            {
                x.Update("I'm here!");
            }
        }
    }
}