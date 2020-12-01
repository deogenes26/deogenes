using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UIElements;

public class Ataque : MonoBehaviour
{
    Animator anima;
    public float intervalodeataque;
    float proximoataque;
    public AudioClip espadasom;
    VidaBoss bossvida;




    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
        bossvida = FindObjectOfType<VidaBoss>();
    }


       
        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > proximoataque)
            {
                Combo1();
            }
        }
        void Combo1()
        {
            anima.SetTrigger("1golpe");
            AudioM.inst.PlayAudio(espadasom);
            proximoataque = Time.time + intervalodeataque;
        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        if (collision.gameObject.CompareTag("boss"))
        {
            bossvida.Dano();
           
        }
    }
}
    
