using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCreatures : MonoBehaviour
{
    public Timer time;
    public RandomLevelGenerator rndLevel;

    public GameObject[] spawners;
    public GameObject[] enemy;

    public float timeDelay;
    public float creatureGenerator;

    public void Awake()
    {
        creatureGenerator = Random.Range(1, 3);

    }
    public void Start()
    {
        enemy = new GameObject[2];
        spawners = new GameObject[17];

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(EnemyDrop());
    }

    private void SpawnEnemyLEVEL1()
    {
        int spawnerID1 = Random.Range(2, 6);
        int creatureID1 = Random.Range(0, enemy.Length);

        Instantiate(enemy[creatureID1], spawners[spawnerID1].transform.position, spawners[spawnerID1].transform.rotation);
    }
    private void SpawnEnemyLEVEL2()
    {
        int spawnerID2 = Random.Range(6, 11);
        int creatureID2 = Random.Range(0, enemy.Length);

        Instantiate(enemy[creatureID2], spawners[spawnerID2].transform.position, spawners[spawnerID2].transform.rotation);
    }
    private void SpawnEnemyLEVEL3()
    {
        int spawnerID3 = Random.Range(13, 17);
        int creatureID3 = Random.Range(0, enemy.Length);

        Instantiate(enemy[creatureID3], spawners[spawnerID3].transform.position, spawners[spawnerID3].transform.rotation);
    }

    IEnumerator EnemyDrop()
    {
        timeDelay = Random.Range(12f, 15f);
        yield return new WaitForSeconds(timeDelay);

        if (time.timeValue > 0)
        {
            if (rndLevel.generator == 1)
            {
                SpawnEnemyLEVEL1();
            }
            else if (rndLevel.generator == 2)
            {
                SpawnEnemyLEVEL2();
            }
            else if (rndLevel.generator == 3)
            {
                SpawnEnemyLEVEL3();
            }
            StartCoroutine(EnemyDrop());
        }        
    }
}
