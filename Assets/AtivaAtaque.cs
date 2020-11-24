using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaAtaque : MonoBehaviour
{
    public Animator anima;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anima.Play("ataque");
        }
    }
}
