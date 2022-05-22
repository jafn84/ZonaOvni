using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navematriz : MonoBehaviour
{

    bool dir;
    Animator anima;
    AudioSource caja;
    public AudioClip explo;

    public GameObject nave;
   // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        caja = GetComponent<AudioSource>();
        InvokeRepeating("generaNaves",2.0f,2.0f);
        dir = true;
    }

    private void Update()
    {

        direccion();

        if (Avion.datosAvion.porcientov <= 0)
        { 
          Destroy(this.gameObject, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        
        if (col.tag == "misil")
        { 
            Destroy(this.gameObject, .89f);
            anima.SetBool("explota", true);
            caja.PlayOneShot(explo);
        }
    }
     


    

    void generaNaves()
    {
        Instantiate(nave).transform.position = this.transform.position;
    }


    public void direccion() 
    {
        if (this.transform.position.x < -3) 
        {
            dir = false;
        }

        if (this.transform.position.x > 4)
        {
            dir = true;
        }

        if (dir == true)
        {
            this.transform.position = new Vector2(this.transform.position.x - .1f, this.transform.position.y);
        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x + .1f, this.transform.position.y);
        }
    }


   


}
