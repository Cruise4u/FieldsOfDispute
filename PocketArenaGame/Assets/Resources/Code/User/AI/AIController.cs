using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : UserController
{
    public AIOption currentOption;


    public enum AIOption
    {
        Spell,
        Switch,
    }

    public  void ChooseOption()
    {
        int randomOption = Random.Range(0, 1);
        if(randomOption == 0)
        {
            currentOption = AIOption.Spell;
        }
        else
        {
            currentOption = AIOption.Switch;
        }
    }

    public bool CheckIfOptionIsValid()
    {
        bool condition;
        condition = true;
        return condition;
    }

    public void GetRandomNodeToSpawn()
    {
        var pool = FindObjectOfType<PoolController>();
        var grid = FindObjectOfType<FieldGrid>();
        int numberOfAvailableNodes = 0;
        Vector2[] randomCoordinate;
        for(int i = 0; i < grid.spawningNodeList.Count; i++)
        {
            if(grid.spawningNodeList[i].unitStationed == null)
            {
                numberOfAvailableNodes += 1;
            }
        }
        randomCoordinate = new Vector2[numberOfAvailableNodes];
        for(int i = 0; i < randomCoordinate.Length; i++)
        {
            randomCoordinate[i] = grid.spawningNodeList[i].coordinates;
        }
        int randomNumber = Random.Range(0, randomCoordinate.Length);
        pool.SpawnFromPool(randomCoordinate[randomNumber]);
    }

    public void ChooseNodeToSpawn()
    {
        //var raycast = gameObject.GetComponent<AIRaycast>();
        //raycast.ShootRaycast(raycast.userCamera, raycast.userMask);
        //if (raycast.hittedObject != null)
        //{
        //    if (raycast.hittedObject.tag == "SpawnNode" && raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed == null)
        //    {
        //        var instance = pool.GetObjectFromTopOfStack();
        //        pool.SpawnFromPool(raycast.hittedObject.GetComponent<FieldGridNode>().unitStationedTransform.position);
        //        raycast.hittedObject.GetComponent<FieldGridNode>().unitStationed = instance;
        //        instance.GetComponent<UnitController>().currentNode = raycast.hittedObject.GetComponent<FieldGridNode>();
        //        numberOfSpawnsPerTurn -= 1;
        //    }
        //}
    }

}
