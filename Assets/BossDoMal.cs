using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoMal : MonoBehaviour
{
    public float vel = 2.4f;
    Rigidbody2D rb;
     Transform checkParede;
    Transform inimigoLocal;
    bool face;
    public Animator anima; 
    public bool bater;
    public bool naparede;
    
    float proximoataque;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inimigoLocal = GetComponent<Transform>();
        anima = GetComponent<Animator>();
        checkParede = gameObject.transform.Find("checkParede");
    }

    // Update is called once per frame
    void Update()
    {
        naparede = Physics2D.Linecast(inimigoLocal.position, checkParede.position, 1 << LayerMask.NameToLayer("parede"));

        
         Bater();
        Mover();
        
    }

   void Mover()

    {
        if (naparede == false)
        {
            if (naparede)
            {
                rb.velocity = new Vector2(vel, 0);
                Flip();
                anima.Play("andar");
            }
            else
            {
                rb.velocity = new Vector2(-vel, 0);

                anima.Play("andar");
            }

            naparede = !naparede;
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
            bater = true;
            print("dentrp");
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bater = false;
            print("fora");
        }
    }

    void Bater()
    {
        if (bater == true && Time.time > proximoataque)
        {
            anima.Play("ataque");
            proximoataque = Time.time + 1;

        }
    }
}
