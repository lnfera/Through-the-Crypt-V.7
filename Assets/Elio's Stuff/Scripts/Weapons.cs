using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage;
    public Vector3 kbDirection;


    // Start is called before the first frame update
    void Start()
    {

    }
    public void DoDamage(AiFollow enemy)
    {
        //Deals damage to enemy based on the damage variable, then knocks back enemy that you hit
        enemy.health -= damage;
        kbDirection = enemy.rb.transform.position - gameObject.transform.position;
        enemy.rb.AddForce(kbDirection.normalized * -200f);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //If your weapon collides with an enemy then "controller" will take the AiFollow script on the enemy and start the DoDamage method
        if (collision.collider.tag == "Enemy")
        {
            AiFollow controller = collision.gameObject.GetComponent<AiFollow>();
            if (controller)
            {
                DoDamage(controller);
            }
        }
    }
}
