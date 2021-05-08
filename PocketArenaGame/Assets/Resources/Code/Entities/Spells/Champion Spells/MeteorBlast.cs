using System;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName ="Spell/Champion Spell/Meteor Blast")]
public class MeteorBlast : ChampionSpell
{
    public override void CastSpell(User user)
    {
        var spellIndicator = user.transform.GetChild(0).GetComponent<SpellController>().currentSpellIndicator;
        for (int i = 0; i < spellIndicator.transform.childCount; i++)
        {
            UseSpell(spellIndicator);
        }
        AnimateSpellVisualEffect(spellIndicator.transform.position);
    }

    public override void AimSpell(UserRaycast raycast)
    {
        var grid = FindObjectOfType<FieldGrid>();
        var user = raycast.GetComponent<User>();
        var indicator = user.transform.GetChild(0).GetComponent<SpellController>().currentSpellIndicator;
        int centerRowCoordinate = 0;
        raycast.ShootRaycast(raycast.userCamera, raycast.enemyMask);
        if(user.team == Team.A)
        {
            centerRowCoordinate = 9;
        }
        else
        {
            centerRowCoordinate = 2;
        }
        if (raycast.hittedObject != null && raycast.hittedObject.GetComponent<FieldGridNode>())
        {
            var hittedObjectCoordinates = raycast.hittedObject.GetComponent<FieldGridNode>().coordinates;
            indicator.SetActive(true);
            if(hittedObjectCoordinates.y > 0 && hittedObjectCoordinates.y < 5)
            {
                var hittedCoordinate = new Vector2(centerRowCoordinate, raycast.hittedObject.GetComponent<FieldGridNode>().coordinates.y);
                var hittedTransform = grid.nodeCoordinatesDictionary[hittedCoordinate].GetComponent<FieldGridNode>().unitStationedTransform.position;
                var adjustedPosition = new Vector3(hittedTransform.x, hittedTransform.y + 0.1f, hittedTransform.z);
                indicator.transform.position = adjustedPosition;
            }
        }
        else
        {
            if(spellStats.spellIndicator.activeSelf == true)
            {
                indicator.SetActive(false);
            }
        }
    }

    public override void UseSpell(GameObject spellIndicator)
    {
        Collider[] colliders = Physics.OverlapBox(spellIndicator.transform.position, spellIndicator.transform.lossyScale);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<UnitController>())
            {
                collider.GetComponent<UnitController>().TakeDamage(spellStats.spellPower);
                var stationPosition = collider.GetComponent<UnitController>().currentNode.unitStationedTransform.position;
                var origin = new Vector3(stationPosition.x, stationPosition.y + 10, stationPosition.z);
                var direction = stationPosition - origin;
            }
        }
    }

    public override void AnimateSpellVisualEffect(Vector3 position)
    {
        var spellVFX = Instantiate(spellStats.spellPrefab, position, Quaternion.identity);
        Destroy(spellVFX, 3.5f);
    }
}
