using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{

    private float ancho;
    private float alto;
    private Vector2 coor;
    private Vector3 coor2;
    private GameObject back;
    public float posy;
    public float posx;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        ancho = Screen.width;
        alto = Screen.height;

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(-Time.deltaTime*vel,0,0);

       
        coor = Camera.main.WorldToScreenPoint(this.transform.position);

        
        back = GameObject.Find("BackGround");


        if (coor.x < (ancho + ancho / 6.5f) * -1)
        {

            coor2 = Camera.main.ScreenToWorldPoint(new Vector3(coor.x + Screen.width*2 , coor.y, this.transform.position.z));

            this.transform.position = new Vector3(coor2.x, coor2.y,1);
        }
        

    }
}
