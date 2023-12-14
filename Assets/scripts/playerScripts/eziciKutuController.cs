using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eziciKutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokolmaefecct;
    PlayerScripts playerController;
    public float kirazinCikmasansi;

    public GameObject kirazObje;

    private void Awake()
    {
        playerController=Object.FindAnyObjectByType<PlayerScripts>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("kurbaga"))
        {
            other.transform.gameObject.SetActive(false);
            Instantiate(yokolmaefecct,transform.position,transform.rotation);

            playerController.ziplaFNC();

            float cikmaAraligi= Random.Range(0f, 100f);
            sesMeager.instance.sesEffectCikar(0);

            if(cikmaAraligi < kirazinCikmasansi)
            {
                Instantiate(kirazObje,other.transform.position,other.transform.rotation);
            }
        }
    }

   
}
