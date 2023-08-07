using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float maxSpeed = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 180);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Fireball(Clone)" || collision.gameObject.name == "Player")
        { 
            //Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    public void move()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }

    }
