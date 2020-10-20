using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspetoDano : MonoBehaviour
{
    Animator anima;
    Vida vidaperdida;
    void Start()
    {
        anima = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            vidaperdida = collision.gameObject.GetComponent<Vida>();
            vidaperdida.Dano();
            anima.Play("espinho");
            
        }
    }



}
