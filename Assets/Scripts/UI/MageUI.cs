using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MageUI : MonoBehaviour
{

    public Transform mageObj;
    public Transform fireballUI;
    public GameObject lockUI;
    public int magePrice = 24;
    public GameObject mageCost;
    public float cooldownMageUI = 24f;

    private BoxCollider2D spawnButton;

    void Start()
    {
        mageCost.GetComponent<TextMesh>().text = magePrice.ToString();
        spawnButton = this.GetComponent<BoxCollider2D>();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(GameFlow.currentRes >= magePrice)//вынести число в инспектор для управления балансом
        {
            spawnButton.enabled = false;
            lockUI.SetActive(true);
            Instantiate(mageObj, mageObj.position, mageObj.rotation);
            Instantiate(fireballUI, fireballUI.position, fireballUI.rotation);
            GameFlow.currentRes -= magePrice;

            if (lockUI.activeSelf == true)
            {
                StartCoroutine("mageCooldown");
            }
            //Debug.Log(GameFlow.totalRes);
        }
        //need check for active in scene
        //gameObject.SetActive(false);
        //lockUI.SetActive(true);

        
    }

    IEnumerator mageCooldown()
    {
        yield return new WaitForSeconds(cooldownMageUI);
        lockUI.SetActive(false);
        spawnButton.enabled = true;
        //gameObject.SetActive(true);
        //StartCoroutine(spawnEnemyFireball());

    }

}
