using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    // Start is called before the first frame update
    public float forcaH = 1;
    float tempodeDestruição = 1;
    float forcaHpadrao;
    void Start()
    {
        forcaHpadrao = forcaH;
    }


    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("inimigo"))
        {
            outro.gameObject.GetComponent<Enemy>().enabled = false;
            BoxCollider2D[] boxes = outro.gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
            if (outro.transform.position.x < transform.position.x)
                forcaH *= -1;
            outro.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaH, 2), ForceMode2D.Impulse);
            Destroy(outro.gameObject, tempodeDestruição);
            forcaH = forcaHpadrao;
            print("certo deu ");

        }
    }
    
}
