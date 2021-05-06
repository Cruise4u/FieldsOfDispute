using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public Team playerTeam;
    public ChampionHealth championHealth;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init(Team playerTeam)
    {
        championHealth.Init();
        manaStats.Init();
        if (playerTeam == Team.A)
        {
            this.playerTeam = Team.A;
        }
        else
        {
            this.playerTeam = Team.B;
        }
        spellController.Init(this.playerTeam);
    }
}
