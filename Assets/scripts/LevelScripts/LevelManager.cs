using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    PlayerScripts playerScripts;
    UIControler uIControler;
    public string sahneAdi;

    private void Awake()
    {
        instance = this;
        playerScripts = Object.FindObjectOfType<PlayerScripts>();
        uIControler= Object.FindObjectOfType<UIControler>();
    }
    public int toplananMucevherSayisi;
    private void Start()
    {
        
    }
    public void sahneyibitir()
    {
        StartCoroutine(sahneyiBitirRoutine());
    }
    IEnumerator sahneyiBitirRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        playerScripts.hareketEtsinMi = false;
        yield return new WaitForSeconds(1f);
        uIControler.fadeEkraniAc();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sahneAdi);
    }
}
