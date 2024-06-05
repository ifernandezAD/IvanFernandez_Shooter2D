using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigoNormal : MonoBehaviour
{
    public float vel;

    
    //Dirección de movimiento por defecto
    public Vector3 dirEnemigo = Vector3.right;

    void Update()
    {
        this.transform.Translate(dirEnemigo * vel * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Barrera")
        {
            
            Destroy(this.gameObject);

        }
        
        if (other.gameObject.tag == "Metralla")
        {
           
            Destroy(this.gameObject);
            
        }

        
    }




}
