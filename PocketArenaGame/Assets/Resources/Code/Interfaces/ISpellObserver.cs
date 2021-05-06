using System.Collections;
using UnityEngine;

public interface ISpellObserver
{
    void GetNotified(float cooldown);
}