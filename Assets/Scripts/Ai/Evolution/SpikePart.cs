using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePart : ParentPart
{
    int reload;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (reload > 0)
        {
            reload--;
        }
	}

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != transform.tag && collision.transform.tag != transform.tag + "b" && collision.transform.tag != transform.tag + "part" )
        {
            if (collision.transform.tag[collision.transform.tag.Length-1] == 't')
            {
                collision.gameObject.GetComponent<ParentPart>().GetDamage(damage);
                reload = 3000 / speedDamage;
            }
            else
            {if (collision.transform.tag[collision.transform.tag.Length - 1] != 'b')
                {
                    if (reload <= 0)
                    {
                        collision.gameObject.GetComponent<EvolutionMob>().GetDamage(damage);
                        reload = 3000 / speedDamage;
                    }
                }             
            }
        }
    }
}
