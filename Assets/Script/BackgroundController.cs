using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public Sprite[] sprite;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ModificarBackground(int i)
    {
        this.spriteRenderer.sprite = this.sprite[i];

    }

}
