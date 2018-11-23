using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBoss : Сreature
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void FireAngleType(GameObject typeBullet, float angle, int numberbullet, float rangeAngle)
    {
        for (int i = 0; i < numberbullet; i++)
        {
            GameObject bullet = Instantiate(typeBullet, transform.position, transform.rotation) as GameObject;
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Room").transform);
            Destroy(bullet, 5);
            bullet.transform.rotation = Quaternion.Euler(0, 0, rangeAngle / numberbullet * i + angle);
            bullet.GetComponent<Bullet>().CreateBullet(false, rangedamage * damageMultiplu, 25, (bullet.transform.position - bullet.GetComponent<Bullet>().MoveUp()).normalized);
            if (transform.parent.GetComponent<SpriteRenderer>() != null)
            {
                bullet.GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
            }

            bullet.SetActive(true);

        }
    }
}
