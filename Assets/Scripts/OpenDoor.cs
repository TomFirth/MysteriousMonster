using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private bool playerDetected;

    public Transform movePoint;

    public LayerMask door;

    [SerializeField]
    private string sceneName;

    private SceneSwitcher sceneSwitch;

    private void Start()
    {
        sceneSwitch = GetComponent<SceneSwitcher>();
    }

    public void checkDoor()
    {
        playerDetected = Physics2D.OverlapCircle(movePoint.position, .2f, door);
        if (playerDetected && sceneSwitch != null)
        {
            sceneSwitch.FadeToScene(sceneName);
        }
    }
}
