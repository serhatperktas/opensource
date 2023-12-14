using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIControler : MonoBehaviour
{
    [SerializeField]
    Image heart1, heart2,heart3;
    [SerializeField]
    Sprite fullHeart, halfHeart, emptyHeart;
    public GameObject fadeScreen;

    playerHealController playerHealController;

    [SerializeField]
    TMP_Text mucevherText;
    LevelManager levelManager;
    private void Awake()
    {
        playerHealController = Object.FindAnyObjectByType<playerHealController>();
        levelManager = Object.FindAnyObjectByType<LevelManager>();
    }
    public void saglikDurumunuGuncelle()
    {
        switch(playerHealController.gecerliSaglik)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;
            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;
                break;
            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                break;
            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            

        }
    }
    public void mucevherSayisiniGuncelle()
    {
        mucevherText.text = levelManager.toplananMucevherSayisi.ToString();
    }
    public void fadeEkraniAc()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }
}
