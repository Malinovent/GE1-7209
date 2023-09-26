using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles -= new Vector3(0, 0, rotationSpeed);
        }
    }
}
