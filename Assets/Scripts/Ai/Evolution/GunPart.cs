using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPart : ParentPart
{
    public GameObject ball;
    public GameObject bullet;
    public int reload;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("bullet");
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            if (reload > 0)
            {
                reload--;
            }
            Fire();
        }
		
	}

    public void Fire()
    {
        if (reload <= 0)
        { if (bullet != null)
            {
                GameObject boll = Instantiate(bullet, transform.position, transform.rotation, transform) as GameObject;
                boll.transform.SetParent(GameObject.FindGameObjectWithTag("Room").transform);
                boll.transform.rotation = new Quaternion(0,0,0,0);
                Vector3 moveVector = target.transform.position - transform.position;
                boll.GetComponent<BulletEvolution>().CreateBullet(ID, damage, moveVector);
                boll.SetActive(true);
                Destroy(boll, 5);
                if (speedDamage != 0)
                {
                    reload = 500 / speedDamage;
                }
                else reload = 500;
               // Debug.Log("Fire");
            }
            
        }

    }
}
