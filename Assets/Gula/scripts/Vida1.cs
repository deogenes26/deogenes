using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vida Aumentaessavidaai;
    private void Start()
    {
        Aumentaessavidaai = FindObjectOfType<Vida>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Aumentaessavidaai.vidaatual <3)
            {
                Aumentaessavidaai.vidaatual += 1;
                Destroy(gameObject);
            }
        }
    }
}
