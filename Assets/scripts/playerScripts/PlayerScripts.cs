using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;
    Rigidbody2D rb;
    [SerializeField]
    float ziplamahizi;

    bool yerdeMi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminlayer;
    bool ikiKezZiplayaBilirmi;

    public float geriTepmeSuresi,geriTepmeGucu;
    float geriTepmeSayaci;
    bool yonsagmi;

    public float dusmanZiplatma;
     
    Animator anim;
    public bool hareketEtsinMi;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        hareketEtsinMi = true;
    }

    private void Update()
    {   if(hareketEtsinMi)
        {
            if (geriTepmeSayaci <= 0)
            {
                HareketEttir();
                zipla();
                yonudegistir();
            }
            else
            {
                geriTepmeSayaci -= Time.deltaTime;
                if (yonsagmi)
                {
                    rb.velocity = new Vector2(-geriTepmeGucu, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(geriTepmeGucu, rb.velocity.y);
                }
            }
            anim.SetFloat("harekethizi", Mathf.Abs(rb.velocity.x));
            anim.SetBool("yerdemi", yerdeMi);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("harekethizi", Mathf.Abs(rb.velocity.x));

        }





    }
     void HareketEttir()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;
                rb.velocity = new Vector2 (hiz, rb.velocity.y);

    }
        void zipla()
    {
            
        yerdeMi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminlayer);

         if (yerdeMi)
        {
                ikiKezZiplayaBilirmi = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (yerdeMi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamahizi);
                sesMeager.instance.sesEffectCikar(3);
            }
            else
            {   if (ikiKezZiplayaBilirmi)
                rb.velocity = new Vector2(rb.velocity.x, ziplamahizi);
                ikiKezZiplayaBilirmi = false;
                sesMeager.instance.sesEffectCikar(3);
            }
       
        }
        anim.SetFloat("harekethizi", Mathf.Abs (rb.velocity.x));
        anim.SetBool("yerdemi",yerdeMi);
    }
        void yonudegistir()
    {
        Vector2 geciciScale = transform.localScale;
        if(rb.velocity.x >1f)
        {
            yonsagmi = true;
            geciciScale.x = 1f;
        }
        else if(rb.velocity.x < 0f)
        {   yonsagmi=false;
            geciciScale.x = -1f;
        }
        transform.localScale = geciciScale;
    }
    public void GeriTepmeFNC()
    {
        geriTepmeSayaci = geriTepmeSuresi;
        rb.velocity = new Vector2(0,rb.velocity.y);
        anim.SetTrigger("hasar");
    }
    public void ziplaFNC()
    {
        rb.velocity=new Vector2(rb.velocity.x,dusmanZiplatma);
        sesMeager.instance.sesEffectCikar(3);
    }
}
