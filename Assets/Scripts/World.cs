using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    public Transform movePoint;

    private Scene currentScene;
    private string sceneName;
    private Vector2 worldPosition, currentPosition;

    [SerializeField]
    public SceneInfo sceneInfo;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void Update()
    {
        currentPosition = new Vector2(movePoint.position.x, movePoint.position.y);
        if (sceneName == "Main" && worldPosition != currentPosition)
        {
            sceneInfo.worldPosition = currentPosition;
        }
    }
}
