using System;
using UnityEngine;


public class RighteousStrike : Spell
{

    public override void CastSpell(int cost)
    {

    }

    public override void AimSpell(Camera camera,LayerMask mask)
    {
        var enemyTeamTag = "";
        PlayerRaycast.ShootRaycast(camera, mask);
        if(PlayerRaycast.hittedObject.tag == enemyTeamTag)
        {
            if(PlayerRaycast.hittedObject.GetComponent<FieldGridNode>())
            {
                
            }
        }
    }

    public void VisualizeSpell()
    {

    }

}
