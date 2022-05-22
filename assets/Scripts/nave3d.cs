using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave3d : MonoBehaviour
{

    private float xx,yy,zz;
    private int division,veloz=3;
    private Vector2 posix;
    bool avanza;
    GameObject obj;
    private float[] pos = new float[6];

    // Start is called before the first frame update
    void Start()
    {
        division = Random.Range(0,5); // para checar hasta que posicion de la pantalla avanzara la nave
        
        avanza = true; //para checar que la nave avance
        obj = this.transform.GetChild(2).gameObject; // encuentra objeto para detectar colision de objeto 3d con 2d
        obj.SetActive(false); //desactiva objeto para detectar colision 3d 2d

        //llenamos posiciones
        pos[0] = Screen.width * .138f;
        pos[1] = Screen.width*.27f;
        pos[2] = Screen.width*.46f;
        pos[3] = Screen.width * .69f;
        pos[4] = Screen.width * .85f;
        pos[5] = Screen.width * .95f;

    }

    // Update is called once per frame


    void Update()
    {
        
        

        if (avanza == true)//nave 3d avanza hasta posicion de girar
        {
            transform.Translate(new Vector3(veloz, 0f, 0f) * Time.deltaTime); //nave 3d avanza hasta posicion de girar

            posix = Camera.main.WorldToScreenPoint(this.transform.position); // transforma posicion de nave en mundo 3d a posicion pantalla

        }
        else //nave comienza a girar y aumenta su escala para colisionar con avion
        {
            xx += .02f * Time.deltaTime; // aumenta x,y,z escalas
            yy += .02f * Time.deltaTime;
            zz += .02f * Time.deltaTime;

            transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime); //vuela para arriba miemtras gira
            
            this.transform.Rotate(0,-50 * Time.deltaTime,0); // rota nave mientras va a colisionar

            this.transform.localScale = new Vector3(this.transform.localScale.x+xx, this.transform.localScale.y + yy, this.transform.localScale.z + zz);
            //cambia la escala de la nave
            
            
            if (xx>.02f) //activa objeto para medir la colision entre nave 3d y avion
            {
                obj.SetActive(true);
            }
            

        }


        if (posix.x < pos[division] && avanza == true) // se activa cuando la nave llega al punto donde va a girar
        {
            avanza = false;
            Destroy(this.gameObject,1.1f);
           
        }

        if (Avion.datosAvion.porcientov <= 1 )
        {
           Destroy(this.gameObject, 0);
        }

    
    }

}
