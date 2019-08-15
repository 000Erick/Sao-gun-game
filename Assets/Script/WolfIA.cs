using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfIA : MonoBehaviour {

    public float Walkspeed;
    public Transform groundCheckPoint;
    public Transform attakJump;
    public Transform garraPosition;
    public LayerMask whatisGround;
    public LayerMask whatisPlayer;
    public GameObject Garra;
    public int damage;
    private Rigidbody2D body;
    private Vector2 movimiento;
    private float horImput;
    private bool jumpImput;
    private bool kiritoground;
    private bool wolfPared;
    private bool wolfPlayer;
    private Animator anim;
    private bool faceRigth;
    private float time;
    private float timeToAttak;
    private GameObject Target;
    // Use this for initialization
    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
        this.movimiento = new Vector2();
        this.kiritoground = false;
        this.anim = this.GetComponent<Animator>();
        this.faceRigth = true;
        this.time = 0;
        this.timeToAttak = 1;
        this.Target=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if (this.time > this.timeToAttak)
        {
            this.time = 0;
            this.Attack();
        }

        if (this.Target != null)
        {
            if (this.transform.position.x < this.Target.transform.position.x)
            {
                this.horImput = 1;
            }
            else
            {
                this.horImput = -1;
            }
        }
        else
        {
            this.horImput = 0;
        }
            
        
      
            
        
        
        
        this.anim.SetFloat("HoriSpeed", Mathf.Abs(this.body.velocity.x));
        this.anim.SetFloat("VertSpeed", Mathf.Abs(this.body.velocity.y));
        if (Physics2D.OverlapCircle(this.groundCheckPoint.position, 0.12f, this.whatisGround))
        {
            this.kiritoground = true;
        }
        else
        {
            this.kiritoground = false;
        }
        
        if ((this.horImput < 0) && (this.faceRigth))
        {
            this.Flip();
            this.faceRigth = false;
        }
        else if ((this.horImput > 0) && (!this.faceRigth))
        {
            this.Flip();
            this.faceRigth = true;
        }
        if (Physics2D.OverlapCircle(this.attakJump.position, 0.21f, this.whatisGround))
        {
            this.wolfPared = true;
        }
        else
        {
            this.wolfPared = false;
        }
    }
    private void FixedUpdate()
    {
        this.movimiento = this.body.velocity;
        this.movimiento.x = horImput * Walkspeed;
        if (!this.kiritoground)
        {
            if (this.movimiento.y < -7)
            {
                this.movimiento.y = -7;
            }
        }
        if (this.wolfPared)
        {
            this.movimiento.y = 8;
        }
        

        this.body.velocity = this.movimiento;
    }

    void Flip()
    {
        //Vector3 scale = this.transform.localScale;
        //scale.x *= (-1);
        //this.transform.localScale = scale;
        this.transform.Rotate(Vector3.up, 180);
    }
    void Attack()
    {
        
        Collider2D tmp2 = Physics2D.OverlapCircle(this.attakJump.position, 0.1f, this.whatisPlayer);
        if (tmp2)
        {
            tmp2.gameObject.SendMessage("Hurt", this.damage);
            GameObject tmp = Instantiate(this.Garra, this.garraPosition.position, Quaternion.identity);
            Destroy(tmp, 0.05f);
        }
    }
    public void OnGetKill()
    {
        GameMaster.current.AddPuntuation(100);
    }
}
