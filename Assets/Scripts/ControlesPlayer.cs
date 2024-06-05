using UnityEngine;

public class ControlesPlayer : MonoBehaviour
{
    //Altura del salto y velocidad del player
    public float salto;
    public float vel;
    //Variable que guarda si toca el suelo o no
    public bool contactoSuelo = false;

    public Rigidbody miRigid;

    public GameObject bala;
    public GameObject canon;
    public float velBala;
    //Variable que guarda la dirección de disparo, inicialmente a la derecha
    public Vector3 dirBalas = Vector3.right;

    public Animator miAnim;
    

    void Start()
    {
        miRigid = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Salto();
        ControlesMovimiento();
        Disparar();
        AnimacionAndar();
    }

    void Salto()
    {
        contactoSuelo = false;
        RaycastHit resultadoRayo;
        if (Physics.Raycast(this.transform.position, Vector3.down, out resultadoRayo, 1f))
        {
            if (resultadoRayo.transform.tag == "Suelo")
            {
                contactoSuelo = true;

            }
        }
        if (Input.GetKeyDown(KeyCode.W) && contactoSuelo == true)
        {
            miRigid.velocity = Vector3.up * salto;
        }
    }

    void ControlesMovimiento()
    {

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-vel * Time.deltaTime, 0, 0, Space.World);
            //Modifico la escala a negativo para dar el efecto de giro
            this.transform.localScale = new Vector3(-1f, 1.5f, 1f);
            dirBalas = Vector3.left;

            

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(vel * Time.deltaTime, 0, 0, Space.World);
            this.transform.localScale = new Vector3(1f, 1.5f, 1f);
            dirBalas = Vector3.right;

          
        }
    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
        GameObject balaClon = (GameObject)Instantiate(bala,canon.transform.position, this.transform.rotation);
        balaClon.GetComponent<Rigidbody>().velocity = dirBalas * velBala;

            miAnim.SetTrigger("Disparo");


            Destroy(balaClon, 2f);
        }
    }

    void AnimacionAndar()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            miAnim.SetBool("Andar", true);
        }
        else
        {
            miAnim.SetBool("Andar", false);
        }
       
    }
}
