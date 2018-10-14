using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarManager : MonoBehaviour {
    
    Renderer rend;
    Color originalColor;
    public Color newColor = Color.red;
    public float colorChangeTime = 2f;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor("_Color");
	}

    public void ChangeColor()
    {
        rend.material.color = Color.Lerp(newColor, originalColor, colorChangeTime);
    }

    public void ChangeColorBack()
    {
        rend.material.color = Color.Lerp(originalColor, newColor, colorChangeTime);
    }
}
