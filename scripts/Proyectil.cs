using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] public float damage;  
    [SerializeField] public float speed;   
    [HideInInspector] public Vector3 direction;  

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (direction != Vector3.zero && rb != null)
        {
            rb.velocity = direction * speed;
        }

        if (transform.position.x >= 12 || transform.position.x <= -12 || transform.position.y >= 8 || transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthEnemy enemyHealth = collision.gameObject.GetComponent<HealthEnemy>();
            if (enemyHealth != null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                AtributosJugador playerAttributes = player.GetComponent<AtributosJugador>();

                enemyHealth.currentHealth -= damage * playerAttributes.strength;
            }
            Destroy(gameObject); 
        }
    }
}
