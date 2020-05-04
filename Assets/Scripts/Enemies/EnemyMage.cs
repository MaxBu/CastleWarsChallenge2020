using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : MonoBehaviour
{

    public float fireballSpawnRate = 1f;
    public Transform enemyFireball;
    public static bool enemyMageHere = true;
    // Start is called before the first frame update
    void Start()
    {
        //enemyMageHere = true;
        StartCoroutine(spawnEnemyFireball());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("rogueweapon"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator spawnEnemyFireball()
    {
        
            yield return new WaitForSeconds(fireballSpawnRate);
            Instantiate(enemyFireball, enemyFireball.position, enemyFireball.rotation);
            StartCoroutine(spawnEnemyFireball());
        
    }
}
