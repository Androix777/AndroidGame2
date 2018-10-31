using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTeleport : Сreature
{
    public float distToTarget;
    bool activ = false;
    public int coolDown = 30;
    int timer = 0 ;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (target != null )
        {
            if (activ && timer <= 0)
            {
                timer = coolDown;
                if (Vector3.Distance(transform.position, target.transform.position) > distToTarget)
                {
                    TeleportTotarget(target);
                }else
                {
                    Fire();
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) <= distToTarget)
                {
                    activ = true;
                }
            }
        }

    }
    public void Fire()
    {
        Debug.Log("Fire");
    }

    bool TeleportTotarget(GameObject t)
    {
        
        for(int i=0; i<20; i++)
        {
            Vector3 newPosition = GeneratePosition() + t.transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 1);
            if (colliders.Length == 0)
            {
                transform.position = newPosition;
                return true;
            }
            foreach (Collider2D obj in colliders)
            {
                if (obj.transform.tag == "Ground" || obj.transform.tag == "Enemy")
                {
                    Debug.Log("Break");
                    break;
                }
                if (obj == colliders[colliders.Length-1])
                {
                    transform.position = newPosition;
                    return true;
                }
            }

        }
        return false;
    }
    public Vector3 GeneratePosition()
    {
        float maxX = Random.Range(-distToTarget, distToTarget);
        float maxY = Random.Range(-((distToTarget * distToTarget) - (maxX * maxX)), ((distToTarget * distToTarget) - (maxX * maxX)));
        float minX = maxX * 0.1f;
        float minY = maxY * 0.1f;
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

    }

}
