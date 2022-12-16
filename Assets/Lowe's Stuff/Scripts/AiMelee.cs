using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMelee : AiFollow
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Gör så att AI letar efter något med tagen Player
    }

    // Update is called once per frame
    void Update()
    {
        InAttackRange = Physics.CheckSphere(transform.position, AttackRange, LayerPlayer);
        InSightRange = Physics.CheckSphere(transform.position, SightRange, LayerPlayer);
        InFleeRange = Physics.CheckSphere(transform.position, FleeRange, LayerPlayer);

        if (InSightRange && !InAttackRange && !InFleeRange) ChasePlayer();
        if (InSightRange && InAttackRange && !InFleeRange) MeleeAttack();
        if (InSightRange && InAttackRange && InFleeRange) FleePlayer();
    }
}

