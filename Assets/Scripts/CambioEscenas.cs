using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void PantallaControles()
    {
        SceneManager.LoadSceneAsync("Controles");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadSceneAsync("MenuPrincipal");
    }
}
