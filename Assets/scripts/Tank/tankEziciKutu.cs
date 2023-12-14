using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEziciKutu : MonoBehaviour
{
    PlayerScripts playerScripts;
    tankController tankController;

    private void Awake()
    {
        playerScripts= Object.FindAnyObjectByType<PlayerScripts>();
        tankController=Object.FindAnyObjectByType<tankController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player") && playerScripts.transform.position.y > transform.position.y)
        {
            playerScripts.ziplaFNC();
            tankController.darbealFNC();
            gameObject.SetActive(false);
        }
    }
}
