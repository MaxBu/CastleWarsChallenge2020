using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUIM : MonoBehaviour
{
    public Transform archerObj;
    //public GameObject lockUI;
    public GameObject archerCost;

    public int archerPrice = 12;
    

    void Start()
    {
        archerCost.GetComponent<TextMesh>().text = archerPrice.ToString();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(GameFlow.totalRes >= archerPrice)
        {
            PhotonNetwork.Instantiate(archerObj.name, archerObj.position, archerObj.rotation);
            //GameFlow.totalRes -= archerPrice;
            //Debug.Log(GameFlow.totalRes);
        }
        //gameObject.SetActive(false);
        //lockUI.SetActive(true);

        
    }
}
