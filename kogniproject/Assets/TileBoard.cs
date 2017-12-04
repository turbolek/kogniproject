using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour {

    public Tile[] tiles;
    public Tile selectedTile;
    private int selectedTileIndex;
    private Player owner;

	// Use this for initialization
	void Start () {
        Reset();
        SelectTileAtIndex(0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            DeselectTile(tiles[selectedTileIndex]);
            selectedTileIndex -= 6;
            SelectTileAtIndex(selectedTileIndex);
        }
        if (Input.GetKeyDown("down"))
        {
            DeselectTile(tiles[selectedTileIndex]);
            selectedTileIndex += 6;
            SelectTileAtIndex(selectedTileIndex);
        }
        if (Input.GetKeyDown("right"))
        {
            DeselectTile(tiles[selectedTileIndex]);
            selectedTileIndex += 1;
            SelectTileAtIndex(selectedTileIndex);
        }
        if (Input.GetKeyDown("left"))
        {
            DeselectTile(tiles[selectedTileIndex]);
            selectedTileIndex -= 1;
            SelectTileAtIndex(selectedTileIndex);
        }

        

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

    private void HighlightTile(Tile tile)
    {
        tile.transform.localScale += new Vector3(.25f, .25f, .25f);
        tile.transform.Translate(0, 0, -.1f);
    }

    private void DeselectTile(Tile tile)
    {
        tile.transform.localScale -= new Vector3(.25f, .25f, .25f);
        tile.transform.Translate(0, 0, .1f);
    }

    private void SelectTileAtIndex(int index)
    {
        selectedTileIndex = Mathf.Clamp(selectedTileIndex, 0, 35);
        
        selectedTile = tiles[index];
        selectedTileIndex = index;
        HighlightTile(tiles[selectedTileIndex]);
    }


}
