using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neverecta : MonoBehaviour
{
    float angulox = 1.2f;
    float anguloy = 1.5f;
    float vel;
    bool bajaVel = true;
    bool sumay = false;
    bool moviendo = true;
    bool vivo = true;
    Animator anima;
    AudioSource audio;
    public AudioClip explo;
    private float velox;
    private Vector2 xy;





    private void OnTriggerEnter2D(Collider2D coli)
    {

        if (vivo == true)
        {
            if (coli.tag == "bala" || coli.tag == "misil" || coli.tag == "avion")
            {
                estaVivo();
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
        vel = Random.Range(.10f, .30f);
        anima = this.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        velox = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Avion.datosAvion.porcientov <= 1)
        {
            Destroy(this.gameObject, 0);
        }

        xy = Camera.main.WorldToScreenPoint(this.transform.position);


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
            this.transform.position = new Vector3(this.transform.position.x - Mathf.Cos(angulox) * vel , this.transform.position.y + Mathf.Sin(anguloy) * vel, 0);
        }

        if (xy.x < -20)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
