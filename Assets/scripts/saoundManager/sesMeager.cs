using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesMeager : MonoBehaviour
{
    public static sesMeager instance;
    public AudioSource[] sesEfectleri;
    private void Awake()
    {
        instance = this;
    }
    public void sesEffectCikar(int hangises)
    {
        sesEfectleri[hangises].Stop();
        sesEfectleri[hangises].Play();
    }
    public void karisiksesEffectCikar(int hangises)
    {
        sesEfectleri[hangises].Stop();
        sesEfectleri[hangises].pitch = Random.Range(0.8f, 1.2f);


        sesEfectleri[hangises].Play();
    }
}
