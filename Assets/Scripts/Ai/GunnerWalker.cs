using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerWalker : Сreature
{
    public  bool seeHero = false;
    public float rangeRay;
    int timerToNoSee = 0;
    public bool sideMob = true;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && EnterGround())
        {


            if (SeeTarget())
            {
                seeHero = true;
                timerToNoSee = 30;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                seeHero = false;
                if (timerToNoSee == 0)
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
                    timerToNoSee -= 1;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                }
            }
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }


    public bool SeeTarget()
    {
        RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, target.transform.position - transform.position, rangeVision);
        
        foreach (RaycastHit2D obj in rays)
        {
            if (obj.transform.tag == "Ground" )
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

    public bool SeeBreakage(bool side)
    {
        Vector3 sides;
        if (side) sides = Vector3.right * rangeRay;
        else sides = Vector3.left * rangeRay;

        if (Physics2D.Raycast(transform.position + sides + Vector3.down * rangeRay, Vector3.up * rangeRay, rangeRay))
        {
            RaycastHit2D onTheSide = Physics2D.Raycast(transform.position + sides * rangeRay, -sides, rangeRay);
            if (onTheSide && (onTheSide.transform.tag == "Hero" || onTheSide.transform.gameObject == gameObject))
            {
                if (Physics2D.Raycast(transform.position + sides * rangeRay + Vector3.down, Vector3.up, rangeRay).transform.tag == "Ground")
                {
                    return true;
                }
            }
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