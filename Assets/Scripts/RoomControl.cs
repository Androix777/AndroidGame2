using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {
    GameObject[] effectsRoom;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateRoom(int difficult)
    {
        bool cheak = false;
              
        for (int i = 0; i < difficult; i++)
        {
            foreach (GameObject g in effectsRoom)
            {
                if (!g.activeSelf)
                {
                    cheak = true;
                }
            }
            if (cheak)
            {
                cheak = false;

                int rand = Random.Range(0, effectsRoom.Length);

                while (true)
                {
                    if (effectsRoom[rand].activeSelf)
                    {
                        rand = Random.Range(0, effectsRoom.Length);
                    }
                    else
                    {
                        effectsRoom[rand].SetActive(true);
                        break;
                    }
                }
            }
        }
    }


}
