using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMove : MonoBehaviour
{

    public float maxSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (transform.position.y < -4.7)
        {
            Destroy(gameObject);
        }
    }

    public void move()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, -maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
}
