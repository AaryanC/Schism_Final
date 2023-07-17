using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmosSelected()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.back, radius);
    }
}
