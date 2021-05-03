using System;
using UnityEngine;

[CreateAssetMenu()]
public class FieldGridData : ScriptableObject
{
    public FieldGridNodeData nodeData;
    public Vector2 startingPoint;
    public int xSize;
    public int ySize;
    public int[] borderNodesId_A = { 5, 17, 29, 41, 53 };
    public int[] borderNodesId_B = { 6, 18, 30, 42, 54 };
}