using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    List<PlayerManager> listPlayers;    
    public GameTypes.PlayerType player;
    bool timerOn = false, playerIsAlive = true;
    public bool timeScale = true;

	// Use this for initialization
	void Awake () {
        gameManager = this;
        listPlayers = new List<PlayerManager>();
	}
	
    public void AddPlayer(PlayerManager _player)
    {
        listPlayers.Add(_player);
    }

    public PlayerManager GetPlayer(GameTypes.PlayerType _player)
    {
        foreach( var p in listPlayers)
        {
            if(p.playertype == _player)
            {
                return p;
            }
        }
        return null;
    }

}
