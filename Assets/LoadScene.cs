using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.30f;

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadLevelString(sceneName));
    }

    IEnumerator LoadLevelString(string levelName)
    {
        transition.SetTrigger("Go");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
