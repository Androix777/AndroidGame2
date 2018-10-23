using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int NumberRoom;
    public GameObject roomPrefab;
    public GameObject loadScreen;

    public int floor = 0;
    GameObject room;

    public GameObject[] roomsMetal;

    public Object[] pullrooms;

    public string  location = "Metal";
	// Use this for initialization
	void Start () {
        //teleportationNextRoom();
        LoadPullRooms();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void teleportationNextRoom()
    {
        generationNextRoom();
        GameObject.FindGameObjectWithTag("Hero").transform.position = GameObject.FindGameObjectWithTag("Room").transform.position;
        floor++;
    }


    public void generationNextRoom()
    {
        if (room != null)
        {
            Destroy(room, 0);
        }
        
        room = Instantiate(pullrooms[Random.Range(0, pullrooms.Length)], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        room.SetActive(true);

        
    }


    public void LoadPullRooms()
    {
        pullrooms = Resources.LoadAll("Rooms/Metal/Easy") ;
    }

}
