using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaPausado : MonoBehaviour
{
    public bool pausado = false;
    public GameObject textoPausa;
    public GameObject luz;
    
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void PausarElJuego()
    {
        if (pausado == false)
        {
            Time.timeScale = 0;
            pausado = true;
            textoPausa.gameObject.SetActive(true);
            luz.gameObject.SetActive(false);
            
      
        }
        else
        {
            Time.timeScale = 1;
            pausado = false;
            textoPausa.gameObject.SetActive(false);
            luz.gameObject.SetActive(true);
            

        }
    }
}
