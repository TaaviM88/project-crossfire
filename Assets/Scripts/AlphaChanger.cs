using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphaChanger : MonoBehaviour {
    Image image;
    float alphaIndex = 0.5f;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    public void ResetAlpha()
    {
        alphaIndex = 0;
    }

    private void OnGUI()
    {
        image.CrossFadeAlpha(alphaIndex, 2, false);
    }
}
