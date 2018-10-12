using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerFly : MonoBehaviour {
    public float rangeVision;

    public int hp;
    public int hpMultiplu;

    GameObject target;
    public float speed;
    public float speedMultiplu;

    public float damage;
    public float damageMultiplu;

    public Vector3 Move;
    public Vector3 MoveRandom;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }

        if (target != null && SeeTarget())
        {
            //Debug.Log("I see you");
            MoveRandom = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu / 2;
            
        }
        
    }
    public bool SeeTarget()
    {
        
        if (Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision) && Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision).transform.tag == "Ground")
        {
            return false;
        }
        else return true;
    }
}
