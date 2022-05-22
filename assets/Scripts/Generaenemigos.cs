using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generaenemigos : MonoBehaviour
{

    public GameObject naveOvni;
    public GameObject nave3d;
    private Vector3 posIni, posIni2;

    // Start is called before the first frame update
    void Start()
    {
        posIni = new Vector3(Screen.width + Screen.width / 8, Random.Range(Screen.height/2,Screen.height/4),0);
        posIni2 = new Vector3(Screen.width + Screen.width / 8, Random.Range(Screen.height / 2, Screen.height / 2), 16.11f);

        InvokeRepeating("ponEnemigo", 2.0f, 2.0f);
        InvokeRepeating("ponNave3d", 4.0f, 4.0f);
    }

    // Update is called once per frame
   


    public void ponEnemigo() 
    {
        Instantiate(naveOvni).transform.position = Camera.main.ScreenToWorldPoint(posIni);
        
        
    }

    public void ponNave3d()
    {
        Instantiate(nave3d).transform.position = Camera.main.ScreenToWorldPoint(posIni2);

    }

}
