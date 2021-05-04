using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public ChampionHealth championHealth;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init()
    {
        championHealth.Init();
        manaStats.Init();
    }
}
