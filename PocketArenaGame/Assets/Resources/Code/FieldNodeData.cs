using UnityEngine;

[CreateAssetMenu]
public class FieldNodeData : ScriptableObject
{
    public GameObject nodeVisualizationGO;
    public float width;
    public Material playableMaterial;
    public Material nonplayableMaterial;
}