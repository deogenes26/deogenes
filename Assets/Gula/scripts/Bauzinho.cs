using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bauzinho : MonoBehaviour
{
    // Start is called before the first frame update
    bool ativarbau = false;
    Animator anima;
    public int chave ;
    ItemManager item;
    Fome matafome;
    [SerializeField] EitensBau eitensBau = EitensBau.moeda;


    void Start()
    {
        anima = GetComponent<Animator>();
        item = GameObject.FindGameObjectWithTag("item").GetComponent<ItemManager>();
        matafome = FindObjectOfType<Fome>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (ativarbau == true && Input.GetKey(KeyCode.E) )
        {
            
            ItemBau();

            
        }
    }
    void ItemBau()
    {
        switch (eitensBau)
        {
            case EitensBau.chave:
                item.valorchave = chave;
                anima.Play("BauChave");             
                                                     
                break;
            case EitensBau.moeda:
                print("moeda");
               
                break;
            case EitensBau.vida:
                anima.Play("bauCoxa");
                matafome.fome += 30f;
                print("vida");
                
                break;
            case EitensBau.estrela:
                print("estrela");
                
                break;
        }
        

    }
    void Destuir()
    {
        print("cabum");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ativarbau = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ativarbau = false;
           
        }
    }
}
