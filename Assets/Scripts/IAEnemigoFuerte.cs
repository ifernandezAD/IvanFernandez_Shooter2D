using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigoFuerte : MonoBehaviour
    
{
    public int hits;
    public float vel;

    //Dirección de movimiento por defecto
    public Vector3 dirEnemigo = Vector3.right;



    void Update()
    {
        this.transform.Translate(dirEnemigo * vel * Time.deltaTime, Space.World);
        if (hits == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bala")
        {
            --hits;
        }
        if (other.gameObject.tag == "Metralla")
        {
            Destroy(this.gameObject);
        }

    }
}
