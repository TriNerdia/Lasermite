using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public static int MaxEnemyCount = 5;
    GameObject[] enemies;
    int numEnemies;
    public int SpawnDelay = 5;
    bool spawning;
    public AudioSource spawnSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator SpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(SpawnDelay);

        if (spawning == false)
        {
            spawning = true;
            yield return wait;
            Instantiate(Enemy, transform.position, transform.rotation);
            spawnSound.Play(0);
            spawning = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = enemies.Length;
        if (numEnemies < MaxEnemyCount)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }
}
