using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Сreature
{

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
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }

        if (target != null && EnterGround())
        {

            
            if (SeeTarget(sideMob))
            {
                timerToNoSee = 30;
                seeHero = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {   if (timerToNoSee == 0)
                {
                    seeHero = false;
                    if (!SeeBreakage(sideMob))
                    {

                        sideMob = !sideMob;
                        speed *= -1;
                    }
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * speedMultiplu / 2, gameObject.GetComponent<Rigidbody2D>().velocity.y);
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
            RaycastHit2D[] hitHero = Physics2D.RaycastAll(transform.position, Vector3.right * sideint, i);

            foreach (RaycastHit2D hitray in hitHero)
            {
                //Debug.Log(hitray.transform.tag);
                if ((hitray.transform.tag != "Hero" && hitray != gameObject) || hitray.transform.tag == "Ground")
                {
                    return false;
                }
                else
                {
                    if (hitray.transform.tag == "Hero")
                    {
                        RaycastHit2D hitGround = Physics2D.Raycast(new Vector3(hitray.transform.position.x + i * sideint, hitray.transform.position.y - 1, hitray.transform.position.z), Vector3.up, 1);
                        if (!hitGround || hitGround.transform.tag != "Ground")
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }

           /* RaycastHit2D hitHero = Physics2D.Raycast(new Vector3(transform.position.x + i * sideint, transform.position.y , transform.position.z), Vector3.right * -sideint, i);
            if (hitHero )
            {
                Debug.Log(hitHero.transform.tag);
                if (hitHero.transform.tag != "Hero")
                {
                   if (hitHero != gameObject)
                    {
                        return false ;
                    }
                }
                else
                {
                    RaycastHit2D hitGround = Physics2D.Raycast(new Vector3(transform.position.x + i * sideint, transform.position.y - 1, transform.position.z), Vector3.up, 1);
                    if (hitGround && hitGround.transform.tag == "Ground")
                    {
                        return true;
                    }
                }
                
            }
            else
            {
                RaycastHit2D hitGround = Physics2D.Raycast(new Vector3(hitHero.transform.position.x + i * sideint, hitHero.transform.position.y-1, hitHero.transform.position.z), Vector3.up , 1);
                if (!hitGround || hitGround.transform.tag != "Ground")
                {
                    break;
                }               
            }*/
        }
        return false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hero")
        {
            collision.gameObject.GetComponent<Hero>().GetDamage(meleeDamage);
            Vector2 imp= (collision.transform.position - transform.position).normalized * pushForce;
            imp.y /= pushForce;
            collision.gameObject.GetComponent<Hero>().Push(imp);
        }
    }

}
