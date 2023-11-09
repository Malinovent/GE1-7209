using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 3;
    [SerializeField] private float lifetime = 10;
    [SerializeField] private int degats = 5;
    [SerializeField] private ParticleSystem particule;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vitesse;

        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.TakeDamage(degats);
            AudioManager.Singleton.PlaySons("fireball");

            //Creer Particule
            ParticleSystem particuleGO = Instantiate(particule);
            particuleGO.transform.position = this.transform.position;

            CameraEffects.Singleton.ShakeCamera(0.5f, 1);
            CameraEffects.Singleton.SetCible(collision.transform);

            //Detruire l'effet apres 2 secondes
            Destroy(particuleGO.gameObject, 2);

            Destroy(this.gameObject); 
        }
    }


}
