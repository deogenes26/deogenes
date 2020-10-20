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
    //golpear inimigo




    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
    }


        // Update is called once per frame
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
            proximoataque = Time.time + intervalodeataque;
        }
 }
    
