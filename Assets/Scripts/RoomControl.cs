using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {
    GameObject[] sectorRoom;
    int numberSector = 0;
    int childCount;
    // Use this for initialization
    void Start () {
        childCount = gameObject.transform.childCount;
        sectorRoom = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {

            sectorRoom[i] = gameObject.transform.GetChild(i).gameObject;
        }

        GenerateNextSector();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNextSector()
    {
        if (numberSector < childCount)
        {
            sectorRoom[numberSector].SetActive(true);
            numberSector++;
        }
    }

}
