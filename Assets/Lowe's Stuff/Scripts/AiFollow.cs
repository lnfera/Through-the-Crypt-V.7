using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public float speed;
    public float attackrange;
    private Transform target;
    //public LayerMask mask;
    bool shouldMove = false;

    public LayerMask PlayerMask;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Gör så att AI letar efter något med tagen Player
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, attackrange, PlayerMask);//gör så att när en spelare gå innanför en cirkel så aktiveras AI:n

        foreach (Collider collider in hit)
        {
            if (collider != null)
            {
                shouldMove = true;
            }
            if (shouldMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // gör så att AI:n rör sig mot spelaren
            }
        }
 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }
}

