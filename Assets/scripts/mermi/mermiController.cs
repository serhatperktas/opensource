using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiController : MonoBehaviour
{
    playerHealController PlayerHealController;
    public float mermiHizi;

    private void Awake()
    {
        PlayerHealController=Object.FindAnyObjectByType<playerHealController>();
    }
    private void Update()
    {
        transform.position += new Vector3(-mermiHizi *transform.localScale.x * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealController.hasarAl();

        }
        Destroy(gameObject);
    }
}
