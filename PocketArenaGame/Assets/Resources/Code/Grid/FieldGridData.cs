using System;
using UnityEngine;

[CreateAssetMenu()]
public class FieldGridData : ScriptableObject
{
    public FieldGridNodeData nodeData;
    public int xSize;
    public int ySize;
}