using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player owner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnUnit(Transform unitPrefab)
    {
        Transform unitTransform = Instantiate(unitPrefab, gameObject.transform.position, Quaternion.identity);
        unitTransform.parent = gameObject.transform;
        unitTransform.GetComponent<Unit>().owner = owner;
    }
}
