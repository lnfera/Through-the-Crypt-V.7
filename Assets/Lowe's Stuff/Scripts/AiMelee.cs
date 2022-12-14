using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMelee : AiFollow
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //G�r s� att AI letar efter n�got med tagen Player
    }

    // Update is called once per frame
    void Update()
    {
        InAttackRange = Physics.CheckSphere(transform.position, AttackRange, LayerPlayer);
        InSightRange = Physics.CheckSphere(transform.position, SightRange, LayerPlayer);

        if (InSightRange && !InAttackRange) ChasePlayer();
        if (InSightRange && InAttackRange) MeleeAttack();
    }
}

