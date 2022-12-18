using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] EndRooms;
    public GameObject[] furniture;
    public List<GameObject> rooms = new List<GameObject>();

    public float WaitTime;
    private bool BossSpawned = false;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime <= 0 && BossSpawned == false)
        {
            for (int i = 0; i <= rooms.Count; i++)
            {

                if (i == rooms.Count - 1)
                {
                    Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
                    Debug.Log(BossSpawned);
                    BossSpawned = true;
                }

            }
        }
        else
        {
            WaitTime -= Time.deltaTime; 
        }

    }
}