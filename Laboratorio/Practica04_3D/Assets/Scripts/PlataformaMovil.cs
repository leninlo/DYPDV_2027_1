using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector3 direccionMovimiento = Vector3.right;
    public float velocidad = 2f;
    public float distancia = 5f;

    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.position +=
            direccionMovimiento.normalized *
            velocidad *
            direccion *
            Time.deltaTime;

        float desplazamiento =
            Vector3.Dot(
                transform.position - posicionInicial,
                direccionMovimiento.normalized
            );

        if (desplazamiento >= distancia)
        {
            direccion = -1;
        }
        else if (desplazamiento <= 0)
        {
            direccion = 1;
        }
    }
}