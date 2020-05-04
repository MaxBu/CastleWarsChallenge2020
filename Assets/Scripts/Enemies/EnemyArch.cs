using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArch : MonoBehaviour
{
    

    public int enemyArcherHP = 10;
    public int enemyfireDelay = 3;
    public int enemyArrowtakingDamage = 4;

    public Transform enemyArrowObj;

    private Rigidbody2D enemyArchRB;
    private Animator anim;
    private BoxCollider2D box2d;

    private bool onPosition = false;

    // Start is called before the first frame update
    void Start()
    {

        enemyArchRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();

        move();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyArcherHP <= 0)
        {
            stop();
            anim.SetTrigger("archerDie");
            box2d.enabled = false;
            Destroy(gameObject, 0.8f);
        }
    }

    private void move()
    {
        
        enemyArchRB.velocity = new Vector2(-1, 0);
        

    }

    private void stop()
    {
        enemyArchRB.velocity = new Vector2(0, 0);
        anim.SetTrigger("archerIdle");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("playerExplosion"))
        {
            enemyArcherHP = 0;
        }

        if (other.CompareTag("enemyArcherStop"))
        {
            onPosition = true;
            stop();
            //anim.SetTrigger("archerIdle");
            StartCoroutine("rangeAtackRate");
        }

        if (other.CompareTag("ourmelee"))
        {
            stop();
            StartCoroutine("receviedDamage");
            //StartCoroutine("rangeAtackRate");
            //StartCoroutine(receviedDamage());
        }

        if (other.CompareTag("ourarrow"))
        {
            enemyArcherHP -= enemyArrowtakingDamage;
            //Debug.Log("EnemyHP: " + enemyMeleeHP);
        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ourmelee"))
        {
            //Debug.Log(enemyArcherHP);
            StopCoroutine("receviedDamage");
            anim.ResetTrigger("archerIdle");
            anim.SetTrigger("archerRun");
            if (!onPosition)
            {
                move();
            }
            
        }
        
    }

    IEnumerator rangeAtackRate()
    {
        yield return new WaitForSeconds(enemyfireDelay);
        Instantiate(enemyArrowObj, transform.position, enemyArrowObj.rotation);
        anim.SetTrigger("archerShoot");
        StartCoroutine("rangeAtackRate");
    }

    IEnumerator receviedDamage()
    {
        yield return new WaitForSeconds(1);
        enemyArcherHP -= 5;
        StartCoroutine("receviedDamage");

    }
}
