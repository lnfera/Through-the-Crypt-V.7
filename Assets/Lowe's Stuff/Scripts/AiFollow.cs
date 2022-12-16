using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public float lookraduis = 10f;
    public Transform target;
    public LayerMask LayerGround;
    public LayerMask LayerPlayer;
    public float AttackCooldown;
    public Rigidbody rb;

    public float AttackRange;
    public float SightRange;
    public float FleeRange;
    public float Speed;

    public bool InAttackRange;
    public bool InSightRange;
    public bool InFleeRange;
    public bool SpottedPlayer;

    public Animation AttackingAnimation;


    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ChasePlayer()
    {
        Debug.Log("SpottedPlayer");
        SpottedPlayer = true;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    public void MeleeAttack()
    {
        StartCoroutine(MeleeAttacking());
    }

    public void RangedAttack()
    {
        Debug.Log("Attacking");
    }

    public void FleePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, -target.position, Speed * Time.deltaTime);
        Debug.Log("Flee");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FleeRange);
    }

    IEnumerator MeleeAttacking()
    {
        //AttackingAnimation.Play();
        yield return new WaitForSeconds(AttackCooldown);
        Debug.Log("Attacked");
    }
}


