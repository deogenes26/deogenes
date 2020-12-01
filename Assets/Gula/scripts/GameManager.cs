using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Vida vidinha;
    Fome morrerdefome;
    public Vector2 lastCheckpointpos;
    public  GameObject uiMorte;
   
    public  GameObject uiganhou;
    bool ispaused = false;


    public static GameManager instance;
   void Awake()
    {
        if(instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
      
        vidinha = FindObjectOfType<Vida>();
        morrerdefome = FindObjectOfType<Fome>();
        
    }
           
   public  void CheckPoint()
    {
        ispaused = true;
         if(ispaused)
        {
            Time.timeScale = 0;
            uiMorte.SetActive(true);
        }
      
        
    }

    public  void ChamaDenovo()
    {
        Time.timeScale = 1;
        uiMorte.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                 
    }
    public void Vitoria()
    {
        Time.timeScale = 0;
        uiganhou.SetActive(true);
    }
    public void Sair()
    {
        Application.Quit();
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #endif

    }
}
