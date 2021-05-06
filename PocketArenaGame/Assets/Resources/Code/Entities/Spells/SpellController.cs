using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public List<ChampionSpell> spellList;

    public GameObject currentSpellIndicator;

    public void Init(Team playerTeam)
    {
        var user = gameObject.GetComponent<User>();
        var raycast = gameObject.GetComponent<UserRaycast>();
        if(user.team == Team.A)
        {
            raycast.playerFieldMask = LayerMask.GetMask("NodeA");
            raycast.enemyFieldMask = LayerMask.GetMask("NodeB");
        }
        else
        {
            raycast.playerFieldMask = LayerMask.GetMask("NodeB");
            raycast.enemyFieldMask = LayerMask.GetMask("NodeA");
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
        var user = gameObject.GetComponentInParent<User>();
        var userRaycast = gameObject.GetComponent<UserRaycast>();
        if (spell.spellEffect.targetType == TargetType.Allie)
        {
            spell.AimSpell(userRaycast);
        }
        else
        {
            spell.AimSpell(userRaycast);
        }
    }

    public void CastSpecificSpell(ChampionSpell spell)
    {
        var user = gameObject.GetComponentInParent<User>();
        spell.CastSpell(user);
    }
}
