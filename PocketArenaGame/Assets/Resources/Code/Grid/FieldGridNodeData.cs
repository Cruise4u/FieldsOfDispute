using UnityEngine;

[CreateAssetMenu]
public class FieldGridNodeData : ScriptableObject
{
    public int[] borderNodeId = { };
    public GameObject nodeVisualizationGO;
    public float width;
    public Material playableMaterial;
    public Material nonplayableMaterial;
    public Material highlightMaterial;
}