using UnityEngine;

public class GlobalPositionViewer : MonoBehaviour
{
    private void Update()
    {
        Vector2 globalPosition = transform.position;
        Debug.Log("Global Position: " + globalPosition);
    }
}