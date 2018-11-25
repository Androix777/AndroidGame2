using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPart : ParentPart
{
    
    public GameObject bullet;
    public int reload;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (reload > 0)
        {
            reload--;
        }
        Fire();
	}

    public void Fire()
    {
        if (reload <= 0)
        {
            GameObject bull = Instantiate(bullet, transform.position, transform.rotation);
            bull.transform.SetParent(GameObject.FindGameObjectWithTag("Room").transform);
            Destroy(bull, 5);
            Vector2 moveVector = target.transform.position - transform.position; 
            bullet.GetComponent<BulletEvolution>().CreateBullet(ID, damage, moveVector);
            bull.SetActive(true);

            reload = 3000 / speedDamage;
        }

    }
}
