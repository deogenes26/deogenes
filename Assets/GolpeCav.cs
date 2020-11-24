﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeCav : MonoBehaviour
{
    Vida vidinha;
    public AudioClip espadasom;

    private void Start()
    {
        vidinha = FindObjectOfType<Vida>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            vidinha.Dano();
            AudioM.inst.PlayAudio(espadasom);
        }
    }
}
