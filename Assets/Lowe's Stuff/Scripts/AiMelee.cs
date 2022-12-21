using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMelee : AiFollow
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //S�tter targerten till objekten med tagen spelare
    }

    // Update is called once per frame
    void Update()
    {
        InAttackRange = Physics.CheckSphere(transform.position, AttackRange, LayerPlayer); //Ritar upp en sphere med fiendens position i mitt punken och attack range som radien. 
                                                                                           //InattackRange kommer bli sann s� fort ett objekt med tagen player kommer innan f�r spheren
                                                                                           //Detta �r samma f�r dom andra bara att der �r olika ranges och olika bools
        InSightRange = Physics.CheckSphere(transform.position, SightRange, LayerPlayer);
        InFleeRange = Physics.CheckSphere(transform.position, FleeRange, LayerPlayer);

        if (InSightRange && !InAttackRange && !InFleeRange) ChasePlayer(); //Om spelaren �r i SightRange men inte i attackRange och fleeRange s� kommer fienden jaga spelaren 
        if (InSightRange && InAttackRange && !InFleeRange) MeleeAttack(); //Om spelaren �r i sightRange och i attackRange men inte i fleeRange s� kommer fienden attackera spelaren
        if (InSightRange && InAttackRange && InFleeRange) FleePlayer(); //Om spelaren �r i sightRange, attackRange och i fleeRange s� kommer fienden fly fr�n spelaren 
    }
}

