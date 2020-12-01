using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fome : MonoBehaviour
{
    // Start is called before the first frame update

    public Image estomago;
   public float fome = 100f;
    
    

    private void Update()
    {
        UpdateEstomago();
    }
     void UpdateEstomago()
    {
        fome -= Time.deltaTime;
       
        
        estomago.fillAmount = fome / 100 ;
        if(fome <= 0)
        {
            GameManager.instance.CheckPoint();
        }
        


    }
   

}
