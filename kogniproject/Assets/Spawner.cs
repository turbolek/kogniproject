using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public bool owner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnUnit(Transform unitPrefab)
    {
        Transform unit = Instantiate(unitPrefab, gameObject.transform.position, Quaternion.identity);
        unit.parent = gameObject.transform;
    
    }
}
