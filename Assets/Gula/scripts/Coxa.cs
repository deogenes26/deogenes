using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coxa : MonoBehaviour
{
    Fome matarfome;

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
                matarfome.fome += 30f;
                Destroy(gameObject);
            }
           
        }
    }

}
