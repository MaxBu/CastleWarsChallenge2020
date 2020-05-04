using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MageUIM : MonoBehaviour
{

    public Transform mageObj;
    //public Transform fireballUI;
    public GameObject lockUI;
    public int magePrice = 24;
    public GameObject mageCost;

    void Start()
    {
        mageCost.GetComponent<TextMesh>().text = magePrice.ToString();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(GameFlow.totalRes >= magePrice)//вынести число в инспектор для управления балансом
        {
            gameObject.SetActive(false);
            lockUI.SetActive(true);
            PhotonNetwork.Instantiate(mageObj.name, mageObj.position, mageObj.rotation);
            //Instantiate(fireballUI, fireballUI.position, fireballUI.rotation);
            GameFlow.totalRes -= magePrice;
            //Debug.Log(GameFlow.totalRes);
        }
        //need check for active in scene
        //gameObject.SetActive(false);
        //lockUI.SetActive(true);

        
    }
    
}
