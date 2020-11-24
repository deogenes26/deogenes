using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coxa : MonoBehaviour
{
    Fome matarfome;
    public AudioClip itemsom;

    private void Start()
    {
        matarfome = FindObjectOfType<Fome>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (matarfome.fome < 90f && matarfome.fome > 0f )
            {
                AudioM.inst.PlayAudio(itemsom);
                matarfome.fome += 30f;
                Destroy(gameObject);
            }
           
        }
    }

}
