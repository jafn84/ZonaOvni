using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{
    public Rigidbody2D fisica;

    // Start is called before the first frame update
    void Start()
    {
        fisica = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.velocity = new Vector2(-2f,0);

        if (this.transform.position.x < -24.42)
        { this.transform.position = new Vector3(11.78f, 4.93f, 0f); }
    }
}
