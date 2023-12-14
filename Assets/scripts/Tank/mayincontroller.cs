using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayinController : MonoBehaviour
{
    public GameObject patlamaeffect;
    playerHealController playerHealController;

    private void Awake()
    {
        playerHealController = Object.FindAnyObjectByType<playerHealController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            patlamaFNC();
            playerHealController.hasarAl();
        }
    }
    public void patlamaFNC()
    {
        Destroy(this.gameObject);
        Instantiate(patlamaeffect, transform.position, transform.rotation);
    }
}

