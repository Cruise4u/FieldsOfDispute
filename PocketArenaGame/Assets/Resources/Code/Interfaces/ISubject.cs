using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> observerList { get; }

    void AttachObserver();

    void RemoveObserver();

    void NotifyObserver(IObserver observer,float cooldown);
}

