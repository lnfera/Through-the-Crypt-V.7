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
    public GameObject potion;

    public float AttackRange;
    public float SightRange;
    public float FleeRange;
    public float Speed;

    public bool InAttackRange;
    public bool InSightRange;
    public bool InFleeRange;
    public bool SpottedPlayer;

    public int health;
    public int damage;

    public AnimationClip AttackingAnimation;
    Animation anim;


    // Start is called before the first frame update

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animation>();
    }


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Spawns a potion then destroys the enemy
            Instantiate(potion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
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
        anim.clip = AttackingAnimation;
        anim.Play();
        yield return new WaitForSeconds(AttackCooldown);
        Debug.Log("Attacked");
    }
}


