using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int NumberRoom;
    public GameObject roomPrefab;
    public GameObject loadScreen;

    GameObject room;

	// Use this for initialization
	void Start () {
        //teleportationNextRoom();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void teleportationNextRoom()
    {
        GameObject.FindGameObjectWithTag("Hero").transform.position = new Vector3(0,-18,0);
        generationNextRoom();
    }


    public void generationNextRoom()
    {
        if (room != null)
        {
            Destroy(room, 0);
        }
       

       room=Instantiate(roomPrefab,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
       room.SetActive(true);
    }




}
