using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum estados 
{
   menu,
   jugando,
   terminado

}
public class estado : MonoBehaviour
{

    public estados modo = estados.menu;
    public static estado comoEstoy;
  

    void Awake()
    {
        comoEstoy = this;
    }
    void Start()
    {
      
    }

    public void menu()
    {
       cambiaEstado(estados.menu);
    }

    public void jugando()
    {
        cambiaEstado(estados.jugando);
    }

    public void terminado()
    {
        cambiaEstado(estados.terminado);
    }

    public void cambiaEstado(estados nuevoEstado)
    {
        if (nuevoEstado == estados.menu)
        {
            modo = estados.menu;
        }

        if (nuevoEstado == estados.jugando)
        {
            modo = estados.jugando;
            juego.queMuestroEnJuego.pantallas();
        }

        if (nuevoEstado == estados.terminado)
        {
            modo = estados.terminado;
        }





    }


}
