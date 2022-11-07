using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage;


    // Start is called before the first frame update
    void Start()
    {

    }
    /*public void DoDamage(EnemyController enemy)
    {
        //enemy.health -= damage;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            EnemyController controller = collision.gameObject.GetComponent<EnemyController>();
            if (controller)
            {
                DoDamage(controller);
            }
        }
    }*/
}
