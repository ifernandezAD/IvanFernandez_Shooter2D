using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuerte : MonoBehaviour
{
    public GameObject enemigo;

    //Añado el contador,su limite y dos variables para los margenes de su valor aleatorio

    public float contador;
    public float contadorLimite;

    public int min;
    public int max;



    //Dirección de los enemigos
    public Vector3 dirSpawn = Vector3.right;

    
    void Update()
    {
        contador = contador + Time.deltaTime;

        if (contador > contadorLimite)
        {
            GameObject enemigoClon = (GameObject)Instantiate(enemigo, this.transform.position, this.transform.rotation);
            enemigoClon.GetComponent<IAEnemigoFuerte>().dirEnemigo = dirSpawn;

            contador = 0;
            contadorLimite = Random.Range(min, max);

        }

    }
}

