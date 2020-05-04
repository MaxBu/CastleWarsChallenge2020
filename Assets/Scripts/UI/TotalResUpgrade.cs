using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalResUpgrade : MonoBehaviour
{
    public int upgradeRes = 10;
    public int upgradeCounterRes = 1;
    public int upgradeCost;
    public Text upgradeResText;


    // Update is called once per frame
    void Update()
    {
        upgradeCost = GameFlow.totalRes;
        upgradeResText.text = (upgradeCost.ToString());
    }

    private void OnMouseDown()
    {
        Debug.Log("CurrentRes: " + GameFlow.currentRes);
        Debug.Log("upgradeCost: " + upgradeCost);
        if (GameFlow.currentRes >= upgradeCost)
        {
            GameFlow.currentRes -= upgradeCost;
            GameFlow.totalRes += upgradeRes;
            GameFlow.counterRes += upgradeCounterRes;
        }
            //GameFlow.currentRes -= upgradeCost;
            //GameFlow.counterRes += upgradeCounterRes;
            //GameFlow.totalRes += upgradeRes;
        
        
    }
}
