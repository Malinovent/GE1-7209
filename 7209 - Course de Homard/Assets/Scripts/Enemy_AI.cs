using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_AI : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.speed = 3.5f;
        navMeshAgent.height = 1f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            navMeshAgent.speed = 1;
            navMeshAgent.height = 0.5f;
        }
    }
}
