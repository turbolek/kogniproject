using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int layerIndex;
    [Header ("1 => right, -1 => left")]
    public int direction;
    [HideInInspector]
    public Vector2 directionVector;

    // Use this for initialization
    void Start () {
        directionVector = new Vector2(direction, 0);
        Debug.Log("Direction vector for " + gameObject + " : " + directionVector);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Player update");
	}
}
