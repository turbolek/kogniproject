using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TileBoard : MonoBehaviour {

    public Tile[] tiles;
    public Tile highlightedTile;
    public GameObject selector; 
    private int highlightedTileIndex = 0;
    private int tileIndexAfterMove = 0;
    private Player owner;
    private bool tileSelected = false;

    private string upKey;
    private string downKey;
    private string rightKey;
    private string leftKey;
    private string selectKey;
    private string enterKey;

    private Spawner spawner;

    private StringDecoder decoder;

    void Awake()
    {       
        owner = GetOwner();
        spawner = GetSpawner();
        SetControlKeys(owner);
    }

	// Use this for initialization
	void Start () {
        decoder = FindObjectOfType<StringDecoder>();
        Reset();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(upKey) || Input.GetKeyDown(downKey) || Input.GetKeyDown(leftKey) || Input.GetKeyDown(rightKey))
        {
            int previousHighlightedTileIndex = highlightedTileIndex;
            if (Input.GetKeyDown(upKey))
            {
                tileIndexAfterMove = highlightedTileIndex - 6;
                if (tileIndexAfterMove >= 0) highlightedTileIndex -= 6;               
            }
            if (Input.GetKeyDown(downKey))
            {
                tileIndexAfterMove = highlightedTileIndex + 6;
                if (tileIndexAfterMove <= 35) highlightedTileIndex += 6;
            }
            if (Input.GetKeyDown(rightKey))
            {
                tileIndexAfterMove = highlightedTileIndex + 1;
                if (tileIndexAfterMove/6 == highlightedTileIndex/6 ) highlightedTileIndex += 1;
            }
            if (Input.GetKeyDown(leftKey))
            {
                if (highlightedTileIndex > 0)
                {
                    tileIndexAfterMove = highlightedTileIndex - 1;
                    if (tileIndexAfterMove / 6 == highlightedTileIndex / 6) highlightedTileIndex -= 1;
                }

            }
            selector.transform.position = new Vector3(tiles[highlightedTileIndex].transform.position.x, tiles[highlightedTileIndex].transform.position.y, -0.05f);
            highlightedTileIndex = Mathf.Clamp(highlightedTileIndex, 0, 35);

            Tile _highlightedTile = tiles[highlightedTileIndex];
            selector.transform.position.Set(_highlightedTile.transform.position.x, _highlightedTile.transform.position.y, 0.05f);
            if (highlightedTileIndex != previousHighlightedTileIndex)
            {
                DeselectTile(tiles[previousHighlightedTileIndex]);
                
                if (tileSelected)
                {
                    SelectTileAtIndex(highlightedTileIndex);
                    SwapTiles(previousHighlightedTileIndex, highlightedTileIndex);
                }
            }
            DrawPortraits();
        }

        if (Input.GetKeyDown(selectKey))
        {
            tileSelected = !tileSelected;
            if (tileSelected)
            {
                HighlightTile(tiles[highlightedTileIndex]);
            } else
            {
                DeselectTile(tiles[highlightedTileIndex]);
            }
        }
        if (Input.GetKeyDown(enterKey))
        {
            spawner.spawnUnits(decoder.GetUnitsToSpawn(GenerateString()));
            Reset();
        }

        

    }

    private void Reset()
    {
        int i = 0;
        while (i == 0 || decoder.GetUnitsToSpawn(GenerateString()).Count != 0)
        {
            TileColor tileColor;
            foreach (Tile tile in tiles)
            {
                tileColor = ColorSet.colors[Random.Range(0, ColorSet.colors.Count)];
                tile.GetComponent<SpriteRenderer>().color = tileColor.color;
                tile.codeChar = tileColor.codeChar;
                tile.transform.parent.Find("Portrait").GetComponent<SpriteRenderer>().enabled = false;
            }
            i++;
        }

    }

    private void HighlightTile(Tile tile)
    {
        tile.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -0.1f);
    }

    private void DeselectTile(Tile tile)
    {
        tile.transform.localScale = new Vector3(1f, 1f, 1f);
        tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, 0f);
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
        //tileSelected = false;
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

    private void DrawPortraits()
    {
        List<Unit> unitsToSpawn = decoder.GetUnitsToSpawn(GenerateString());
        List<int> matchIndices = new List<int>();
        foreach (Match match in decoder.matches)
        {
            matchIndices.Add(match.Index);
        }
        for (int i = 0; i < tiles.Length; i++)
        {
            SpriteRenderer portraitSpriteRenderer = tiles[i].transform.parent.Find("Portrait").GetComponent<SpriteRenderer>();
            if (matchIndices.Contains(i))
            {
                int matchIndex = matchIndices.IndexOf(i);
                portraitSpriteRenderer.enabled = true;
                portraitSpriteRenderer.sprite = unitsToSpawn[matchIndex].portrait;
            } else
            {
                portraitSpriteRenderer.enabled = false;
            }

        }
    }
}
