using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerTowerHealth : MonoBehaviour
{


    public int playerCastleHP = 100;
    public int currentPlayerCastleHP;
    public int playerCastleDamage = 2;
    public int enemyArrowtakingDamage = 4;

    public HealthBar healthBar;

    // Start is called before the first frame update

    void Start()
    {
        currentPlayerCastleHP = playerCastleHP;
        healthBar.SetMaxHealth(playerCastleHP);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentPlayerCastleHP);

        if (currentPlayerCastleHP < 1)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemymelee"))
        {
            Debug.Log("Castle HIT!");
            
            StartCoroutine("castleDamage");

        }

        if (other.CompareTag("enemyArrow"))
        {
            
            currentPlayerCastleHP -= enemyArrowtakingDamage;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemymelee"))
        {
            StopCoroutine("castleDamage");
        }
    }



    IEnumerator castleDamage()
    {
        yield return new WaitForSeconds(1);

        currentPlayerCastleHP -= playerCastleDamage;
        
        StartCoroutine("castleDamage");
        Debug.Log(currentPlayerCastleHP);
    }
}
