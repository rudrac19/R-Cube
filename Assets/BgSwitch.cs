using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSwitch : MonoBehaviour
{
    public GameObject[] Bgs;
    public int BgNum = 0;

    void Update()
    {

    }

    public void Switch()
    {
        BgNum++;
        if (BgNum != 4)
        {
            Bgs[BgNum].SetActive(true);
            Bgs[(BgNum - 1)].SetActive(false);
            Bgs[(BgNum + 1)].SetActive(false);
        }

        if (BgNum == 4)
        {
            BgNum = 0;
            Bgs[0].SetActive(true);
            Bgs[1].SetActive(false);
            Bgs[2].SetActive(false);
            Bgs[3].SetActive(false);
        }

        
        
    }
}
