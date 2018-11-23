using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

     protected bool ally;
     protected float damage;
     protected float speed;
     protected Vector3 moveVector;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed * moveVector);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 MoveUp()
    {

        return transform.TransformPoint(Vector3.up);
    }


    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (ally)
		{
			if (collision.tag=="Enemy" )
			{
                collision.gameObject.GetComponent<Сreature>().GetDamage(damage);
                Destroy(gameObject,0);
			}
            else
            {
                if (collision.tag == "Ground")
                {
                    Destroy(gameObject, 0);
                }
            }
        }
		else
		{
			if (collision.tag=="Hero" )
			{
                collision.gameObject.GetComponent<Hero>().GetDamage(damage);
				Destroy(gameObject,0);
			}else
            {
                if (collision.tag == "Ground")
                {
                    Destroy(gameObject, 0);
                }
            }
		}
	}

    public void CreateBullet(bool newally,float newdamage,float newspeed,Vector3 newmoveVector)
    {
         ally = newally;
         damage = newdamage;
         speed = newspeed;
         moveVector = newmoveVector;
    }

}
