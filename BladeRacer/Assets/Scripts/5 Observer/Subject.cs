using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly List<Observer> _observers 
        = new List<Observer>();

    public void Attach(Observer observer)
    {
        _observers.Add(observer);
    }
    public void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach (Observer o in _observers)
            o.Notify(this);
    }
}
