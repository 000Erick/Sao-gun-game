using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmasDistancia : MonoBehaviour {
    public LayerMask whatToHit;
    public GameObject lineHit;
    public float shootRatio;
    public float damageHit;
    public int munition;
    private float TimeS;

	// Use this for initialization
	void Start () {
        this.TimeS = 0;
        GameMaster.current.UpdateTextMunition(this.munition);
    }
	
	// Update is called once per frame
	void Update () {
        this.TimeS += Time.deltaTime;
        if (Input.GetButton("Fire1")&& (this.TimeS>this.shootRatio)&&(this.munition>0))
        {
            this.Shoot();
            this.TimeS = 0;
            this.munition--;
            GameMaster.current.UpdateTextMunition(this.munition);

        }
	}

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.right, 10, this.whatToHit);
        GameObject tmp = Instantiate(this.lineHit) as GameObject;
        LineRenderer line = tmp.GetComponent<LineRenderer>();

        
        if (hit.collider)
        {
            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, hit.point);
            if (hit.collider.gameObject.CompareTag("Wolf"))
            {
                hit.collider.SendMessage("Hurt",this.damageHit);
            }
        }
        else
        {
            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, this.transform.position + (this.transform.right * 10));
        }
        Destroy(tmp, 0.05f);
    }
    
}
