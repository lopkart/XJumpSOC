using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorController : MonoBehaviour {

    public GameObject EnemyPrefab;
    public Transform EnemyTransform;
    public Transform[] spawnPoints;

    public float delay;

    // Use this for initialization
    void Start ()
    {
        EnemyTransform.position = gameObject.transform.position;
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies ()
    {
        while (true)
        {
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                yield return new WaitForSeconds(delay);

                //int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[i];

                Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
