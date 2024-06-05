using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EfectoFade : MonoBehaviour
{
    public Image pantallaNegra;
    public Canvas canvasFade;
    public GameObject miCanvas;

    

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Color colorAux = pantallaNegra.color;
        colorAux.a = 0;
        pantallaNegra.color = colorAux;
    }

    public void EmpezarPartida()
    {
        canvasFade.sortingOrder = 2;
        StartCoroutine("TransicionFade");
    }

 

    IEnumerator TransicionFade()
    {
        while (pantallaNegra.color.a < 1)
        {
            float valor = pantallaNegra.color.a;
            valor += 0.05f;
            Color colorAux = pantallaNegra.color;
            colorAux.a = valor;
            pantallaNegra.color = colorAux;

            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadSceneAsync("Level 1");
        yield return new WaitForSeconds(1f);

        while (pantallaNegra.color.a > 0)
        {
            float valor = pantallaNegra.color.a;
            valor -= 0.05f;
            Color colorAux = pantallaNegra.color;
            colorAux.a = valor;
            pantallaNegra.color = colorAux;

            yield return new WaitForSeconds(0.05f);
        }

        miCanvas.gameObject.SetActive(false);
        canvasFade.sortingOrder = 0;
        yield return null;
    }

}
