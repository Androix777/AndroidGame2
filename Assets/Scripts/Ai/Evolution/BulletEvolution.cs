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
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed * moveVector);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != transform.tag && collision.transform.tag != transform.tag + "b" && collision.transform.tag != transform.tag + "part")
        {
            if (collision.transform.tag[collision.transform.tag.Length - 1] == 't')
            {
                collision.gameObject.GetComponent<ParentPart>().GetDamage(damage);
                Destroy(gameObject, 0);
            }
            else
            {
                if (collision.transform.tag[collision.transform.tag.Length - 1] != 'b')
                {

                    collision.gameObject.GetComponent<EvolutionMob>().GetDamage(damage);
                    Destroy(gameObject, 0);
                }
            }
        }

    }

    public void CreateBullet(string ID, int damage, Vector3 moveVector)
    {
        this.ID = ID;
        this.damage = damage;
        this.moveVector = moveVector;
        transform.tag = ID + "b";
    }
    
}
