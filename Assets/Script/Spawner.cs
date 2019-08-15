using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Enemig;
    public int enemigLimit;
    private float time;
    private float timeToSpawn;
    private float enemigCount;
	// Use this for initialization
	void Start () {
        this.time = 0;
        this.timeToSpawn = 1;
	}
    private void OnEnable()
    {
        this.enemigCount = 0;
    }
    // Update is called once per frame
    void Update () {
        this.time += Time.deltaTime;
        if (this.time > timeToSpawn)
        {
            this.time = 0;
            Instantiate(this.Enemig,this.transform.position,Quaternion.identity);
            this.enemigCount++;
            if (this.enemigCount >= this.enemigLimit)
            {
                this.gameObject.SetActive(false);
            }
        }
		
	}
}
