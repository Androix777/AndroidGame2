using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerWalker : Сreature
{

    public float rangeRay;

    public bool sideMob = true;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }
        if (target != null && !SeeTarget() && EnterGround())
        {
            if (!SeeBreakage(sideMob))
            {
                sideMob = !sideMob;
                speed *= -1;
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }


    public bool SeeTarget()
    {

        if (Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision))
        {
           
            if (Physics2D.Raycast(transform.position, target.transform.position - transform.position, rangeVision).transform.tag == "Ground")
            {
                return false;
            }
            return true;
        }
        else return false;
    }

    public bool SeeBreakage(bool side)
    {
        Vector3 sides;
        if (side) sides = Vector3.right * rangeRay;
        else sides = Vector3.left * rangeRay;

        if (Physics2D.Raycast(transform.position + sides + Vector3.down * rangeRay, Vector3.up * rangeRay, rangeRay))
        {
            if (!Physics2D.Raycast(transform.position, sides, rangeRay) || (Physics2D.Raycast(transform.position, sides, rangeRay) && Physics2D.Raycast(transform.position, sides, rangeRay).transform.tag != "Ground"))
            {
                if (Physics2D.Raycast(transform.position + sides + Vector3.down * rangeRay, Vector3.up * rangeRay, rangeRay).transform.tag == "Ground")
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;

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