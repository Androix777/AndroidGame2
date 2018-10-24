using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Сreature
{

    public float pushForce;
    public float rangeRay;

    public bool sideMob = true;

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

        if (target != null && EnterGround())
        {

            if (!SeeBreakage(sideMob))
            {

                sideMob = !sideMob;
                speed *= -1;
            }
            if (SeeTarget(sideMob))
            {
                Debug.Log("See");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                 Debug.Log("!See");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu / 2, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }           
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

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

    public bool SeeTarget(bool side)
    {
        int sideint = 1;
        if (side)
        {
            sideint = 1;
        }else
        {
            sideint = -1;
        }

        for (int i = 1; i < rangeVision; i++)
        {
            RaycastHit2D hitGround = Physics2D.Raycast(new Vector3(transform.position.x + i * sideint, transform.position.y - 1, transform.position.z), Vector3.up, 1);
            if (hitGround && hitGround.transform.tag == "Ground" )
            {
                RaycastHit2D hitHero = Physics2D.Raycast(transform.position, Vector3.right * sideint, i);
                if ( hitHero && hitHero.transform.tag == "Hero")
                {
                    return true;
                }
            }
            else
            {
                break;
            }
        }
        return false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hero")
        {
            collision.gameObject.GetComponent<Hero>().GetDamage(damage);
            Vector2 imp= (collision.transform.position - transform.position).normalized * pushForce;
            imp.y /= pushForce;
            collision.gameObject.GetComponent<Hero>().Push(imp);
        }
    }

}
