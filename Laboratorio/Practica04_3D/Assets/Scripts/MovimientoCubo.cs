using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{
    public float velocidad = 2.0f;
    public float minX = 0.0f;
    public float maxX = 10.0f;
    private int direccion = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidad * direccion * Time.deltaTime);
        if(transform.position.x >= maxX || transform.position.x <= minX)
        {
            direccion *= -1;
        }    
    }
}
