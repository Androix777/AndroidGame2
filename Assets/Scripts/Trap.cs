using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public float damage;
	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionStay2D(Collision2D collision)
    {   
        
            if (collision.gameObject.tag == "Hero")
            {
                collision.gameObject.GetComponent<Сreature>().GetDamage(damage);
            }              
    }
    // Update is called once per frame
    void Update () {
		
	}
}
