using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour {

    public Tile[] tiles;
    public Tile highlightedTile;
    private int highlightedTileIndex;
    private Player owner;
    private bool tileSelected = false;

    private string upKey;
    private string downKey;
    private string rightKey;
    private string leftKey;
    private string selectKey;
    private string enterKey;

    void Awake()
    {       
        owner = GetOwner();
        SetControlKeys(owner);
    }

	// Use this for initialization
	void Start () {
        Reset();
        SelectTileAtIndex(0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(upKey))
        {
            DeselectTile(tiles[highlightedTileIndex]);
            highlightedTileIndex -= 6;
            SelectTileAtIndex(highlightedTileIndex);
        }
        if (Input.GetKeyDown(downKey))
        {
            DeselectTile(tiles[highlightedTileIndex]);
            highlightedTileIndex += 6;
            SelectTileAtIndex(highlightedTileIndex);
        }
        if (Input.GetKeyDown(rightKey))
        {
            DeselectTile(tiles[highlightedTileIndex]);
            highlightedTileIndex += 1;
            SelectTileAtIndex(highlightedTileIndex);
        }
        if (Input.GetKeyDown(leftKey))
        {
            DeselectTile(tiles[highlightedTileIndex]);
            highlightedTileIndex -= 1;
            SelectTileAtIndex(highlightedTileIndex);
        }
        if (Input.GetKeyDown(selectKey))
        {
            tileSelected = !tileSelected;
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
        highlightedTileIndex = Mathf.Clamp(highlightedTileIndex, 0, 35);
        
        highlightedTile = tiles[index];
        highlightedTileIndex = index;
        HighlightTile(tiles[highlightedTileIndex]);
    }

    private Player GetOwner()
    {
        owner = GetComponentInParent<Player>();
        return owner;
    }

    private void SetControlKeys (Player owner)
    {
        if (owner == GameObject.Find("Player 1").GetComponent<Player>() )
        {
            upKey = "w";
            downKey = "s";
            leftKey = "a";
            rightKey = "d";
            selectKey = "space";
            enterKey = "e";
        } else
        {
            upKey = "up";
            downKey = "down";
            leftKey = "left";
            rightKey = "right";
            selectKey = "shift";
            enterKey = "enter";
        }
    }


}
