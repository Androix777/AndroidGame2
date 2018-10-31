using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJump : Сreature {

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
    }
	
	// Update is called once per frame
	void Update () {
		if (SeeTarget())
        {
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }
	}

    public bool SeeTarget()
    {
        RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, Vector3.down, rangeVision);

        foreach (RaycastHit2D obj in rays)
        {
            if (obj.transform.tag == "Ground")
            {
                return false;
            }
            else
            {
                if (obj.transform.tag == "Hero")
                {
                    return true;
                }
            }
        }
        return false;
    }

}
