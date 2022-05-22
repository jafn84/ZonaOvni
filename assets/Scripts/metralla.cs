using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metralla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, .2f);
        
    }

    void Update()
    {
        this.transform.position = new Vector2(Avion.datosAvion.transform.position.x+1, Avion.datosAvion.transform.position.y-.55f);
    }

    // Update is called once per frame

}
