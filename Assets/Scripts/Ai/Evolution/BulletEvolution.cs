using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEvolution : MonoBehaviour {

    protected string ID;
    protected int damage;
    protected float speed = 1;
    protected Vector3 moveVector;
    
    // Use this for initialization
    void Start()
    {
        
        //gameObject.GetComponent<Rigidbody2D>().AddForce(speed * moveVector);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.TransformPoint(moveVector) * Time.deltaTime * speed);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "wall")
        {
            Destroy(gameObject, 0);
        }
        if ( collision.transform.GetComponent<EvolutionMob>() != null)
        {
            if (collision.gameObject.GetComponent<EvolutionMob>().ID != ID)
            {
                collision.gameObject.GetComponent<EvolutionMob>().GetDamage(damage);
                Destroy(gameObject, 0);
            }
        }
        if (collision.transform.GetComponent<ParentPart>() != null )
        {
            if (collision.gameObject.GetComponent<ParentPart>().ID != ID)
            {
                collision.gameObject.GetComponent<ParentPart>().GetDamage(damage);
                Destroy(gameObject, 0);
            }
            

        }

    }

    public void CreateBullet(string ID, int damage, Vector3 moveVector)
    {
        this.ID = ID;
        this.damage = damage;
        this.moveVector = moveVector;
       
    }
    
}
