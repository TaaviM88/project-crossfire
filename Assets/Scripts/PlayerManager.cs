using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameTypes.PlayerType playertype = GameTypes.PlayerType.None;
    public GameObject barrier;
    bool barrierOn = false;
    bool playerIsAlive = true;
    Animator anime;
    PlayerStarManager starManager;
    PlayerMovement playerMovement; 
    private int layerIndex;
	// Use this for initialization
	void Start () {
        GameManager.gameManager.AddPlayer(this);
        anime = GetComponent<Animator>();
        barrier.SetActive(false);
        barrierOn = false;
        starManager = GetComponentInChildren<PlayerStarManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.EnablePlayeMovement(true);
        layerIndex = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            playerIsAlive = false;
            PlayerDie(); 
        }
    }

    public void PlayerDie()
    {
        if(playerIsAlive == false && !barrierOn)
        {
            playerMovement.EnablePlayeMovement(false);
            GameManager.gameManager.CanvasEnable(); 
            Debug.Log("Kuolin saatana " + gameObject.name);
        }
    }
    public void ActivateBarrier()
    {
        anime.SetBool("Barrier",true);
        barrier.SetActive(true);
        barrierOn = true;
        gameObject.layer = 11;
        //gameObject.tag = "Untagged";
        starManager.ChangeColor();
    }
    public void DisableBarrier()
    {
        anime.SetBool("Barrier", false);
        barrier.SetActive(false);
        barrierOn = false;
        gameObject.layer = layerIndex;
        //gameObject.tag = "Player";
        starManager.ChangeColorBack();
    }

    public bool PlayerMove(bool move)
    {
        anime.SetBool("PlayerMoves", move);
        return move;
    }
}
