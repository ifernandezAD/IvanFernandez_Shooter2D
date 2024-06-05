using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaPuntuacion : MonoBehaviour
{

    public int puntuacion = 0;
    Text textoPuntuacion;
    
    void Start()
    {
        textoPuntuacion = GetComponent<Text>();
    
    }


    public void SumarPuntuacion(int valor)
    {
        puntuacion+= valor;
        textoPuntuacion.text = "Score  " + puntuacion;
        
    }
}
