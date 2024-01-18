using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void OpenScene() 
    {
        SceneManager.LoadScene("Dirctions");
    }
 
}
