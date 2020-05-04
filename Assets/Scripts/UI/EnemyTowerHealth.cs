using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTowerHealth : MonoBehaviour
{
    public int enemyCastleHP = 100;
    public int currentEnemyCastleHP;
    public int enemyCastleDamage = 2;
    public int enemyArrowtakingDamage = 4;

    public HealthBar healthBar;

    // Start is called before the first frame update

    void Start()
    {
        currentEnemyCastleHP = enemyCastleHP;
        healthBar.SetMaxHealth(enemyCastleHP);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentEnemyCastleHP);

        if (currentEnemyCastleHP < 1)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ourmelee"))
        {
            //Debug.Log("Castle HIT!");

            StartCoroutine("castleDamage");

        }

        if (other.CompareTag("ourarrow"))
        {
            currentEnemyCastleHP -= enemyArrowtakingDamage;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ourmelee"))
        {
            StopCoroutine("castleDamage");
        }
    }



    IEnumerator castleDamage()
    {
        yield return new WaitForSeconds(1);

        currentEnemyCastleHP -= enemyCastleDamage;
        
        StartCoroutine("castleDamage");
        //Debug.Log(currentEnemyCastleHP);
    }
}

