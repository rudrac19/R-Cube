using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Animator tutorial;

    int tutorialIsOver = 0; // 0 = false; 1 = true

    // Start is called before the first frame update
    void Start()
    {
        tutorialIsOver = PlayerPrefs.GetInt("isOver", 0);
        if (tutorialIsOver == 0)
        {
            Debug.Log("Tutorial Started");
            tutorial.SetTrigger("Start");
            PlayerPrefs.SetInt("isOver", 1);
            tutorialIsOver = PlayerPrefs.GetInt("isOver", 0);
        }
    }
}
