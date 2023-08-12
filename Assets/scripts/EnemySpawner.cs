
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public static float delay = 3f;
    [SerializeField]private bool isGameActive = true;

    // Update is called once per frame
    void Update()
    {
       
    }

    async void Start()
    {
        await Task.Delay(5000);
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
