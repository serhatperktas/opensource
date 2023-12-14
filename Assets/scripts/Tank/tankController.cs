using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankController : MonoBehaviour
{
    public enum tankdurumlari {atesetme,darbealma,hareketetme,sonaerdi };
    public tankdurumlari gecerlidurum;

    [SerializeField]
    Transform tankObje;
    public Animator anim;
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool yonuSagmi;
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmasayac;
    public float darbeSuresi;
    float darbeSayac;
    public GameObject tankEziciKutu;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayinnirakmaSuresi;
    public float mayinbirakmaSayac;

    public int candurumu = 5;
    public GameObject tankpatlamaEfecti;
    bool yenildimi;
    public float mermisuresiarttir;
    public float mayinbirakmasuresiarttir;

    private void Start()
    {
        gecerlidurum=tankdurumlari.atesetme;
    }
    private void Update()
    {
        switch (gecerlidurum)
        {
            case tankdurumlari.atesetme:
                mermiAtmasayac-=Time.deltaTime;
                if (mermiAtmasayac <= 0)
                {
                    mermiAtmasayac = mermiAtmaSuresi;
                  var yenimermi=  Instantiate(mermi,mermiMerkezi.position,mermiMerkezi.rotation);
                  yenimermi.transform.localScale = tankObje.localScale;
                }


                break;
            case tankdurumlari.darbealma:
                if (darbeSayac > 0)
                {
                    darbeSayac -= Time.deltaTime;
                } 
                if(darbeSayac <= 0)
                {
                    gecerlidurum=tankdurumlari.hareketetme;
                    mayinbirakmaSayac = 0;
                    if (yenildimi)
                    {
                        tankObje.gameObject.SetActive(false);
                        Instantiate(tankpatlamaEfecti,transform.position,transform.rotation);
                        gecerlidurum = tankdurumlari.sonaerdi;
                    }
                }
                break;
            case tankdurumlari.hareketetme:
                if(yonuSagmi)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x > sagHedef.position.x)
                    {  
                        tankObje.localScale =new Vector3(1,1,1);

                        yonuSagmi = false;
                        hareketetidurdurFNC();
                    }
                }
                else
                {
                    tankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x < solHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        yonuSagmi = true;
                        hareketetidurdurFNC();
                    }
                }
                mayinbirakmaSayac -=Time.deltaTime;
                if(mayinbirakmaSayac <= 0)
                {
                    mayinbirakmaSayac = mayinnirakmaSuresi;
                    Instantiate(mayinObje, mayinMerkezNoktasi.position, mayinMerkezNoktasi. rotation);
                }
                break;

        }
        if (Input.GetKeyDown(KeyCode.R)) {
            darbealFNC();
        }
    }

    public void darbealFNC()
    {
        
        gecerlidurum = tankdurumlari.darbealma;
        darbeSayac = darbeSuresi;
        anim.SetTrigger("vurma");
        mayinController[] mayinlar = FindObjectsOfType<mayinController>();

        if(mayinlar.Length > 0)
        {
            foreach (mayinController bulunanmayin in mayinlar)
            {
                bulunanmayin.patlamaFNC();
                   
            }
        }
        candurumu--;
      if(candurumu<=0)
        {
            yenildimi = true;

        }
        else
        {
            mermiAtmaSuresi /= mermisuresiarttir;
            mayinnirakmaSuresi /= mayinbirakmasuresiarttir;
        }
    }
    public void hareketetidurdurFNC()
    {
        tankEziciKutu.SetActive(true);
        gecerlidurum = tankdurumlari.atesetme;
        mermiAtmasayac = mermiAtmaSuresi;
        anim.SetTrigger("dur");
    }
}
