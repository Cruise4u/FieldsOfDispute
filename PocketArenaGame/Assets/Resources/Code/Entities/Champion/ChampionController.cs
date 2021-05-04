using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public ChampionHealth championStats;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init()
    {
        championStats = new ChampionHealth();
        manaStats = new ManaStats();
    }
}
