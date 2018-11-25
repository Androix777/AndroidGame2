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

    private void OnCollisionStay2D(Collision2D collision)
    {       
        if (collision.transform.GetComponent<EvolutionMob>() != null)
        {
            if (collision.gameObject.GetComponent<EvolutionMob>().ID != ID)
            {
                if (reload <= 0)
                {
                    collision.gameObject.GetComponent<EvolutionMob>().GetDamage(damage);
                    if (speedDamage != 0)
                    {
                        reload = 500 / speedDamage;
                    }
                    else reload = 500;
                }
            }
        }
        if (collision.transform.GetComponent<ParentPart>() != null)
        {
            if (collision.gameObject.GetComponent<ParentPart>().ID != ID)
            {
                if (reload <= 0)
                {
                    collision.gameObject.GetComponent<ParentPart>().GetDamage(damage);

                    if (speedDamage != 0)
                    {
                        reload = 500 / speedDamage;
                    }
                    else reload = 500;
                }
            }


        }
        
    }
}
