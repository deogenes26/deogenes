using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public float maxvida = 3;
    public float minvida = 0;
    public float vidaatual = 3;
    
    public Image[] vidavazia;
    public Image[] vida;
    

    void Start()
    {
        print(vidaatual);
    }

    // Update is called once per frame
    
    public void Dano()
    {
        if (vidaatual > minvida)
        {
            vidaatual -= 1;
            print (vidaatual);
            VidaNahud();

        }
        if(vidaatual <= 0)
        {
            GameManager.CheckPoint();
        }
    }
    
    void VidaNahud()
    {
        
        if (vidaatual == 3)
        {
            vida[0].enabled = true;
            vida[1].enabled = true;
            vida[2].enabled = true;
        }
        else if (vidaatual == 2)
        {
            vida[0].enabled = true;
            vida[1].enabled = true;
            vida[2].enabled = false;
        }
        else if (vidaatual == 1)
        {
            vida[0].enabled = true;
            vida[1].enabled = false;
            vida[2].enabled = false;
        }
        else
        {
            vida[0].enabled = false;
            vida[1].enabled = false;
            vida[2].enabled = false;

        }

    }

   
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("hit"))
        {
            Dano();
        }
    }
}
