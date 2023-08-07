using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{

    public float delay = 2f;
    public GameObject projectile;
    [SerializeField] private bool isGameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator shootRoutine()
    {
        while (isGameActive)
        {
            Vector3 pos = transform.position;
            pos.y -= 2;
            Instantiate(projectile, pos, transform.rotation);
            yield return new WaitForSeconds(delay);
        }

    }

}
