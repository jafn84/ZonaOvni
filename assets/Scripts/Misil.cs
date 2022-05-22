using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    LineRenderer linea;
    float rango = 1.5f; //variable para poner el rango de movimiento de la direccion del misil
    float ang = .1f;    // velocidad con la que se incrementa el angulo de la direccion del misil
    float ang2 = .03f;   //velocidad en que se mueve el vector de apunte
    bool arriba = true; //variable para saber si se le da una direccion positiva o negativa en el eje de la y
    float distancia = 1.2f;  //variable para medir el largo del vector para dar direccion
    float distanciav = 0.2f;  //variable para medir el largo del vector para dar direccion
    float ponVectorPunta = 0f; //variable para situar vector en la punta del misil
    bool avanza = false; // activa avance del misil
    bool noAng = false; //activa movimiento del vector de apunte
    float avanceAng = .09f; //velocidad a la que se mueve el misil
    public LayerMask mm;
    private Vector2 posMisil;
    private float retro;
   


    GameObject fuego;

    // Start is called before the first frame update
    void Start()
    {
       linea = this.GetComponent<LineRenderer>();

        linea.SetPosition(0,new Vector3(ponVectorPunta+this.transform.position.x,this.transform.position.y,0));

        retro = 0;

    }

    // Update is called once per frame
    void Update()
    {

        posMisil = Camera.main.WorldToScreenPoint(this.transform.position);
        
        limites();



        if (noAng == false)
        {
            angulo(); 
        }
       
               

        if (avanza == true)
        {
            yendo();        
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoxCollider2D b = this.GetComponent<BoxCollider2D>();

            if (b.OverlapPoint(wp)) 
            {
                noAng = true;
                avanza = true;
                transform.Rotate(new Vector3(0, 0, ang / .017f));
                fuego = this.transform.GetChild(0).gameObject;
                fuego.transform.localScale = new Vector3(1, 4.62f, 1);
                fuego.transform.position = new Vector3(fuego.transform.position.x, fuego.transform.position.y, 0);
                Destroy(this.GetComponent<LineRenderer>());
            }

        }
         

    }


    //funcion donde se muestra el vector de direccion en la punta del misil
    void angulo()  
    {
        linea.SetPosition(1, new Vector3(ponVectorPunta+this.transform.position.x+Mathf.Cos(ang) * distancia, this.transform.position.y+ Mathf.Sin(ang) * distancia, 0));

        

       
        if (ang > rango) { arriba = false; }
        if (ang < -rango) { arriba = true; }

        if (arriba == true) { ang+=ang2; } else { ang-=ang2; }
    }

    void yendo() 
    {
       this.transform.position= new Vector3(this.transform.position.x + Mathf.Cos(ang) * avanceAng , this.transform.position.y + Mathf.Sin(ang) * avanceAng, 0);

        //por si el misil tiene que detectar colisiones
      /*  Debug.DrawRay(new Vector3( this.transform.position.x , this.transform.position.y , 0), new Vector3( Mathf.Cos(ang) * distanciav,  Mathf.Sin(ang) * distanciav, 0), Color.red);

        if (Physics2D.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, 0), new Vector3(Mathf.Cos(ang) * distanciav, Mathf.Sin(ang) * distanciav, 0), distanciav,mm.value))
            {
            Debug.Log(this.gameObject.name+ "pego");
            }*/
        //avanceAng += .01f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="naves") 
        {
            Destroy(this.gameObject);
        }
    }

    public void limites()
    {
        if (posMisil.x < Screen.width / 10)
        {

            Destroy(this.gameObject);
        }

        if (posMisil.x > Screen.width)
        {

            Destroy(this.gameObject);
        }

        if (posMisil.y < Screen.height / 20)
        {

            Destroy(this.gameObject);
        }

        if (posMisil.y > Screen.height)
        {

            Destroy(this.gameObject);
        }

    }

}
