using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    public GameObject canvas;
    List<PlayerManager> listPlayers;
    List<EnemyShooting> listEnemy;
    public GameTypes.PlayerType player;
    bool timerOn = false, playerIsAlive = true;
    public bool timeScale = true;

    // Use this for initialization
    void Awake()
    {
        canvas.SetActive(false);
        gameManager = this;
        listPlayers = new List<PlayerManager>();
        listEnemy = new List<EnemyShooting>();
    }

    public void AddPlayer(PlayerManager _player)
    {
        listPlayers.Add(_player);
    }

    public PlayerManager GetPlayer(GameTypes.PlayerType _player)
    {
        foreach (var p in listPlayers)
        {
            if (p.playertype == _player)
            {
                return p;
            }
        }
        return null;
    }
    public void AddEnemy(EnemyShooting _enemy)
    {
        listEnemy.Add(_enemy);
    }
    public void RemoveEnemy(EnemyShooting _enemy)
    {
        if (listEnemy.Count != 0)
        {
            listEnemy.Remove(_enemy);
        }
        else
            PlayerWins();
    }
    public void CanvasEnable()
    {
        canvas.SetActive(true);
    }

    public void PlayerWins()
    {
        CanvasEnable();
    }
}
