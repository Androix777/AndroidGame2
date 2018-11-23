using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {
    public GameObject[] setStatusObjects;
    public bool setstatus, destroySetStatus;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            foreach (GameObject g in setStatusObjects)
            {
                g.SetActive(setstatus);
            }
            if (destroySetStatus)
            {
                Destroy(gameObject);
            }
        }

    }
}
