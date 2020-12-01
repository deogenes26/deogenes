using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Color minhacor;
    SpriteRenderer balao;
    GameManager gm;
    public AudioClip cpsom;
    void Start()
    {
        balao = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            balao.color = minhacor;
            gm.lastCheckpointpos = transform.position;
            AudioM.inst.PlayAudio(cpsom);
        }
    }
}
