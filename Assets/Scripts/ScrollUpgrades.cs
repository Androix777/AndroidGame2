using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUpgrades : MonoBehaviour {

	GameObject content;
	GameObject panel;

	// Use this for initialization
	void Start () {
		content = gameObject.transform.Find("Viewport").Find("Content").gameObject;
		panel = content.transform.Find("PanelExample").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddPanel () {
		
	}
}
