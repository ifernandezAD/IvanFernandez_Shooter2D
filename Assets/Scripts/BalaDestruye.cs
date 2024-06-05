using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDestruye : MonoBehaviour
{
    public int loot;
    public GameObject hamburguesa;
    public GameObject llave1;
    public GameObject llave2;
    public GameObject llave3;

    public bool llaveInv1;
    public bool llaveInv2;
    public bool llaveInv3;

    private SistemaPuntuacion sistemaPuntuacion;
    private Animator animPuntuar;

   

    private void Start()
    {
       sistemaPuntuacion = GameObject.Find("Puntuacion UI").GetComponent<SistemaPuntuacion>();
        animPuntuar = GameObject.Find("Puntuacion UI").GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            Destroy(other.gameObject);
           

            //Puntuar al matar enemigos
            sistemaPuntuacion.SumarPuntuacion(100);
            animPuntuar.SetTrigger("Puntuar");

           loot= Random.Range(1, 30);

            if(loot==1 || loot==2 || loot==3 )
            {
                Instantiate(hamburguesa, this.transform.position, this.transform.rotation);
            }
            if (loot ==4 && llaveInv1==false )
            {
                Instantiate(llave1, this.transform.position, this.transform.rotation);
                llaveInv1 = true;
            }
            else if (loot == 5 && llaveInv2 == false)
            {
                Instantiate(llave2, this.transform.position, this.transform.rotation);
                llaveInv2 = true;
            }
            else if (loot == 6 && llaveInv3 == false)
            {
                Instantiate(llave3, this.transform.position, this.transform.rotation);
                llaveInv3 = true;
            }


        }

        Destroy(this.gameObject);
    }
}
