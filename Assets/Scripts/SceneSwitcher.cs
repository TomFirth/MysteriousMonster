using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer fadeSprite;
    public float fadeSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeSprite.gameObject.SetActive(true);
        Color color = fadeSprite.color;
        while (color.a > 0)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            fadeSprite.color = color;
            yield return null;
        }
        fadeSprite.gameObject.SetActive(false);
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadeSprite.gameObject.SetActive(true);
        Color color = fadeSprite.color;
        while (color.a < 1)
        {
            color.a += fadeSpeed * Time.deltaTime;
            fadeSprite.color = color;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
