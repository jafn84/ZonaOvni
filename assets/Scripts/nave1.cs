using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nave1 : MonoBehaviour
{
    float angulox = 1.5f;
    float anguloy = 1.5f;
    float vel;
    bool bajaVel = true;
    bool sumay = false;
    bool moviendo = true;
    bool vivo = true;
    Animator anima;
    AudioSource audio;
    public AudioClip explo;



   

    private void OnTriggerEnter2D(Collider2D coli)
    {

        if (vivo == true)
        {
            if (coli.tag == "bala" || coli.tag == "misil")
            {
                estaVivo();
            }

            if (coli.tag == "avion")
            {

                Avion.datosAvion.porcientov = Avion.datosAvion.porcientov - 10;
                Avion.datosAvion.vida.text = Avion.datosAvion.porcientov.ToString();

            }

            if (Avion.datosAvion.porcientov <= 0)
            {

                moviendo = false;
                audio.PlayOneShot(explo);
                anima.SetBool("explota", true);
                Avion.datosAvion.puntosv = Avion.datosAvion.puntosv + 1;
                Avion.datosAvion.puntos.text = Avion.datosAvion.puntosv.ToString();
                Destroy(this.gameObject, .89f);

            }

        }

    }

    public void estaVivo() 
    {
        moviendo = false;
        audio.PlayOneShot(explo);
        anima.SetBool("explota", true);
        Avion.datosAvion.puntosv = Avion.datosAvion.puntosv + 1;
        Avion.datosAvion.puntos.text = Avion.datosAvion.puntosv.ToString();

        Destroy(this.gameObject, .89f);

        vivo = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        vel = Random.Range(.10f, .32f);
        anima = this.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {

        
           
            if (bajaVel == true)
            {
                vel -= .01f;
            }

            if (vel < 0f && bajaVel == true)
            {
                bajaVel = false;
                vel = Random.Range(.05f, .3f);
                sumay = true;
            }

            if (sumay == true)
            {
                anguloy += .1f;
            }


        if (moviendo == true)
        {
            this.transform.position = new Vector3(this.transform.position.x - Mathf.Cos(angulox) * vel, this.transform.position.y + Mathf.Sin(anguloy) * vel, 0);

        }
    }
}
