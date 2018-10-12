﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KamikadzeFly : MonoBehaviour {
    public float pushForce;
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

    void Start () {
        target = GameObject.FindGameObjectWithTag ( "Hero" );
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }

        if (target!=null && SeeTarget())
        {
            Debug.Log("See Hero");
            Move = (target.transform.position - transform.position).normalized * speed * speedMultiplu; 

        }
        else
        {

            Move = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu/2;

        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(Move);
    }

    public bool SeeTarget( )
    {

        if (Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision) )
        {
            if (Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision).transform.tag == "Ground")
            {
                return false;
            }
            return true;
        }
        else return false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hero")
        {
            collision.gameObject.GetComponent<Hero>().GetDamage(damage);
            Vector2 imp = (collision.transform.position - transform.position).normalized * pushForce;
            collision.gameObject.GetComponent<Hero>().Push(imp);
        }
    }
}
