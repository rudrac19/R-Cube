using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Animator tutorial;

    bool tutorialIsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (tutorialIsOver == false)
        {
            Debug.Log("Tutorial Started");
            tutorial.SetTrigger("Start");
        }
    }
}
