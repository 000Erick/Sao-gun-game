using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   // public static int id=2;
    public GameObject Kirito;
    public GameObject Sani;
    // Use this for initialization

    

    void Start () {
       // this.crearPlayer(id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void crearPlayer(int i)
    {
        switch (i)
        {
            case 1:
                {
                    Instantiate(this.Kirito,this.transform.position,Quaternion.identity);
                    break;
                }
            case 2:
                {
                    Instantiate(this.Sani, this.transform.position, Quaternion.identity);
                    break;
                }
        }
        
    }
}
