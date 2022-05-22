using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour // esta clase se encara de poner en el escenario los personajes y pantallas.
{
   public List<GameObject> personajes = new List<GameObject>(); // Lista de objetos que aparecen en el escenario.
   
    public static juego queMuestroEnJuego; // variable estatica que se conecta con clase estado.

    public Canvas botones; // tiene la pantalla cuando el juego esta en accion.

    public Canvas botonComienza; // tiene la pantalla para del menu rpincipal.

    public Canvas botonTerminado; // tiene la pantalla para de GameOver.

    AudioSource musica;  // carga musica de fondo.

    public AudioClip mus; // reproduce el clip de musica.

    public bool comienza = false; // checa que el juego comience.

    public logicaAds ads; // accede al objeto para poner comerciales.

    public Sprite img,imgn; // contiene la grafica del fondo amanece.

    private bool fondo2 = false, lluviacae = false, lluviacae2 = false; //variables para controlar caidas de lluvia.

    public GameObject lluvia,muevolluvia, enemigos, mensajes; // contiene elobjeto que genera la lluvia particulas.

    public bool reiniciar;//para cuidar que el avion tome posicion nueva si se reinicia el juego.

   ParticleSystem.EmissionModule emis;// controla intensidad de lluvia.

    void Start()  
    {
        
        musica = GetComponent<AudioSource>();
        reiniciar = false;
        queMuestroEnJuego = this; //se iguala variable esatica asi mismo.  
        muestraComenzar();
      
    }

    public void pantallas()  // funcion que va a mostrar que nivel poner en pantalla al momento de empezar el juego.
    {
        // Instantiate(personajes[2]);

        if(estado.comoEstoy.modo == estados.jugando)  // checa el estado de juego por medio de la clase estatica estado.
        {
            stage1();
        }

    }

    public void stage1()//comienza el nivel 1
    {

        musica.Play();

        if (reiniciar == true) //si el juego se reinicia esta sera la posición del avión
        {
            Avion.datosAvion.transform.position = new Vector3(-8.1f, 0f, 0f); 
        }
        GameObject.Find("fondo").GetComponent<SpriteRenderer>().sprite = imgn;
        
        lluviacae = false;
        lluviacae2 = false;
        fondo2 = false;
        comienza = true;
        Avion.datosAvion.muriendo = false;
        Avion.datosAvion.porcientov = 100;
        
        Avion.datosAvion.puntos.text = Avion.datosAvion.puntosv.ToString();
        Avion.datosAvion.gameObject.SetActive(true);
        Avion.datosAvion.anima.SetBool("cero",false);
        GameObject.Find("BarraVida").transform.localScale = new Vector3(Avion.datosAvion.largoBarraV, 1, 1);
        GameObject.Find("block").transform.localScale = new Vector3(1, 1, 1);
        muestraBotones();
        comienza = true;
        
      

    }

    public void soltarEne()
    {
        enemigos = Instantiate(personajes[3]); //backgorund
        enemigos.name = "enemigos1";
        mensajes.SetActive(false);
    }

    void Update()
    {

        if (Avion.datosAvion.controlado == false && comienza == true)
        {
            Avion.datosAvion.transform.Translate(new Vector3(-6.90f, -2.5f, 0) * Time.deltaTime);
        }

        if (Avion.datosAvion.puntosv > 50 & lluviacae2 == false) // si los puntos pasan los 50 llueve fuerte
        {
            emis.rate = 300f;
            lluviacae2 = true;
        }


        if (Avion.datosAvion.puntosv > 20 & lluviacae == false) // si los puntos pasan 20 comienza a llover moderado
        {
            muevolluvia = Instantiate(lluvia);
            muevolluvia.name = "lloviendo";
            muevolluvia.transform.position = new Vector3(.77f, 6.578f, 3.03f);
            emis = muevolluvia.GetComponent<ParticleSystem>().emission;
            emis.rate = 60f;
           
            lluviacae = true;
        }

        if (Avion.datosAvion.puntosv > 40 & fondo2 == false) // si los puntos pasan 40 amanece
        {
            GameObject.Find("fondo").GetComponent<SpriteRenderer>().sprite = img;
            fondo2 = true;

            enemigos = Instantiate(personajes[3]); //backgorund
            enemigos.name = "enemigos2";
        }

    }


    public void muestraBotones() //activa pantalla de jugando  
    {
        botones.enabled = true;
        mensajes.SetActive(true);
        

        ApagaMuestraComenzar();
        ApagaMuestraTerminado();
      
    }

    public void muestraComenzar()  //activa pantalla de menu prncipal
    {
        botonComienza.enabled = true;
        ApagaMuestraBotones();
        ApagaMuestraTerminado();
        logicaAds.anuncios.pedirBanner();
      

    }

    public void muestraTerminado()  //activa pantalla de Terminado
    {
        logicaAds.anuncios.muestraint();
        logicaAds.anuncios.pedirreward();
        botonTerminado.enabled = true;
        ApagaMuestraBotones();
        ApagaMuestraComenzar();
        Avion.datosAvion.puntosv = 0;
        Destroy(GameObject.Find("lloviendo"),0f);
        Destroy(GameObject.Find("enemigos1"), 0f);
        Destroy(GameObject.Find("enemigos2"), 0f);
        Destroy(GameObject.Find("naveOvni(Clone)"), 0f);
        Destroy(GameObject.Find("nave3d(Clone)"), 0f);
        lluviacae2 = false;
        lluviacae = false;
        fondo2 = false;
        comienza = false;
        reiniciar = true; // si se reinicia el juego esta variable pone el avion en el lado izquierdo de la pantalla
        //logicaAds.anuncios.muestraint();

    }


    public void ApagaMuestraBotones() //desaactiva pantalla de jugando  
    {
        botones.enabled = false;
    }

    public void ApagaMuestraComenzar()  //desaactiva pantalla de menu prncipal
    {
        botonComienza.enabled = false;
    }

    public void ApagaMuestraTerminado()  //desaactiva pantalla de Terminado
    {
        botonTerminado.enabled = false;
    }


    public void quitaPersonajes()
    { 
          
    }


}
