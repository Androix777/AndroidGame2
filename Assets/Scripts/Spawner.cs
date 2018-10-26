using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] pullMobs;
    public int sumMobs;

	// Use this for initialization
	void Start () {
        for ( int i = 0; i < sumMobs ; i++ )
        {
            GameObject mobs = Instantiate(pullMobs[Random.Range(0, pullMobs.Length)], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
