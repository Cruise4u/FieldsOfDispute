using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpellSubject
{
    List<ISpellObserver> observerList { get; }

    void AttachObserver();

    void RemoveObserver();

    void NotifyObserver(float cooldown);
}

