using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUpgrades : MonoBehaviour {

	GameObject content;
	GameObject panelExample;
	public GameObject generator;
	int[] upgrades;
	GameObject[] panels;

	// Use this for initialization
	void Start () {
		content = gameObject.transform.Find("Viewport").Find("Content").gameObject;
		panelExample = content.transform.Find("PanelExample").gameObject;
		upgrades = generator.GetComponent<PlayerCreator>().upgrades;
		panels = new GameObject[upgrades.Length];
		for(int i = 0; i < upgrades.Length; i++)
		{
			panels[i] = Instantiate(panelExample, content.transform); 
			panels[i].transform.Find("Num").GetComponent<Text>().text = i.ToString();
			panels[i].SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddPanel () {
		
	}
}
