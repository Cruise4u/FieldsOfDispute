using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Spell/Meteor Blast")]
public class MeteorBlast : Spell
{
    public override void CastSpell(GameObject spellShape)
    {
        for(int i = 0; i < spellShape.transform.childCount; i++)
        {
            PerformSpellOnTarget(spellShape.transform.GetChild(i).gameObject);
        }
    }

    public override void AimSpell(GameObject indicator,PlayerController controller,Camera camera,LayerMask mask)
    {
        var grid = FindObjectOfType<FieldGrid>(); 
        controller.playerRaycast.ShootRaycast(camera, mask);
        if(Physics.Raycast(controller.playerRaycast.playerRay, out controller.playerRaycast.playerCastHit, mask))
        {
            if (indicator != null && indicator.activeSelf != false)
            {
                if(controller.playerTeam == PlayerTeam.TeamA)
                {
                    if (controller.playerRaycast.playerCastHit.collider.GetComponent<FieldGridNode>())
                    {
                        var hittedCoordinate = new Vector2(9, controller.playerRaycast.playerCastHit.collider.gameObject.GetComponent<FieldGridNode>().coordinates.y);
                        var hittedTransform = grid.nodeCoordinatesDictionary[hittedCoordinate].GetComponent<FieldGridNode>().unitStationedTransform.position;
                        var adjustedPosition = new Vector3(hittedTransform.x, hittedTransform.y + 0.1f, hittedTransform.z);
                        indicator.transform.position = adjustedPosition;
                    }
                }
                else
                {
                    var hittedCoordinate = new Vector2(2, controller.playerRaycast.playerCastHit.collider.gameObject.GetComponent<FieldGridNode>().coordinates.y);
                    var hittedTransform = grid.nodeCoordinatesDictionary[hittedCoordinate].GetComponent<FieldGridNode>().unitStationedTransform.position;
                    var adjustedPosition = new Vector3(hittedTransform.x, hittedTransform.y + 0.1f, hittedTransform.z);
                    indicator.transform.position = adjustedPosition;
                }
            }
        }
        else
        {
            Debug.Log("Not hitting anything!");
        }
    }

    public void PerformSpellOnTarget(GameObject go)
    {
        Collider[] colliders = Physics.OverlapBox(go.transform.position,go.transform.lossyScale);
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject);
            if (collider.gameObject.GetComponent<UnitController>())
            {
                Debug.Log(collider.gameObject);
                collider.gameObject.GetComponent<UnitController>().TakeDamage(spellStats.spellPower);
            }
        }
    }
}
