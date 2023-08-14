using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HealScript : MonoBehaviour
{

    [SerializeField] public GameObject healPrefabs;
    public Transform[] spawnPoints;
    public float delay = 10f;
    private bool isGameActive = true;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(15000);
        StartCoroutine(spawnHeal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnHeal()
    {

        while (isGameActive)
        {
            System.Random rand = new System.Random();
            //Generate a random number for spawn position from the spawPoints Array//
            int randSpawnPoint = rand.Next(0, spawnPoints.Length);
            
            Instantiate(healPrefabs, spawnPoints[randSpawnPoint].position, transform.rotation);

            yield return new WaitForSeconds(delay);
        }

    }

    
}
