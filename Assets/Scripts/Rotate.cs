using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rotateSpeed = 50f;
    //public GameObject player;
    //private float rbSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(player.transform.eulerAngles);
        transform.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed), Space.World);
	}
}
