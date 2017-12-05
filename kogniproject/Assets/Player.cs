using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int layerIndex;
    [Header ("1 => right, -1 => left")]
    public float direction;
    [HideInInspector]
    public Vector2 directionVector;

    // Use this for initialization
    void Start () {
        directionVector = new Vector2(direction, 0);
    }
}
