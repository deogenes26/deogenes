using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaTrancada : MonoBehaviour
{
    Animator anima;
    bool colocouchave = false;
    ItemManager item;
    public int fechadura;
    BoxCollider2D porta;

    void Start()
    {

        item = GameObject.FindGameObjectWithTag("item").GetComponent<ItemManager>();
        anima = GetComponent<Animator>();
        porta = GetComponent<BoxCollider2D>();

    }


    void Update()
    {
        if (colocouchave == true && Input.GetKey(KeyCode.E))
        {
            AbrirPorta();
            print("tocou1");
        }
       
    }
    
    void AbrirPorta()
    {
        if ( item.valorchave == fechadura)
        {
            anima.Play("portaAbrindo");
            porta.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colocouchave = true;
            print("tocou");


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colocouchave = false;


        }

    }
}
