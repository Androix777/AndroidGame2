using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenButton : MonoBehaviour {

    public GameObject layoutClose;
	public GameObject layoutOpen;
	public string SceneName;
    public void Change() {
        layoutClose.gameObject.SetActive(false);
		layoutOpen.gameObject.SetActive(true);
    }

	public void NewScene() {
        SceneManager.LoadScene(SceneName);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
