using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamRevision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Vie vie = collision.gameObject.GetComponent<Vie>();
        vie.TakeDamage(5);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Vie vie = collision.GetComponent<Vie>();
        vie.TakeDamage(5);
    }
}
