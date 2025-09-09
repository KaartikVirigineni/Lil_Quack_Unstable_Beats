using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour
{
    [Header("Animation")]
    public Animator transition;
    public int time = 1;

    [Header("Sprites")]
    public Image imageToChange;
    public Sprite spriteOnExit;
    public Sprite spriteOnEnter;

    void Start()
    {
        if (imageToChange != null && spriteOnEnter != null)
        {
            imageToChange.sprite = spriteOnEnter;
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        if (imageToChange != null && spriteOnExit != null)
        {
            imageToChange.sprite = spriteOnExit;
        }

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
