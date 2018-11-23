using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGravity : Bullet {
    


    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed * moveVector,ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
