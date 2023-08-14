using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public float maxHealth;
    public float health;
    public float shootingDelay = 0.2f;
    public bool shootingDelayed;
    public float enemyDamage = 20f;

    public GameObject projectile;
    public Transform playerShip;
    //public AudioSource gunAudio;

    public ScreenBounds screenBounds;
    [SerializeField] private HealthBarUI healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        //get input and move
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        Vector3 velocity = speed * input;
        Vector3 tempPosition = transform.localPosition + velocity * Time.deltaTime;
        if (screenBounds.AmIOutOfBounds(tempPosition))
        {
            Vector2 newPosition = screenBounds.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }

        //shooting
        if (Input.GetKey(KeyCode.Space))
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;
                //gunAudio.Play();
                Vector3 playerPosition = transform.position;
                playerPosition.y += 1;

                GameObject p = Instantiate(projectile, playerPosition, Quaternion.identity);

                StartCoroutine(DelayShooting());
            }
        }

    }

    private IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(shootingDelay);
        shootingDelayed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Heal(Clone)")
        {
            if (health < 100)
            {
                setHealth(enemyDamage);
            }
        }
        else
        {
            setHealth(-enemyDamage);
        }
        
    }

    public void setHealth(float healthChange)
    {
        health += healthChange;
        health = Math.Clamp(health, 0f, maxHealth);

        healthBar.setHealth(health);
    }

    


}
