
using System.Collections;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float delay = 2f;
    [SerializeField]private bool isGameActive = true;

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    public IEnumerator spawnRoutine() {

        while (isGameActive)
        {
            System.Random rand = new System.Random();
            int randSpawnPoint = rand.Next(0, spawnPoints.Length);
            
            Instantiate(enemyPrefab, spawnPoints[randSpawnPoint].position, transform.rotation);
            enemyPrefab.transform.Rotate(0, 0, 180);
            yield return new WaitForSeconds(delay);
        }
            
    }

}
