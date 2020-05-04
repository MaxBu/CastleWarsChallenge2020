using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueUI : MonoBehaviour
{
    public Transform rogueObj;
    public Transform rogueSkillUI;
    public GameObject lockUI;
    private BoxCollider2D spawnButton;
    public GameObject rogueCost;

    public int roguePrice = 24;
    public float cooldownRogueUI = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rogueCost.GetComponent<TextMesh>().text = roguePrice.ToString();
        spawnButton = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(GameFlow.currentRes >= roguePrice)
        {
            GameFlow.currentRes -= roguePrice;
            spawnButton.enabled = false;
            lockUI.SetActive(true);

            Instantiate(rogueObj, rogueObj.position, rogueObj.rotation);

            if (lockUI.activeSelf == true)
            {
                StartCoroutine("rogueCooldown");
            }
        }
        
        
        //Instantiate(rogueSkillUI, rogueSkillUI.position, rogueSkillUI.rotation);
    }

    IEnumerator rogueCooldown()
    {
        yield return new WaitForSeconds(cooldownRogueUI);
        lockUI.SetActive(false);
        spawnButton.enabled = true;
        //gameObject.SetActive(true);
        //StartCoroutine(spawnEnemyFireball());

    }

}
