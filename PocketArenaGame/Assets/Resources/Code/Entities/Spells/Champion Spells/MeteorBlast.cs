using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Spell/Champion Spell/Meteor Blast")]
public class MeteorBlast : ChampionSpell
{
    public override void CastSpell(Player player)
    {
        var spellIndicator = player.transform.GetChild(0).GetComponent<SpellController>().currentSpellIndicator;
        for (int i = 0; i < spellIndicator.transform.childCount; i++)
        {
            UseSpell(spellIndicator);
        }
    }

    public override void AimSpell(Player player,Camera camera,LayerMask mask)
    {
        var grid = FindObjectOfType<FieldGrid>();
        var raycast = player.playerController.playerRaycast;
        var indicator = player.transform.GetChild(0).GetComponent<SpellController>().currentSpellIndicator;
        raycast.ShootRaycast(camera, mask);
        int centerRowCoordinate = 0;
        if(player.playerTeam == PlayerTeam.TeamA)
        {
            centerRowCoordinate = 9;
        }
        else
        {
            centerRowCoordinate = 2;
        }
        if(raycast.hittedObject != null && raycast.hittedObject.GetComponent<FieldGridNode>())
        {
            indicator.SetActive(true);
            var hittedCoordinate = new Vector2(centerRowCoordinate, raycast.hittedObject.GetComponent<FieldGridNode>().coordinates.y);
            var hittedTransform = grid.nodeCoordinatesDictionary[hittedCoordinate].GetComponent<FieldGridNode>().unitStationedTransform.position;
            var adjustedPosition = new Vector3(hittedTransform.x, hittedTransform.y + 0.1f, hittedTransform.z);
            indicator.transform.position = adjustedPosition;
        }
        else
        {
            if(spellStats.spellIndicator.activeSelf == true)
            {
                indicator.SetActive(false);
            }
        }
    }

    public override void UseSpell(GameObject spellShape)
    {
        Collider[] colliders = Physics.OverlapBox(spellShape.transform.position, spellShape.transform.lossyScale);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<UnitController>())
            {
                collider.GetComponent<UnitController>().TakeDamage(spellStats.spellPower);
            }
        }
    }

}
