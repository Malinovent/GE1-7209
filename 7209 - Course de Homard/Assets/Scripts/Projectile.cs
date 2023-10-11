using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 3;
    [SerializeField] private float lifetime = 10;
    [SerializeField] private int degats = 5;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vitesse;

        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* 1.
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(degats);
        }*/

        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.TakeDamage(degats);
            Destroy(this.gameObject); 
        }
    }


}
