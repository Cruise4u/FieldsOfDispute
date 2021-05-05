using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public List<ChampionSpell> spellList;
    public LayerMask playerFieldMask;
    public LayerMask enemyFieldMask;
    public GameObject currentSpellIndicator;

    public void Init(PlayerTeam playerTeam)
    {
        if(playerTeam == PlayerTeam.TeamA)
        {
            playerFieldMask = LayerMask.GetMask("NodeA");
            enemyFieldMask = LayerMask.GetMask("NodeB");
        }
        else
        {
            playerFieldMask = LayerMask.GetMask("NodeB");
            enemyFieldMask = LayerMask.GetMask("NodeA");
        }
    }

    public void EnableIndicator(ChampionSpell spell)
    {
        currentSpellIndicator = Instantiate(spell.spellStats.spellIndicator);
    }

    public void DisableIndicator()
    {
        Destroy(currentSpellIndicator);
    }

    public void AimSpecificSpell(ChampionSpell spell)
    {
        var player = gameObject.GetComponentInParent<Player>();
        var playerCamera = player.playerController.playerRaycast.playerCamera;
        if (spell.spellEffect.targetType == TargetType.Allie)
        {
            spell.AimSpell(player,playerCamera,playerFieldMask);
        }
        else
        {
            spell.AimSpell(player, playerCamera, enemyFieldMask);
        }
    }

    public void CastSpecificSpell(ChampionSpell spell)
    {
        var player = gameObject.GetComponentInParent<Player>();
        spell.CastSpell(player);
    }
}
