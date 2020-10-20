using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel = 2.4f;
    Rigidbody2D rb;
    public Transform gulaLocal;
    Transform inimigoLocal;
    bool face;
    public Animator anima;
    bool andar = false;
    public float distancia;
    //ataque
    float proximoataque;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inimigoLocal = GetComponent<Transform>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.inimigoLocal.position, gulaLocal.position);

        if ((gulaLocal.transform.position.x > this.inimigoLocal.position.x) && !face)
        {
            Flip();
        }
        else if((gulaLocal.transform.position.x < this.inimigoLocal.position.x) && face)
        {
            Flip();
        }

        Bater();

    }
    private void FixedUpdate()
    {
        if ((andar) && distancia > 2.8f)
        {
            if(gulaLocal.transform.position.x < this.inimigoLocal.position.x)
            {
                rb.velocity = new Vector2(-vel, rb.velocity.y);
                anima.SetBool("andar", true);
                anima.SetBool("idle", false);
            }
            if (gulaLocal.transform.position.x > this.inimigoLocal.position.x)
            {
                rb.velocity = new Vector2(vel, rb.velocity.y); 
                anima.SetBool("andar", true);
                anima.SetBool("idle", false);
            }

        }
       
    }
    
  
    void Flip()
    {
        face = !face;

        Vector3 scala = this.inimigoLocal.localScale;
        scala.x *= -1;
        this.inimigoLocal.localScale = scala;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            andar = true;
        }
    }

    void Bater()
    {
        if (distancia <= 2 && Time.time > proximoataque )
        {
            anima.SetTrigger("bater");
            proximoataque = Time.time + 1;
        }
    }
        


}
