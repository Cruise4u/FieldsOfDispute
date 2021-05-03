using System;
using UnityEngine;

public abstract class Spell
{
    public int originPoint;
    public SpellStats spellStats;
    public abstract void CastSpell(int spellCost);
    public abstract void AimSpell(Camera camera, LayerMask mask);
 }

public class SpellShape
{
    public int[] targetedNodes;
    public int xSize;
    public int ySize;
    public void CalculateShapeSize(FieldGridNode node)
    {
        var originPoint = node.nodeID;
        for (int y = 0; y < xSize; y++)
        {
            for (int x = 0; x < ySize; x++)
            {

            }
        }
    }

    public void DisplayShapeOnField()
    {

    }

    public void CastShapeOnField(Camera camera,LayerMask mask,string adversaryTeamString)
    {
        PlayerRaycast.ShootRaycast(camera, mask);
        if (PlayerRaycast.hittedObject.tag == adversaryTeamString)
        {
            if (PlayerRaycast.hittedObject.GetComponent<FieldGridNode>())
            {
                CalculateShapeSize(PlayerRaycast.hittedObject.GetComponent<FieldGridNode>());
            }
        }
    }

    
}