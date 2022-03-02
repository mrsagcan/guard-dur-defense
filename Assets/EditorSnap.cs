using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] private float gridSize = 10f;
    void Update()
    {
        Vector3 snapPos, objectPos = transform.position;
        snapPos.x = Mathf.RoundToInt(objectPos.x / 10f) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(objectPos.z / 10f) * gridSize;
        transform.position = snapPos;
    }
}
