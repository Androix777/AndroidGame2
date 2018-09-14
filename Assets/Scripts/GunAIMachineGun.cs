using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAIMachineGun : MonoBehaviour {
    GameObject hero;
    GameObject room;
    public GameObject gun;

    public float angleView;
    public float angleStart;

    // Use this for initialization
    void Start () {

        hero = GameObject.FindGameObjectWithTag("Hero").gameObject;
        room = GameObject.FindGameObjectWithTag("Room").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = hero.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationZ = (360 + rotationZ) % 360;
        float minAngle = (360 + angleStart - angleView) % 360;
        float maxAngle = (360 + angleStart + angleView) % 360;

        if (maxAngle < angleStart || minAngle > angleStart)
        {
            if (rotationZ <= maxAngle && rotationZ >= 0 || rotationZ <= 360 && rotationZ >= minAngle )
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
}
