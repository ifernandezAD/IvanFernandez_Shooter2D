using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class SistemaVidas : MonoBehaviour
{
  
    public GameObject Afro;
    public float escala;
    public int bomba;
    public GameObject efecto;

    public AudioSource sonidoHit;

    private SistemaPuntuacion sistemaPuntuacion;

    //Variables de barra salud
    public Image barraVida;
    public Animator animVibrar;
    public int vida = 3;
    public int topeVida = 3;

    //Variables del Meta
    public PostProcessVolume metaDaño;

    //Variables de la barra de empacho
    public Image barraEmpacho;
    public int empacho = 0;
    public int topeEmpacho = 10;
    public Animator empachoCritico;
    private Animator puntuacionEmpacho;


    void Start()
    {
        sistemaPuntuacion = GameObject.Find("Puntuacion UI").GetComponent<SistemaPuntuacion>();
        puntuacionEmpacho = GameObject.Find("Puntuacion UI").GetComponent<Animator>();
        bomba = 0;
    }
    void Update()
    {
        float vidaBarra = (float)vida / topeVida;
        barraVida.fillAmount = vidaBarra;

        float empachoBarra = (float)empacho/10;
        barraEmpacho.fillAmount = empachoBarra;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            --vida;
            Destroy(other.gameObject);
            sonidoHit.Play();
            animVibrar.SetTrigger("HitEnemigo");

            EstadoCritico();
            Muerte();
        }

        if (other.gameObject.tag == "Hamburguesa")
        {
            ++vida;
            ++empacho;
            Destroy(other.gameObject);
            metaDaño.isGlobal = false;

            Afro.transform.localScale = new Vector3(escala, 0.5f * escala, escala);
            Afro.transform.Translate(0, 0.37f, 0);
            ++escala;
            ++bomba;
            if (bomba == 10)
            {
                Afro.SetActive(false);
                Instantiate(efecto, this.transform.position, this.transform.rotation);
                sistemaPuntuacion.SumarPuntuacion(10000);
                puntuacionEmpacho.SetTrigger("Puntuar Empacho");
                
            }
            if (empacho == 9)
            {
                empachoCritico.SetBool("Empachado",true);
            
            }
            else 
            {
                empachoCritico.SetBool("Empachado", false);

            }

        }
        if (vida >= topeVida)
        {
            vida = topeVida;

        }
    }

    void Muerte()
    {
        if (vida == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Derrota");
            
        }
    }

    void EstadoCritico()
    {
        if (vida == 1)
        {
            metaDaño.isGlobal = true;
           
        }
       
    }
}
