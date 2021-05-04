using UnityEngine;

[CreateAssetMenu]
public class FieldGridNodeData : ScriptableObject
{
    public GameObject nodeVisualizationGO;
    public float width;
    public Material playerANodeMat;
    public Material playerBNodeMat;
    public Material borderNodeMat;

    public Material highlightMaterial;
}