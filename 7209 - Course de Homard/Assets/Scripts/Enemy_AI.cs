using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField]
    private EnemyState etatActuel = EnemyState.IDLE;

    [SerializeField] Transform joueur;

    [SerializeField] float chaseRayon;
    [SerializeField] float chaseVitesse;

    [SerializeField] float attackRayon;
    [SerializeField] float attackVitesse;

    [SerializeField] float patrolRayon;
    [SerializeField] float patrolVitesse;

    private Vector2 pointDepart;

    private void Awake()
    {
        pointDepart = this.transform.position;
    }

    void Update()
    {
        switch(etatActuel)
        {
            case EnemyState.IDLE:
                Idle();
                break;

            case EnemyState.PATROL:
                Patrol();
                break;

            case EnemyState.CHASE:
                Chase();
                break;

            case EnemyState.ATTACK:
                Attack();
                break;
        }
    }

    private void TransitionTo(EnemyState newState)
    {
        etatActuel = newState;

        switch (etatActuel)
        {
            case EnemyState.IDLE:
                //Animator.Play("IDLE")
                break;

            case EnemyState.PATROL:
                //Animator.Play("PATROL")
                Debug.Log("Patrol Animation!");
                break;

            case EnemyState.CHASE:
                //Animator.Play("CHASE")
                Debug.Log("Patrol Chase!");
                break;

            case EnemyState.ATTACK:
                //Animator.Play("ATTACK")
                break;
        }
    }

    #region ETATS

    private void Idle()
    {
        //ACTION


        //TRANSITION(S)
        float dist = Vector2.Distance(this.transform.position, joueur.transform.position);
        if(dist < chaseRayon)
        {
            //etatActuel = EnemyState.CHASE;
            TransitionTo(EnemyState.CHASE);
        }

    }

    private void Patrol()
    {
        //ACTION
        this.transform.position = Vector2.MoveTowards(
            this.transform.position, pointDepart, patrolVitesse * Time.deltaTime);

        //TRANSITION(S)
        float distPatrol = Vector2.Distance(this.transform.position, pointDepart);
        if (distPatrol < 0.1f)
        {
            TransitionTo(EnemyState.IDLE);
        }

        float distChase = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (distChase < chaseRayon)
        {
            //etatActuel = EnemyState.CHASE;
            TransitionTo(EnemyState.CHASE);
        }
    }

    private void Chase()
    {
        //ACTION
        this.transform.position = Vector2.MoveTowards(
            this.transform.position, joueur.transform.position, chaseVitesse * Time.deltaTime);

        //TRANSITION(S)
        float dist = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (dist < attackRayon)
        {
            TransitionTo(EnemyState.ATTACK);
        }

        if (dist > patrolRayon)
        {
            TransitionTo(EnemyState.PATROL);
        }
    }

    private void Attack()
    {
        //ACTION
        this.transform.position = Vector2.MoveTowards(
            this.transform.position, joueur.transform.position, attackVitesse * Time.deltaTime);

        //TRANSITION(S)
        float dist = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (dist > attackRayon)
        {
            TransitionTo(EnemyState.CHASE);
        }
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, patrolRayon);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chaseRayon);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRayon);
    }
}

public enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}