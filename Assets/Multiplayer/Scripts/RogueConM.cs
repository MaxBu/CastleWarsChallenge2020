using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueConM : MonoBehaviour
{
    private Rigidbody2D roguerb;
    private Animator anim;
    private GameObject enemyMage;
    private GameObject enemyCastle;

    void Start()
    {
        roguerb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyMage = GameObject.FindGameObjectWithTag("enemymage");
        enemyCastle = GameObject.FindGameObjectWithTag("enemycastle");

        StartCoroutine(waitingForWalk());
        

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("step1"))
        {
            StopCoroutine(waitingForWalk());
            roguerb.velocity = new Vector2(10, 25);

        }

        if (other.CompareTag("step2"))
        {

            anim.ResetTrigger("rogueRun");
            anim.SetTrigger("rogueIdle");
            roguerb.velocity = new Vector2(0, 0);
            
            if(enemyMage == true)
            {
                //anim.ResetTrigger("rogueIdle");
                anim.SetTrigger("rogueAttack");
                
                //Debug.Log("Animation of kill!");
               // anim.SetTrigger("rogueAttack");
                
            }
            else
            {
                anim.ResetTrigger("rogueAttack");
                StartCoroutine(waitingForHide());
            }

            if(enemyCastle == true && enemyMage == false)
            {
                anim.SetTrigger("rogueBoom");
                //GameFlow.enemyCastleHP -= 2;
                //Debug.Log("Enemy Castle HP: " + GameFlow.enemyCastleHP);
                //Debug.Log("Making BOOM");

            }

        }

        


    }

    //public void ShadowStep()
    //{
    //    roguerb.velocity = new Vector2(20, 0);
    //}

    IEnumerator waitingForWalk()
    {
        yield return new WaitForSeconds(2);
        roguerb.velocity = new Vector2(40, 0);
        anim.SetTrigger("rogueRun");

    }

    IEnumerator waitingForHide()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }


}