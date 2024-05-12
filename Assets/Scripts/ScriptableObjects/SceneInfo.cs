using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
    public Vector2 worldPosition;
    public float posX = -0.5f;
    public float posY = -0.5f;

    private void OnEnable()
    {
        worldPosition = new Vector2(posX, posY);
    }
}
