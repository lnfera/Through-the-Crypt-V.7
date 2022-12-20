using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomSpawner : MonoBehaviour
{
    public int openingdirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int rand;
    public bool SpawnerInWay = false;
    public bool RoomInWay = false;
    public float waitTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = FindObjectOfType<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
        Debug.Log("Spawned");
    }


    void Spawn()
    {
        if (SpawnerInWay == false && RoomInWay == false) //Ifall det finns en Spawner eller ett rum ivägen 
        {
            if (openingdirection == 1) //Ifall openingdir är 1 så ska ett rum från bottomRooms listan spawna vid spawnpointen
            {
                var rand = Random.Range(0, templates.bottomRooms.Length);
                Debug.Log("Chosen Room");
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingdirection == 2) //Om rummet inte har openingdir 1 och har istället openingdir 2, tar den ett rum från toproom istället
            {
                var rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingdirection == 3) //Om rummet inte har openingdir 2 och har istället openingdir 3, tar den ett rum från leftroom istället
            {
                var rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingdirection == 4) //Om rummet inte har openingdir 3 och har istället openingdir 4, tar den ett rum från rightroom istället
            {
                var rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Room") //Ifall Spawnern träffar ett rum så förstörs gameobjekten så inga fler rum kan spawnas på den punkten
        {
            RoomInWay = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("SpawnPoint")) //Ifall spawnern träffar en annan spawner så startas coroutinen EndSpawn
        {
            SpawnerInWay = true;
            StartCoroutine(EndSpawn());
        } 
    
    }

    IEnumerator EndSpawn() //När två spawners colliderar så väntar den 0.1 sekund så dom inte tar bort varandra på direkten, 
                           //Den stänger sedan av collidern så scriptet inte repeteras efterdet så spawnar den en EndRoom och till sist så förstörs spawnern 
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(templates.EndRooms[0], transform.position, templates.EndRooms[0].transform.rotation);
        Destroy(gameObject);
    }
}
