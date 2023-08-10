using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = 5f;

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		
		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
		
		pos += transform.rotation * velocity;

		transform.position = pos;

		if (transform.position.y >= 4.7 && gameObject.name == "Fireball(Clone)")
		{
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "EnemyFireball(Clone)" || collision.gameObject.tag == "Obstacles")
        {
            //Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
