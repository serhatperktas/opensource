using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealController : MonoBehaviour
{
    public int maxSaglik,gecerliSaglik;
    LevelManager levelManager;


    UIControler uIControler;
    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;

    SpriteRenderer  SpriteRenderer;
    PlayerScripts playerScripts;
    [SerializeField]
    GameObject olumEffecti;
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        uIControler = Object.FindAnyObjectByType <UIControler>();
        playerScripts = Object.FindAnyObjectByType <PlayerScripts>();
        levelManager = Object.FindAnyObjectByType<LevelManager>();

    }
    private void Start()
    {

        gecerliSaglik = maxSaglik;

    }
    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;
        if(yenilmezlikSayaci <= 0)
        {
            SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b,1);
        }
    }

    public void hasarAl()
    {
        if(yenilmezlikSayaci<=0)
        {
            gecerliSaglik--;

            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);
                Instantiate(olumEffecti,transform.position,transform.rotation);
                sesMeager.instance.sesEffectCikar(2);
                levelManager.sahneyibitir();
               

            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, 0.5f);
                playerScripts.GeriTepmeFNC();
                sesMeager.instance.sesEffectCikar(1);
            }

            uIControler.saglikDurumunuGuncelle();
        }
       
    }
    public void caniArtir()
    {
        gecerliSaglik++;
        if(gecerliSaglik>=maxSaglik)
        {
            gecerliSaglik = maxSaglik;
        }
    }

}
