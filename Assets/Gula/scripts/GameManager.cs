using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Vida vidinha;
    Fome morrerdefome;
    public Vector2 lastCheckpointpos;
    
    
    static GameManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
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

    
    
   public static void CheckPoint()
    {
      
       
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
            
          
    }
    
}
