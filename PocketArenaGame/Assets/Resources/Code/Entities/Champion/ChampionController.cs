using System;
using UnityEngine;

public class ChampionController : MonoBehaviour
{
    public PlayerTeam playerTeam;
    public ChampionHealth championHealth;
    public ManaStats manaStats;
    public SpellController spellController;

    public void Init(PlayerTeam playerTeam)
    {
        championHealth.Init();
        manaStats.Init();
        if (playerTeam == PlayerTeam.TeamA)
        {
            this.playerTeam = PlayerTeam.TeamA;
        }
        else
        {
            this.playerTeam = PlayerTeam.TeamB;
        }
        spellController.Init(this.playerTeam);
    }
}
