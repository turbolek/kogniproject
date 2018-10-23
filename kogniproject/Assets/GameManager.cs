using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Player[] players;
    [SerializeField]
    private EndgameMessageDisplay messageDisplay;

	// Use this for initialization
	void Start () {
        players = FindObjectsOfType<Player>();
        //Subscribe for Castle.Destroyed event
        Castle.Destroyed += EndGame;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EndGame(Player loser)
    {
        Player winner = null;
        foreach (Player player in players)
        {
            if (player != loser)
            {
                winner = player;
            }
        }
        messageDisplay.DisplayMessage(winner.name + " wins!");
    }
}
