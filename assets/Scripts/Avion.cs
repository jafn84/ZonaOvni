using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avion : MonoBehaviour
{
    public static Avion datosAvion;
    public int velox;
    public int veloy;
    private Rigidbody2D fisica;
    public GameObject misil;
    private GameObject a;
    public GameObject m;
    private GameObject mc;
    public int veces=0;
    public GameObject bala;
    public int porcientov;
    public Text vida;
    public int puntosv;
    public Text puntos;
    AudioSource audio;
    public AudioClip clip;
    public AudioClip clipgolpe;
    private Vector2 posAvion;
    private float retro;
    public Animator anima;
    private bool golpeado = false;  //checa si golpearon el aviom'
    private float segundos = 0.5f;
    private float duratiempo = 1;
    public bool controlado = false , muriendo = false;
    public int quitar;
    public float largoBarraV;

    // Start is called before the first frame update
    void Start()
    {
        retro = .2f;
        datosAvion = this;
        velox = 8;
        veloy = 8;
        fisica = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        
        porcientov = 100;
     
        vida.text = porcientov.ToString();
        puntosv = 0;
        puntos.text = puntosv.ToString();

        anima = GetComponent<Animator>();
        anima.SetBool("golpe", false);
        anima.SetBool("cero", false);
        quitar = 3;
        largoBarraV = .3f;
    }

    // Update is called once per frame
    void Update()
    {
        posAvion = Camera.main.WorldToScreenPoint(this.transform.position);
       
      
        if (golpeado == true)
        {
            segundos += Time.deltaTime;
           

            if (segundos > duratiempo) 
            {
                segundos = 0;
                golpeado = false;
                anima.SetBool("golpe", false);
            }
        }


        if (muriendo == true)
        {
            segundos += Time.deltaTime;


            if (segundos > duratiempo)
            {
                segundos = 0;
                
                anima.SetBool("cero", false);
                Vector2 pospp = Camera.main.ScreenToWorldPoint(new Vector2(0-Screen.width/3,Screen.height/2));
                this.transform.position = pospp;
                controlado = false;
                muriendo = false;
                juego.queMuestroEnJuego.muestraTerminado();
            }
            
        }

        if(muriendo == false)
        { limites(); }
          /* veces++;
         a = Instantiate(misil);
         a.transform.position = new Vector3(Mathf.Cos(veces) + veces * .01f, Mathf.Sin(veces) + this.transform.position.y, 0);
         Destroy(a, .1f); */
    }

    //funcion que aparece misil
    public void misiles()
    {
        veces++;
        a = Instantiate(misil);
        a.name = "m" + veces;
        a.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,0);

    }


    public void metralla()
    {
        audio.PlayOneShot(clip);
        Instantiate(m).transform.position = new Vector2(this.transform.position.x + 1f, this.transform.position.y - .55f);
        
        Instantiate(bala).transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y - .55f);
    }

    //funciones para mover avion
    public void derecha()
    {
        fisica.velocity = new Vector2(1*velox,0*veloy);
    }

    public void izquierda()
    {
        fisica.velocity = new Vector2(-1*velox , 0*veloy);
    }

    public void arriba()
    {
        fisica.velocity = new Vector2(0*velox , 1*veloy);
    }

    public void abajo()
    {
        fisica.velocity = new Vector2(0*velox , -1*veloy);
    }


    public void sd()
    {
        fisica.velocity = new Vector2(1*velox , 1*veloy);
    }

    public void id()
    {
        fisica.velocity = new Vector2(1*velox , -1*veloy);
    }

    public void ii()
    {
        fisica.velocity = new Vector2(-1*velox , -1*veloy);
    }

    public void si()
    {
        fisica.velocity = new Vector2(-1*velox , 1*veloy);
    }
    //funciones para mover avion



    //situa misiles en circulo


    public void paro()
    {
        fisica.velocity = new Vector2(0,0);
    }

    public void limites()
    {
        if (posAvion.x <  Screen.width/10) 
        {
            
            this.transform.position = new Vector2(this.transform.position.x + retro, this.transform.position.y);
            controlado = true; //permite mover avion;
        }

        if (posAvion.x > Screen.width)
        {

            this.transform.position = new Vector2(this.transform.position.x - retro, this.transform.position.y);
        }

        if (posAvion.y < Screen.height/4)
        {

            this.transform.position = new Vector2(this.transform.position.x , this.transform.position.y + retro);
        }

        if (posAvion.y > Screen.height)
        {

            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - retro);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) // destruye el avion si coliciona anve 3d
    {
        if (collision.tag == "col3d" | collision.tag == "naves" && muriendo == false)
        {
            
            audio.PlayOneShot(clipgolpe);
            
            //transform.Translate(new Vector3(transform.position.x+1f, transform.position.y - 3f, 0f) * Time.deltaTime);

            porcientov = porcientov - (100 / quitar);

            vida.text = porcientov.ToString();

            if (porcientov <= 1 )
            {
                anima.SetBool("cero", true);
                muriendo = true;            
            }
            else 
            {
                anima.SetBool("golpe", true);
                golpeado = true;
            }

            

            GameObject.Find("block").transform.localScale = new Vector3(porcientov/100f,1,1);
        }
    }

}
