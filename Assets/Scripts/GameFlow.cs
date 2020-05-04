using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    //public static int enemyCastleHP = 100;
    //public static int ourCastleHP = 100;
    //public int currentOurCastleHealth;
    public static int totalRes;
    public static int currentRes;
    public static int counterRes = 1;

    
    
    public GameObject resourceText;
    public ResourceBar resourceBar;
    //public HealthBar healthBar;
    public Transform enemyWarr;
    public Transform enemyArch;
    public Transform enemyMage;
    

    public float meleeSpawnRate = 4f;
    public float archerSpawnRate = 8f;
    public float mageSpawnRate = 30f;
    

    private GameObject enemyMageOnScene;
    //private bool enemyMageOnScene = false;

    private void Awake()
    {
        totalRes = 8;
        counterRes = 1;
    }

    void Start()
    {

        currentRes = 0;
        
        //currentOurCastleHealth = ourCastleHP;

        // healthBar.SetHealth(GameFlow.ourCastleHP);
        //enemyMageOnScene = GameObject.FindGameObjectWithTag("enemymage");
        StartCoroutine("GenerateRes");
        
        StartCoroutine(spawnEnemyMelee());
        StartCoroutine(spawnEnemyArcher());
        
        StartCoroutine(spawnEnemyMage());

        
        
    }



    void Update()
    {
        resourceBar.SetMaxRes(totalRes);
        resourceBar.SetRes(currentRes);
        resourceBar.SetMaxResText("Макс. " + totalRes.ToString());
        resourceBar.SetCurrentResText(currentRes.ToString());

        

        //resourceText.GetComponent<TextMesh>().text = totalRes.ToString();

    }

    IEnumerator GenerateRes()
    {
        yield return new WaitForSeconds(1);
        
        //Debug.Log(totalRes);
        if (currentRes >= totalRes)
        {
            currentRes += 0;
        }
        else
        {
            currentRes += counterRes;
        }

        StartCoroutine("GenerateRes");
    }

        IEnumerator spawnEnemyMelee()
    {
        yield return new WaitForSeconds(meleeSpawnRate);
        Instantiate(enemyWarr, enemyWarr.position, enemyWarr.rotation);

        StartCoroutine(spawnEnemyMelee());
    }


    IEnumerator spawnEnemyArcher()
    {
        yield return new WaitForSeconds(archerSpawnRate);
        Instantiate(enemyArch, enemyArch.position, enemyArch.rotation);

        StartCoroutine(spawnEnemyArcher());
    }


    IEnumerator spawnEnemyMage()
    {
        yield return new WaitForSeconds(mageSpawnRate);
        Instantiate(enemyMage, enemyMage.position, enemyMage.rotation);
        
        StartCoroutine(spawnEnemyMage());
    }
}
