using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerFly : Сreature
{

    public Vector3 move;

    int timerRandom;
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

        if (target != null )
        {


            if (timerRandom <= 0)
            {
                move = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu / 2;
                timerRandom = 30;
            }
            if (timerRandom > 0) { timerRandom -= 1; }


        }
        gameObject.GetComponent<Rigidbody2D>().velocity = move;
    }
    


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hero")
        {
            collision.gameObject.GetComponent<Hero>().GetDamage(damage);
            Vector2 imp = (collision.transform.position - transform.position).normalized * 5;
            imp.y /= 5;
            collision.gameObject.GetComponent<Hero>().Push(imp);
        }
    }
}
