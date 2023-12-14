using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class KurbagaController : MonoBehaviour
{
    public float hareketHizi;

    public Transform solHedef, sagHedef;

    bool sagTarafta;

    Rigidbody2D rb;
    public float beklemeSuresi, hareketSuresi;
    float hareketSayaci, beklemeSayaci;
    Animator anim;
    public SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }
    private void Start()
    {
        solHedef.parent = null;

        sagHedef.parent=null;

        sagTarafta = true;
        hareketSayaci = hareketSuresi;
    }
    private void Update()
    {
        if (hareketSayaci > 0)
        {
            hareketSayaci -= Time.deltaTime;

            if (sagTarafta)
            {
                rb.velocity = new Vector2(hareketHizi, rb.velocity.y);
                sr.flipX = true;

                if (transform.position.x > sagHedef.position.x)
                {
                    sagTarafta = false;
                }
            }
            else
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-hareketHizi, rb.velocity.y);
                if (transform.position.x < solHedef.position.x)
                {
                    sagTarafta = true;
                }
            }
            if (beklemeSayaci <= 0)
            {
                beklemeSayaci = beklemeSuresi;
            }
            anim.SetBool("hareketediyor", true);
        }
        else if (beklemeSayaci > 0)
        {
            beklemeSayaci -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);
            
            if (beklemeSayaci <= 0)
            {
                hareketSayaci = hareketSuresi;
            }
            anim.SetBool("hareketediyor", false);
        }
    }  
}
