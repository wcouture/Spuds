using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour
{
    public Animator anim;
    public Animator options;
    public void nextScene()
    {
        StartCoroutine("nextSceneCour");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        options.SetTrigger("options");
    }

    IEnumerator nextSceneCour()
    {
        anim.SetTrigger("slideOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
