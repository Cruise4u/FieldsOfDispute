using System;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public FieldGrid fieldGrid;
    public FieldGridNode nodeBelowGO;
    public PlayerRaycast playerRaycast;

    public bool IsPossibleToMoveForward()
    {
        bool condition;
        var currentNode = nodeBelowGO;
        if (currentNode.nodeID != 0)
        {
            var nextNode = fieldGrid.nodeList[currentNode.nodeID + 1].GetComponent<FieldGridNode>();
            if(nextNode.unitStationed == null)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
        }
        else
        {
            condition = false;
        }
        return condition;
    }



}
