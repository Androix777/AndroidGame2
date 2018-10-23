using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorControl : MonoBehaviour {
    public GameObject sector;
	// Use this for initialization
	void Start () {
        Instantiate(sector, gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
