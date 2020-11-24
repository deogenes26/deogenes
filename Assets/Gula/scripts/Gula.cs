using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Gula : MonoBehaviour
{
    [Header("pulo")]
    public float forca = 8f;
    public Rigidbody2D gula;
    public bool Pulo = false;
    Transform checkChao;
    public bool noChao = false;
    public AudioClip pulosom;

    [Header("andar")]
    Transform gulaTransforme;
    public bool face = false;
    public float vel = 2.5f;
    public float H;
    public float V;
    [Header("animacao")]
    public Animator anima;
   
    [Header("coyote")]
    public float coyoteduration = 0.1f;
    private float coyoteTime;
   
    [Header("escada")]
    public float climbSpeed = 3;
    public LayerMask ladderMask;
    public float vertical;
    public bool climbing;
    public float checkRadius = 0.3f;
    private Transform ladder;
    Collider2D col;
       
    private void Start()
    {
        gulaTransforme = GetComponent<Transform>();
        gula = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        checkChao = gameObject.transform.Find("checkChao");
       


        col = GetComponent<Collider2D>();
        ClimbLadder();
    }


    void Update()
    {
        noChao = Physics2D.Linecast(gulaTransforme.position, checkChao.position, 1 << LayerMask.NameToLayer("chao"));
       

        if (Input.GetKeyDown(KeyCode.Space) && (noChao || coyoteTime > Time.time))
        {

            Pulo = true;
            anima.SetTrigger("pulou");
            coyoteTime = Time.time;
            
        }
         
        
        
           
            
        

        if (Input.GetKey(KeyCode.D) && face)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.A) && !face)
        {
            Flip();
        }
        ClimbLadder();
        

    }
    private void FixedUpdate()
    {
        if (Pulo)
        {
           
            gula.AddForce(new Vector2(0, forca));
            Pulo = false;
            AudioM.inst.PlayAudio(pulosom);

        }

        Andar();
        //movimentacao antiga
       /* float H = Input.GetAxis("Horizontal");
            anima.SetFloat("move", Mathf.Abs(H));
            gula.velocity = new Vector2(H * vel, gula.velocity.y);

            vertical = Input.GetAxis("Vertical");*/


      GroundMovement();

    }
    public void MoverH(InputAction.CallbackContext ctx)
    {
        H = ctx.ReadValue<float>();
       
    }
    public void MoverV(InputAction.CallbackContext ctx)
    {
        V = ctx.ReadValue<float>();
        
    }
    void Andar()
    {
        
        gula.velocity = new Vector2(H * vel, gula.velocity.y);
        anima.SetFloat("move", Mathf.Abs(H));
    }
    void Flip()
    {
        face = !face;

        Vector3 scala = gulaTransforme.localScale;
        scala.x *= -1;
        gulaTransforme.localScale = scala;

    }
    bool TouchingLadder()
    {
        return col.IsTouchingLayers(ladderMask); 
    }
    void ClimbLadder()
    {
        bool up = Physics2D.OverlapCircle(transform.position, checkRadius, ladderMask); 
        bool down = Physics2D.OverlapCircle(transform.position + new Vector3(0, -1), checkRadius, ladderMask);

        if (V != 0 && TouchingLadder())
        {
            climbing = true;
            gula.isKinematic = true; 
           

          float xPos = ladder.position.x;

          transform.position = new Vector2(xPos, transform.position.y);
        }

        if (climbing) 
        {
            if (!up && V >= 0)
            {
                FinishClimb();
                return;
            }

            if (!down && V <= 0)
            {
                FinishClimb();
                return;
            }

            float y = V * climbSpeed;
            gula.velocity = new Vector2(0, y);
            anima.Play("subirEscada");
        }
       
    }

    void FinishClimb()
    {

        climbing = false;
        gula.isKinematic = false;
        anima.Play("idle");

    }

    void GroundMovement() 
    {

        if (noChao)
        {
            coyoteTime = Time.time + coyoteduration;
        }

    }   

      public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("escada"))
            {
                ladder = other.transform;
            }
        } 
}

