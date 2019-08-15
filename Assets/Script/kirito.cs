using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kirito : MonoBehaviour {

    public float kiritospeed;
    public float jumpPower;
    public Transform groundCheckPoint;
    public LayerMask whatisGround;
    private Rigidbody2D body;
    private Vector2 movimiento;
    private float horImput;
    private bool jumpImput;
    private bool kiritoground;
    private Animator anim;
    private bool faceRigth;
	// Use this for initialization
	void Start () {
        this.body = this.GetComponent<Rigidbody2D>();
        this.movimiento = new Vector2();
        this.kiritoground = false;
        this.anim = this.GetComponent<Animator>();
        this.faceRigth = true;
	}
	
	// Update is called once per frame
	void Update () {
        this.horImput = Input.GetAxis("Horizontal");
        this.jumpImput = Input.GetKey(KeyCode.Space);
        this.anim.SetFloat("HoriSpeed", Mathf.Abs(this.body.velocity.x));
        this.anim.SetFloat("VertSpeed", Mathf.Abs(this.body.velocity.y));
        if (Physics2D.OverlapCircle(this.groundCheckPoint.position, 0.1f, this.whatisGround))
        {
            this.kiritoground = true;
        }
        else
        {
            this.kiritoground = false;
        }
        if ((this.horImput<0)&&(this.faceRigth))
        {
            this.Flip();
            this.faceRigth = false;
        }else if ((this.horImput > 0) && (!this.faceRigth))
        {
            this.Flip();
            this.faceRigth = true;
        }
	}
    private void FixedUpdate()
    {
        this.movimiento = this.body.velocity;
        this.movimiento.x = horImput * kiritospeed; 
        if (this.jumpImput && this.kiritoground)
        {
            this.movimiento.y = jumpPower;
        }
        if (!this.kiritoground)
        {
            if(this.movimiento.y < -7)
            {
                this.movimiento.y = -7;
            }
        }

        this.body.velocity = this.movimiento;
    }

    void Flip()
    {
        //Vector3 scale = this.transform.localScale;
        //scale.x *= (-1);
        //this.transform.localScale = scale;
        this.transform.Rotate(Vector3.up,180);
    }
    public void OnGetKill()
    {
        GameMaster.current.GamerOver();
    }
}
