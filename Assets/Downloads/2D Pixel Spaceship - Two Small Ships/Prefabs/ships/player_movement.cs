using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveHorizontalSpeed;
    private float moveVerticalSpeed;

    private float moveHorizontal;
    private float moveVertical;

    public ScreenBounds screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveHorizontalSpeed = 3f;
        moveVerticalSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveHorizontalSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f || moveVertical < -0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * moveVerticalSpeed), ForceMode2D.Impulse);
        }

    }
}
