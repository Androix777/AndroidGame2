using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAIMachineGun : MonoBehaviour {
    GameObject hero;
    GameObject room;
    public GameObject gun { get; set; }

    public float angleView;
    public float angleStart;

    // Use this for initialization
    void Start() {
        gun = gameObject;
        hero = GameObject.FindGameObjectWithTag("Hero").gameObject;
        room = GameObject.FindGameObjectWithTag("Room").gameObject;

    }

    // Update is called once per frame
    void Update() {
        Vector3 difference = hero.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationZ = (361 + rotationZ) % 361;
        float minAngle = (361 + angleStart - angleView) % 361;
        float maxAngle = (361 + angleStart + angleView) % 361;

        if (SeeTarget())
        {
            if (maxAngle < angleStart || minAngle > angleStart)
            {
                if (rotationZ <= maxAngle && rotationZ >= 0 || rotationZ <= 360 && rotationZ >= minAngle)
                {
                    Debug.Log(1);
                    gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                    gun.GetComponent<Gun>().Fire(difference.normalized);
                }
            }
            else
            {
                if (rotationZ <= maxAngle && rotationZ >= angleStart || rotationZ <= maxAngle && rotationZ >= minAngle)
                {
                    Debug.Log(2);
                    gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                    gun.GetComponent<Gun>().Fire(difference.normalized);
                }
            }
        }

        if (transform.rotation.eulerAngles.z > -90 && transform.rotation.eulerAngles.z < 90)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }


    }
    public bool SeeTarget()
    {
        // Debug.Log(Physics2D.Raycast(transform.position, target.transform.position - transform.position).transform.tag);
        // Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);

        if (Physics2D.Raycast(transform.position, hero.transform.position - transform.position).transform.tag == "Hero")
        {
            return true;
        }
        else return false;
    }
}

