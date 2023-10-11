using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementRigidbody : MonoBehaviour
{
    [SerializeField] private float vitesse = 1;
    [SerializeField] private float forceSaut = 100;
    [SerializeField] private int maxSaut = 2;

    private int nombreSautActuel = 0;

    Rigidbody2D rb2d;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (rb2d.velocity.x < 0)
        {
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb2d.velocity.x > 0)
        {
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Mouvement(int direction)
    {
        rb2d.velocity = new Vector2(vitesse * direction, rb2d.velocity.y);
    }

    public void Jump()
    {
        if (nombreSautActuel++ < maxSaut)
        {
            //Saute
            //nombreSautActuel++;
            rb2d.AddForce(new Vector2(0, forceSaut));
        }  
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.7f)
        {
            nombreSautActuel = 0;
        }
    }

}
