using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public bool ally { private get; set; }
	public float damage { private get; set; }
    public float speed { private get; set; }
    public Vector3 moveVector { private get; set; }
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed * moveVector);
    }
	
	// Update is called once per frame
	void Update () {
		
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


}
