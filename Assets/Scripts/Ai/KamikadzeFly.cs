using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KamikadzeFly : MonoBehaviour {
    GameObject target;
    public float speed;
    public float speedMultiplu;

    public float damage;
    public float damageMultiplu;

    public string tag;
    // Use this for initialization

    public Vector3 Move;
    public Vector3 MoveRandom;
    void Start () {
        target = GameObject.FindGameObjectWithTag ( "Hero" );
	}
	
	// Update is called once per frame
	void Update () {
		if (target!=null && SeeTarget())
        {
            Move = (target.transform.position - transform.position).normalized * speed * speedMultiplu; 
            gameObject.GetComponent<Rigidbody2D>().AddForce(Move);
        }
        else
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(-Move);
            // Move = -Move;
            MoveRandom = new Vector3(Random.RandomRange(-100, 100), Random.RandomRange(-100, 100)).normalized * speed * speedMultiplu/2;
            gameObject.GetComponent<Rigidbody2D>().AddForce(MoveRandom);

        }

    }

    public bool SeeTarget( )
    {
       // Debug.Log(Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag);
       // Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);

        if (Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag == "Ground")
        {
        return false;
        }
        else return true;
    }
}
