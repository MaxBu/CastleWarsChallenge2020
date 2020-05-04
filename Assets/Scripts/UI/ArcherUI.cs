using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUI : MonoBehaviour
{
    public Transform archerObj;
    public GameObject lockUI;
    public GameObject archerCost;

    public int archerPrice = 12;
    public float cooldownArchUI = 7f;

    private BoxCollider2D spawnButton;


    void Start()
    {
        archerCost.GetComponent<TextMesh>().text = archerPrice.ToString();
        spawnButton = this.GetComponent<BoxCollider2D>();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(GameFlow.currentRes >= archerPrice)//вынести число в инспектор для управления балансом
        {
            spawnButton.enabled = false;
            lockUI.SetActive(true);
            Instantiate(archerObj, archerObj.position, archerObj.rotation);
            GameFlow.currentRes -= archerPrice;

            if (lockUI.activeSelf == true)
            {
                StartCoroutine("archCooldown");
            }
            //Debug.Log(GameFlow.totalRes);
        }
        //gameObject.SetActive(false);
        //lockUI.SetActive(true);

        
    }

    IEnumerator archCooldown()
    {
        yield return new WaitForSeconds(cooldownArchUI);
        lockUI.SetActive(false);
        spawnButton.enabled = true;
        //gameObject.SetActive(true);
        //StartCoroutine(spawnEnemyFireball());

    }
}
