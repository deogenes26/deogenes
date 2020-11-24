using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vida Aumentaessavidaai;
    public AudioClip itemsom;
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
                AudioM.inst.PlayAudio(itemsom);
                Aumentaessavidaai.VidaAdd();
                Destroy(gameObject);
            }
        }
    }
}
