using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public ChampionStats championStats;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init()
    {
        championStats = new ChampionStats();
        manaStats = new ManaStats();
    }
}
