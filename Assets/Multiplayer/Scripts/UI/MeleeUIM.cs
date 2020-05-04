using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUIM : MonoBehaviour
{
    public  Transform meleeSoldier;
    

    //public GameObject lockUI;
    public GameObject warrCost;

    public int meleePrice = 6;

    void Start()
    {
        //isLockUI();
        warrCost.GetComponent<TextMesh>().text = meleePrice.ToString();

    }

    
    void Update()
    {
        
        

    }

    

    private void OnMouseDown()
    {
        if(GameFlow.totalRes >= meleePrice)
        {
            

            PhotonNetwork.Instantiate(meleeSoldier.name, meleeSoldier.position, meleeSoldier.rotation);
            //PhotonNetwork.Instantiate(meleeSoldier.name, meleeSoldier.position, meleeSoldier.rotation);
            GameFlow.totalRes -= meleePrice;
            //Debug.Log(GameFlow.totalRes);
        }
        
        

        
    }
}
