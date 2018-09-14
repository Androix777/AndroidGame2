using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAIHero : MonoBehaviour {

   
    public GameObject gun{get;set;}

    Joystick control;

    // Use this for initialization
    void Start () {
        control = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
            
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 moveVector = (Vector3.right * control.Horizontal + Vector3.up * control.Vertical);
        moveVector = moveVector.normalized;

        if (moveVector != Vector3.zero)
        {
            AngleGun(moveVector);
            gun.GetComponent<Gun>().Fire(moveVector.normalized);
        }
       
    }
    virtual protected void AngleGun(Vector3 moveVector)
    {
        gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
    }
}
