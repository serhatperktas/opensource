using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasarController : MonoBehaviour
{

    playerHealController playerHealController;
    private void Awake()
    {
        playerHealController = Object.FindObjectOfType<playerHealController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealController.hasarAl();
        }
    }
}
