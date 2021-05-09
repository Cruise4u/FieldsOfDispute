using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public enum AIOption
{
    Spell,
    Swap,
}

public class AIController : UserController
{
    public AIOption currentOption;
    public GameObject swappingUnit;
    public override void SwapAdjacentUnits()
    {
        var temporaryNode = pickedUnit.GetComponent<UnitController>().currentNode;
        pickedUnit.GetComponent<UnitController>().MoveUnitToNode(swappingUnit.GetComponent<UnitController>().currentNode);
        swappingUnit.GetComponent<UnitController>().MoveUnitToNode(temporaryNode);
        isUnitPicked = false;
    }
    public override void Init()
    {
        spawnNumber = Mathf.Clamp(2, 0, 3);
    }
    public override void ChooseNodeToSpawn()
    {
        var pool = gameObject.GetComponent<PoolController>();
        var raycast = gameObject.GetComponent<AIRaycast>();
        raycast.ShootRaycast(raycast.userCamera, raycast.userMask);
        if (raycast.hittedObject != null)
        {
            if (raycast.hittedObject.tag == "SpawnNode" && raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
            {
                var instance = pool.GetObjectFromTopOfStack();
                pool.SpawnFromPool(raycast.hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position);
                raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed = instance;
                instance.GetComponent<UnitController>().currentNode = raycast.hittedObject.GetComponent<FieldGridNode>();
                spawnNumber -= 1;
            }
        }
    }

    public AIOption GetRandomOptionToPerform()
    {
        int random = Random.Range(0, 2);
        if(random == 1)
        {
            currentOption = AIOption.Spell;
        }
        else
        {
            currentOption = AIOption.Swap;
        }
        return currentOption;
    }
    public int GetRandomSpellName()
    {
        var spellList = gameObject.transform.GetChild(0).GetComponent<SpellController>().spellList;
        int randomNumber = Random.Range(0, spellList.Count);
        return spellList[randomNumber].spellStats.spellId;
    }
    public Vector2 GetRandomNodeBySpellId(Spell spell)
    {
        var spellController = gameObject.transform.GetChild(0).GetComponent<SpellController>();
        Vector2 spellCoordinates = new Vector2(-1, -1);
        List<Vector2> coordinatesList = new List<Vector2>();
        switch(spell.spellStats.spellId)
        {
            case 0:
                var grid = FindObjectOfType<FieldGrid>();
                var nodeList = grid.nodeList;
                foreach (GameObject nodeGO in nodeList)
                {
                    if (nodeGO.GetComponent<FieldGridNode>().coordinates.x == 2 && nodeGO.GetComponent<FieldGridNode>().coordinates.y > 0 || nodeGO.GetComponent<FieldGridNode>().coordinates.x == 2 && nodeGO.GetComponent<FieldGridNode>().coordinates.y < 5)
                    {
                        coordinatesList.Add(nodeGO.GetComponent<FieldGridNode>().coordinates);
                    }
                }
                int randomNumber = Random.Range(0, coordinatesList.Count);
                spellCoordinates = coordinatesList[randomNumber];
                break;
        }
        return spellCoordinates;
    }
    public Vector2 GetRandomNodeSpawnCoordinates()
    {
        var pool = FindObjectOfType<PoolController>();
        var grid = FindObjectOfType<FieldGrid>();
        int numberOfAvailableNodes = 0;
        for (int i = 0; i < grid.spawningNodeList.Count; i++)
        {
            if (grid.spawningNodeList[i].unitStationed == null)
            {
                numberOfAvailableNodes += 1;
            }
        }
        Vector2[] randomCoordinate = new Vector2[numberOfAvailableNodes];
        for (int i = 0; i < randomCoordinate.Length; i++)
        {
            randomCoordinate[i] = grid.spawningNodeList[i].coordinates;
        }
        int randomNumber = Random.Range(0, randomCoordinate.Length);
        Debug.Log(randomNumber);
        return randomCoordinate[randomNumber];
    }
    public void FindPossibleUnitsToPick()
    {
        //pickedUnit = null;
        //swappingUnit = null;
        for (int i = 0; i < unitList.Count; i++)
        {
            pickedUnit = unitList[i].gameObject;
            for (int j = 0; j < unitList.Count; j++)
            {
                if (pickedUnit != unitList[j].gameObject)
                {
                    if (pickedUnit.GetComponent<UnitController>().currentNode.coordinates.x == unitList[j].GetComponent<UnitController>().currentNode.coordinates.x)
                    {
                        if(unitList[j].GetComponent<UnitController>().currentNode.coordinates.y == pickedUnit.GetComponent<UnitController>().currentNode.coordinates.y +1 || unitList[j].GetComponent<UnitController>().currentNode.coordinates.y == pickedUnit.GetComponent<UnitController>().currentNode.coordinates.y - 1) 
                        { 
                            swappingUnit = unitList[j].gameObject;
                            isUnitPicked = true;
                            break;
                        }
                    }
                }
            }
        }
    }
    public bool CheckIfOptionIsValid()
    {
        bool condition;
        condition = true;
        return condition;
    }
    public void ChooseOption()
    {
        int randomOption = Random.Range(0, 1);
        if (randomOption == 0)
        {
            currentOption = AIOption.Spell;
        }
        else
        {
            currentOption = AIOption.Swap;
        }
    }

}
