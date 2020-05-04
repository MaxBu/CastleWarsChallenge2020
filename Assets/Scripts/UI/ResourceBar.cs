using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider slider;
    public Text maxResText;
    public Text currentResText;

    private void Start()
    {
        
    }

    public void SetMaxRes(int res)
    {
        slider.maxValue = res;
        slider.value = res;
    }

    public void SetRes(int res)
    {
        slider.value = res;
    }

   public void SetMaxResText(string resMaxStr)
    {
        maxResText.text = resMaxStr;
    }

    public void SetCurrentResText(string resCurStr)
    {
        currentResText.text = resCurStr;
    }
}
