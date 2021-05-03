using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Spell/Meteor Blast")]
public class MeteorBlast : Spell
{
    RaycastHit castHit;

    public override void CastSpell(LayerMask mask)
    {
        GameObject[] spellNodeArray = new GameObject[spellStats.spellPrefab.transform.childCount];
        for(int i = 0; i < spellNodeArray.Length; i++)
        {
            var spell = spellNodeArray[i];
            var bottomPosition = new Vector3(spell.transform.position.x, spell.transform.position.y - 2.0f, spell.transform.position.z);
            if (Physics.Raycast(spell.transform.position, bottomPosition, out castHit, mask))
            {
                castHit.collider.gameObject.GetComponent<UnitController>().TakeDamage(spellStats.spellPower);
            }
        }
    }

    public override void AimSpell(FieldGrid grid,Camera camera,LayerMask mask)
    {
        var enemyTeamTag = "";
        PlayerRaycast.ShootRaycast(camera, mask);
        if(PlayerRaycast.hittedObject.tag == enemyTeamTag)
        {
            if(PlayerRaycast.hittedObject.GetComponent<FieldGridNode>())
            {
                VisualizeSpellOnGrid(grid,PlayerRaycast.hittedObject,spellStats.spellPrefab);
            }
        }
    }

    public override void VisualizeSpellOnGrid(FieldGrid grid,GameObject simulatedHit,GameObject spellPrefab)
    {
        if(spellPrefab != null && spellPrefab.activeSelf != true)
        {
            var hitPosition = simulatedHit.transform.position;
            var node = castHit.collider.gameObject.GetComponent<FieldGridNode>();
            spellPrefab.transform.position = new Vector3(hitPosition.x, hitPosition.y + 0.1f, hitPosition.z);
        }
    }
}
