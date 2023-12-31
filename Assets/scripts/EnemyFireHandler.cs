using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireHandler : MonoBehaviour
{
    public float maxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;

        if (transform.position.y < -4.7 && gameObject.name == "EnemyFireball(Clone)")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.name == "Fireball(Clone)" || collision.gameObject.name == "Player" || collision.gameObject.tag == "Obstacles")
        {
             Destroy(gameObject);
        }
    }


}
