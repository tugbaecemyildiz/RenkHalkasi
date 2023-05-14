using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [SerializeField] GameObject htpText;
    bool htpPanel = false;

    public void HowToPlay()
    {
        if (!htpPanel)
        {
            htpPanel = true; 
            htpText.SetActive(true);
            Time.timeScale = 0;
            TopKontrol.isStart = false;
        }
        else
        {
            htpPanel = false;
            htpText.SetActive(false);
            TopKontrol.isStart= false;
            Time.timeScale = 0;


        }
    }
}
