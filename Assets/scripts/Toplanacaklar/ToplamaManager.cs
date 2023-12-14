using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool mucevherMi;
    [SerializeField]
    bool toplandiMi;
    [SerializeField]
    bool kirazMi;
    [SerializeField]
    GameObject toplamaEffecti;


    LevelManager levelManager;
    UIControler uicontroler;
    playerHealController playerHealController;


    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uicontroler = Object.FindObjectOfType<UIControler>();
        playerHealController = Object.FindObjectOfType<playerHealController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !toplandiMi)
        {
            if(mucevherMi)
            {
                levelManager.toplananMucevherSayisi++;
                toplandiMi = true;
                Destroy(gameObject);
                uicontroler.mucevherSayisiniGuncelle();
                Instantiate(toplamaEffecti,transform.position,transform.rotation);
                sesMeager.instance.karisiksesEffectCikar(7);
            }
            if (kirazMi)
            {
                if (playerHealController.gecerliSaglik!=playerHealController.maxSaglik) 
                {
                    
                    toplandiMi = true;
                    Destroy(gameObject);
                    playerHealController.caniArtir();
                    Instantiate(toplamaEffecti, transform.position, transform.rotation);
                    sesMeager.instance.sesEffectCikar(4);

                }
                }
            

        }
    }
}
