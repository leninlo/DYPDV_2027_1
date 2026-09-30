using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalaCubo : MonoBehaviour
{
    public float velocidadCrecimiento = 2.0f;
    public float escalaMinima = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one * velocidadCrecimiento * Time.deltaTime;
        }else
        {
            transform.localScale = Vector3.Max(transform.localScale - Vector3.one * velocidadCrecimiento * Time.deltaTime, Vector3.one * escalaMinima);
        }  
    }
}
