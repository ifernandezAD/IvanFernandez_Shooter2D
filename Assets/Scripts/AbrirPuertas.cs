using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbrirPuertas : MonoBehaviour
{

    public bool tengoLlave1;
    public bool tengoLlave2;
    public bool tengoLlave3;

    public GameObject llave1;
    public GameObject llave2;
    public GameObject llave3;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Llave1")
        {
            tengoLlave1 = true;
            Destroy(other.gameObject);
            llave1.SetActive(true);

        }
        if (other.gameObject.tag == "Llave2")
        {
            tengoLlave2 = true;
            Destroy(other.gameObject);
            llave2.SetActive(true);
        }
        if (other.gameObject.tag == "Llave3")
        {
            tengoLlave3 = true;
            Destroy(other.gameObject);
            llave3.SetActive(true);
        }

        if(other.gameObject.tag=="Puerta1" && tengoLlave1 == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Puerta2" && tengoLlave2 == true)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Puerta3" && tengoLlave3 == true)
        {
            Destroy(other.gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}


