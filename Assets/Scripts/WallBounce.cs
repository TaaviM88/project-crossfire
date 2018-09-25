using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour {

    public float mapForce = 200f;

    public GameObject player;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Player")) {

            Vector3 knockbackVelocity = new Vector3((transform.position.x - player.transform.position.x) * mapForce, 
                (transform.position.z - player.transform.position.z) * mapForce);

            player.GetComponent<Rigidbody>().velocity = knockbackVelocity;
        }
    }
}
