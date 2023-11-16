using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFirePoint;
    [SerializeField] private int initialPoolSize = 5;

    private Queue<GameObject> poolProjectile = new Queue<GameObject>();

    private GameObject parentProjectile;

    private void Awake()
    {
        parentProjectile = new GameObject();
        parentProjectile.name = "Projectiles Pool";

        AddProjectilesToList(initialPoolSize);
    }

    private void AddProjectilesToList(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.parent = parentProjectile.transform;
            poolProjectile.Enqueue(projectile);
            projectile.SetActive(false);

            projectile.GetComponent<Projectile>().SetPoolReference(poolProjectile);
        }
    }

    public void FireProjectile()
    {
        Debug.Log("Firing Projectile! " + gameObject.name);
        Vector3 gaucheDirection = new Vector3(0, 0, 0);

        if(transform.localScale.x == -1)
        {
            gaucheDirection = new Vector3(0, 0, 180);
        }

        Quaternion gaucheQuaternion = Quaternion.Euler(gaucheDirection);

        if(poolProjectile.Count <= 0)
        {
            AddProjectilesToList(5);
        }

        GameObject projectile = poolProjectile.Dequeue();
        projectile.SetActive(true);
        projectile.transform.position = projectileFirePoint.position;
        projectile.transform.rotation = gaucheQuaternion;

    }
}
