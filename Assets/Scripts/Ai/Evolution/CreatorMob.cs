using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorMob : MonoBehaviour {

    public GameObject prefab;

    DNA Dn;

    List<DNA> listDNA;
    int numberDNA=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateMob()
    {
        Vector2[] moveVector = new Vector2 [5];
        moveVector[0] = new Vector2(1, 1);
        moveVector[1] = new Vector2(1, 1);
        moveVector[2] = new Vector2(1, 1);
        moveVector[3] = new Vector2(1, 1);
        moveVector[4] = new Vector2(1, 1);

        bool[] cheakVector = new bool[5];
        cheakVector[0] = true;
        cheakVector[1] = true;
        cheakVector[2] = true;
        cheakVector[3] = true;

        int[] sizeVector = new int[5];
        sizeVector[0] = 1;
        sizeVector[1] = 1;
        sizeVector[2] = 1;
        sizeVector[3] = 1;

        Vector2[] possVector = new Vector2[5];
        possVector[0] = new Vector2(1, 1);
        possVector[1] = new Vector2(1, 1);
        possVector[2] = new Vector2(1, 1);
        possVector[3] = new Vector2(1, 1);
       


        DNA newDna = new DNA (1,1,1,1,1,moveVector,cheakVector,sizeVector, possVector);

        GameObject newobj = Instantiate(prefab, transform.position, transform.rotation);
        newobj.GetComponent<EvolutionMob>().SetDNA(newDna, numberDNA+"");
        newobj.SetActive(true);

        numberDNA++;
    }



}
