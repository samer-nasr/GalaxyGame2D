using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] asteroidsPrefab;
    public float delay = 5f;
    [SerializeField] private bool isGameActive = true;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(12000);
        StartCoroutine(spawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnRoutine()
    {

        while (isGameActive)
        {
            System.Random rand = new System.Random();
            //Generate a random number for spawn position from the spawPoints Array//
            int randSpawnPoint = rand.Next(0, spawnPoints.Length);
            //Generate a random number for asteroid prefabs from the asteroidsPrefabs Array//
            int randAsteroid = rand.Next(0, asteroidsPrefab.Length);

            Instantiate(asteroidsPrefab[randAsteroid], spawnPoints[randSpawnPoint].position, transform.rotation);
           
            yield return new WaitForSeconds(delay);
        }

    }
}
