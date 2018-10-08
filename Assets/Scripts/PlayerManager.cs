using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameTypes.PlayerType playertype = GameTypes.PlayerType.None;
    bool playerIsAlive = true;

	// Use this for initialization
	void Start () {
        GameManager.gameManager.AddPlayer(this);
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
        if(playerIsAlive == false)
        {
            Debug.Log("Kuolin saatana " + gameObject.name);
        }
    }
}
