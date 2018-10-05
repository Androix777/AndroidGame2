using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerWalker : MonoBehaviour
{
    GameObject target;
    public float speed;
    public float speedMultiplu;

    public float damage;
    public float damageMultiplu;

    //public string tag;

    public Vector3 Move;
    public bool sideMob = true;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero");
        Move = Vector3.right * speed * speedMultiplu;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !SeeTarget() && EnterGround())
        {
            // Debug.Log("See");
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
        //  Debug.Log(Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag);
        // Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);

        if (Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag == "Ground")
        {
            return false;
        }
        else return true;
    }

    public bool SeeBreakage(bool side)
    {
        Vector3 sides;
        if (side) sides = Vector3.right / 3;
        else sides = Vector3.left / 3;

        if (Physics2D.Raycast(transform.position + sides + Vector3.down, Vector3.zero, 1))
        {
            if (!Physics2D.Raycast(transform.position, sides, 1) || (Physics2D.Raycast(transform.position, sides, 1) && Physics2D.Raycast(transform.position, sides, 1).transform.tag != "Ground"))
            {
                if (Physics2D.Raycast(transform.position + sides + Vector3.down, Vector3.zero, 1).transform.tag == "Ground")
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
        // Debug.Log(Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag);
        // Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);
    }

    public bool EnterGround()
    {
       // Debug.Log();
        if (Physics2D.Raycast(transform.position + Vector3.down, Vector3.zero, 1) && Physics2D.Raycast(transform.position + Vector3.down, Vector3.zero, 1).transform.tag == "Ground")
        {
            return true;
        }
        return false;
    }
}