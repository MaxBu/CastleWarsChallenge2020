using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUI : MonoBehaviour
{
    public  Transform meleeSoldier;
    public GameObject lockUI;
    public GameObject warrCost;
    
    public float cooldownMeleeUI = 3f;
    public int meleePrice = 6;

    private BoxCollider2D spawnButton;

    void Start()
    {
        //isLockUI();
        warrCost.GetComponent<TextMesh>().text = meleePrice.ToString();
        spawnButton = this.GetComponent<BoxCollider2D>();

    }

    
    void Update()
    {
        
        

    }

    

    private void OnMouseDown()
    {
        if(GameFlow.currentRes >= meleePrice)
        {
            spawnButton.enabled = false;
            lockUI.SetActive(true);
            Instantiate(meleeSoldier, meleeSoldier.position, meleeSoldier.rotation);
            //PhotonNetwork.Instantiate(meleeSoldier.name, meleeSoldier.position, meleeSoldier.rotation);
            GameFlow.currentRes -= meleePrice;
            //Debug.Log(GameFlow.totalRes);
            if (lockUI.activeSelf == true)
            {
                StartCoroutine("meleeCooldown");
            }
        }
        
        

        
    }

    IEnumerator meleeCooldown()
    {
        yield return new WaitForSeconds(cooldownMeleeUI);
        lockUI.SetActive(false);
        spawnButton.enabled = true;
        //gameObject.SetActive(true);
        //StartCoroutine(spawnEnemyFireball());

    }
}
