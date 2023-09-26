using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("KeyCode Parameters")]
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode jumpKey = KeyCode.W;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    [Header("Object References")]
    [SerializeField] private MouvementRigidbody joueur;
    [SerializeField] private FiringBehaviour firingBehaviour;

    // Update is called once per frame
    void Update()
    {
        InputJump();
        InputMove();
        InputProjectile();
    }

    public void InputJump()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            //Jump!
            joueur.Jump();
        }
    }

    public void InputMove()
    {
        if (Input.GetKey(leftKey))
        {
            //Deplace gauche
            joueur.Mouvement(-1);
        }
        else if (Input.GetKey(rightKey))
        {
            //Deplace Droite
            joueur.Mouvement(1);
        }

    }

    public void InputProjectile()
    {
        if(Input.GetKeyDown(shootKey))
        {
            //Attack!
            firingBehaviour.FireProjectile();
        }
    }
}
