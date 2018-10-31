using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KamikadzeFly : Сreature
{
    public float pushForce;
    public Vector3 move;
    public Vector3 moveRandom;

    int timerRandom;

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
            
            move = (target.transform.position - transform.position).normalized * speed * speedMultiplu; 

        }
        else
        {
            if (timerRandom<=0)
            {
                move = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu / 5;
                timerRandom = 30;
            }
            if (timerRandom > 0) { timerRandom -= 1; }

        }
        gameObject.GetComponent<Rigidbody2D>().velocity = move;
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
            collision.gameObject.GetComponent<Hero>().GetDamage(meleeDamage);
            Vector2 imp = (collision.transform.position - transform.position).normalized * pushForce;
            imp.y /= pushForce;
            collision.gameObject.GetComponent<Hero>().Push(imp);
        }
    }
}
