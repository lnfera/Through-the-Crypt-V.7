using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMelee : AiFollow
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Sätter targerten till objekten med tagen spelare
    }

    // Update is called once per frame
    void Update()
    {
        InAttackRange = Physics.CheckSphere(transform.position, AttackRange, LayerPlayer); //Ritar upp en sphere med fiendens position i mitt punken och attack range som radien. 
                                                                                           //InattackRange kommer bli sann så fort ett objekt med tagen player kommer innan för spheren
                                                                                           //Detta är samma för dom andra bara att der är olika ranges och olika bools
        InSightRange = Physics.CheckSphere(transform.position, SightRange, LayerPlayer);
        InFleeRange = Physics.CheckSphere(transform.position, FleeRange, LayerPlayer);

        if (InSightRange && !InAttackRange && !InFleeRange) ChasePlayer(); //Om spelaren är i SightRange men inte i attackRange och fleeRange så kommer fienden jaga spelaren 
        if (InSightRange && InAttackRange && !InFleeRange) MeleeAttack(); //Om spelaren är i sightRange och i attackRange men inte i fleeRange så kommer fienden attackera spelaren
        if (InSightRange && InAttackRange && InFleeRange) FleePlayer(); //Om spelaren är i sightRange, attackRange och i fleeRange så kommer fienden fly från spelaren 
    }
}

