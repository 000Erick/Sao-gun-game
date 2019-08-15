using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformControlle : MonoBehaviour {
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject[] PlataformPrefab;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MyPlataform()
    {
        Instantiate(this.GeneratePlataform(), this.P1.transform.position, Quaternion.identity);
        Instantiate(this.GeneratePlataform(), this.P2.transform.position, Quaternion.identity);
        Instantiate(this.GeneratePlataform(), this.P3.transform.position, Quaternion.identity);
        Instantiate(this.GeneratePlataform(), this.P4.transform.position, Quaternion.identity);
    }

    GameObject GeneratePlataform()
    {
        int random = UnityEngine.Random.Range(0, this.PlataformPrefab.Length);
        return this.PlataformPrefab[random];
    }
        

    
}
