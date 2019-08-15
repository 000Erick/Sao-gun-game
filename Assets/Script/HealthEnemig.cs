using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthEnemig : MonoBehaviour {

    public float hp;
    public GameObject bloadExplotion;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hurt(float damage)
    {
        this.hp -= damage;
      
        if (this.hp <= 0)
        {
            this.hp = 0;
            GameObject be = Instantiate(this.bloadExplotion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(be, 0.5f);
            Destroy(this.gameObject);
            this.gameObject.SendMessage("OnGetKill");
        }
    }
}
