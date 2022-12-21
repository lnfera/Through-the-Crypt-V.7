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
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //S�tter targerten till objekten med tagen spelare
        anim = GetComponent<Animation>(); //s�tter anim som komponenten Aninmator
    }


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Spawnar en potion n�r fienden d�r
            Instantiate(potion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void ChasePlayer()
    {   //N�r spelaren blir spotted av en fiende s� kommer fienden g� mot targets position
        Debug.Log("SpottedPlayer");
        SpottedPlayer = true; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime); 
    }

    public void MeleeAttack()
    {
        StartCoroutine(MeleeAttacking()); //Startar coroutinen MeleeAttacking
    }

    public void RangedAttack()
    {
        Debug.Log("Attacking"); //B�rjan p� en Ranged attack (Hade gjort klart den ifall jag inte hade beh�vt g�ra om hela Ai scriptet
    }

    public void FleePlayer()
    {   //G�r s� n�r spelaren �r n�ra nog s� kommer fiende att g� emot motsatta h�llet
        transform.position = Vector3.MoveTowards(transform.position, -target.position, Speed * Time.deltaTime);
        Debug.Log("Flee");
    }

    private void OnDrawGizmosSelected()
    {   //Ritar upp spheres med radien av t.ex attackrange s� att det blir enklare att se hur l�ngt fienden kan t.ex se dig
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
        anim.Play(); // Spelar en attacj animation
        yield return new WaitForSeconds(AttackCooldown); //V�ntar en viss tid s� fienden inte kan attackera varje sekund
        Debug.Log("Attacked");
    }
}


