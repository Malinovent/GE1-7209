using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFirePoint;

    public void FireProjectile()
    {
        Debug.Log("Firing Projectile! " + gameObject.name);
        Vector3 gaucheDirection = new Vector3(0, 0, 0);

        if(transform.localScale.x == -1)
        {
            gaucheDirection = new Vector3(0, 0, 180);
        }


        Quaternion gaucheQuaternion = Quaternion.Euler(gaucheDirection);
        Instantiate(projectilePrefab, projectileFirePoint.position, gaucheQuaternion);
    }
}
