using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPart : MonoBehaviour {
     int damage, speedDamage;
    GameObject god;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStats(int dam, int speed, string ID,GameObject lord)
    {
        damage = dam;
        speedDamage = speed;
        transform.tag = ID;
        god = lord;
    }
   


}
