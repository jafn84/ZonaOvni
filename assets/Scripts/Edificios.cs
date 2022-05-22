using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificios : MonoBehaviour
{
    Rigidbody fisica;


    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        
    }
        // Update is called once per frame
        void Update()
    {
        this.transform.Translate( new Vector3(1, 0, 0) * Time.deltaTime * .5f);
    }
}
