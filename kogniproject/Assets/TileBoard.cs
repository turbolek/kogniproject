using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour {

    public Tile[] tiles;

	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Reset()
    {
        TileColor tileColor;
        foreach (Tile tile in tiles)
        {
            tileColor = ColorSet.colors[Random.Range(0, ColorSet.colors.Count)];
            tile.GetComponent<SpriteRenderer>().color = tileColor.color;
            tile.codeChar = tileColor.codeChar;
        }
    }


}
