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

    private Spawner spawner;

    void Awake()
    {       
        owner = GetOwner();
        spawner = GetSpawner();
        SetControlKeys(owner);
    }

	// Use this for initialization
	void Start () {
        Reset();
        SelectTileAtIndex(0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(upKey) || Input.GetKeyDown(downKey) || Input.GetKeyDown(leftKey) || Input.GetKeyDown(rightKey))
        {
            int previousHighlightedTileIndex = highlightedTileIndex;
            if (Input.GetKeyDown(upKey))
            {
                
                highlightedTileIndex -= 6;
                SelectTileAtIndex(highlightedTileIndex);
            }
            if (Input.GetKeyDown(downKey))
            {
                highlightedTileIndex += 6;
            }
            if (Input.GetKeyDown(rightKey))
            {
                highlightedTileIndex += 1;
            }
            if (Input.GetKeyDown(leftKey))
            {
                highlightedTileIndex -= 1;                
            }
            highlightedTileIndex = Mathf.Clamp(highlightedTileIndex, 0, 35);
            if (highlightedTileIndex != previousHighlightedTileIndex)
            {
                DeselectTile(tiles[previousHighlightedTileIndex]);
                SelectTileAtIndex(highlightedTileIndex);
                if (tileSelected)
                {
                    SwapTiles(previousHighlightedTileIndex, highlightedTileIndex);
                }
            }
            
        }

        if (Input.GetKeyDown(selectKey))
        {
            tileSelected = !tileSelected;
        }
        if (Input.GetKeyDown(enterKey))
        {
            spawner.spawnUnits(GenerateString());
            Reset();
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
        tile.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        tile.transform.Translate(0, 0, -.1f);
    }

    private void DeselectTile(Tile tile)
    {
        tile.transform.localScale = new Vector3(1f, 1f, 1f);
        tile.transform.Translate(0, 0, .1f);
    }

    private void SelectTileAtIndex(int index)
    {
        
        
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
            selectKey = "right shift";
            enterKey = "enter";
        }
    }

    private void SwapTiles (int tileIndex_1, int tileIndex_2)
    {
        char tempChar = tiles[tileIndex_1].codeChar;
        Color32 tempColor = tiles[tileIndex_1].GetComponent<SpriteRenderer>().color;

        tiles[tileIndex_1].codeChar = tiles[tileIndex_2].codeChar;
        tiles[tileIndex_1].GetComponent<SpriteRenderer>().color = tiles[tileIndex_2].GetComponent<SpriteRenderer>().color;
        tiles[tileIndex_2].codeChar = tempChar;
        tiles[tileIndex_2].GetComponent<SpriteRenderer>().color = tempColor;
        tileSelected = false;
    }

    private Spawner GetSpawner()
    {
        Spawner _spawner = owner.GetComponentInChildren<Castle>().GetComponentInChildren<Spawner>();
        return _spawner;
    }

    public string GenerateString()
    {
        string output = "";
        foreach (Tile tile in tiles)
        {
            output += tile.codeChar;
        }
        return output;
    }
}
