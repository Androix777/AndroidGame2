using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : Сreature {



    public float pushForce;
    public float rangeRay;
    int timerToNoSee = 0;
    public bool sideMob = true;

    public bool seeHero;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
    }
	
	// Update is called once per frame
	void Update () {
		






	}

    public bool SeePit()
    { 

        RaycastHit2D onTheSide = Physics2D.Raycast(transform.TransformPoint( Vector3.down), transform.TransformPoint( Vector3.up) - transform.position, rangeRay);
            if (onTheSide && (onTheSide.transform.tag == "Ground" ))
            {
             return false;
            }
        return true;

    }

    public bool SeeWall()
    {
        Vector3 sides;
        sides = Vector3.right * rangeRay;


        RaycastHit2D onTheSide = Physics2D.Raycast(transform.TransformPoint(Vector3.right), transform.TransformPoint(Vector3.right) - transform.position, rangeRay);
        if (onTheSide && (onTheSide.transform.tag == "Ground"))
        {
            return true;
        }
        return false;

    }


    public bool EnterGround()
    {
        if (Physics2D.Raycast(transform.position + Vector3.down * rangeRay, Vector3.up * rangeRay, rangeRay) && Physics2D.Raycast(transform.position + Vector3.down * rangeRay, Vector3.up * rangeRay, rangeRay).transform.tag == "Ground")
        {
            return true;
        }
        return false;
    }
}
