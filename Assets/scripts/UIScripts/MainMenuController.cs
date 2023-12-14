using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public string sahneAdi;

    

    private void Start()
    {
        
    }

  
    public void OyununaBasla()
    {
        SceneManager.LoadScene(sahneAdi);
    }
    public void oyundanCikis()
    {
        Application.Quit();
    }
    
}
