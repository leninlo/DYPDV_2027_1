using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadActual = 0f;
    public float velocidadMax = 5f;
    public float aceleracion = 10f;

    public float velocidadVertical = 0f;
    public float gravedad = -20f;

    public float tiempoMaxSalto = 0.2f;
    private float tiempoSaltoActual = 0f;

    private float tiempoAnterior;

    private Jugador jugador;

    void Awake()
    {
        jugador = GetComponent<Jugador>();
    }

    void Start()
    {
        tiempoAnterior = Time.time;
    }

    void Update()
    {
        // DeltaTime manual
        float delta = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        // Movimiento horizontal
        float h = Input.GetAxis("Horizontal");

        velocidadActual += h * aceleracion * delta;

        velocidadActual = Mathf.Clamp(
            velocidadActual,
            -velocidadMax,
            velocidadMax
        );

        if (h == 0)
        {
            velocidadActual = Mathf.MoveTowards(
                velocidadActual,
                0f,
                aceleracion * delta
            );
        }

        transform.position += new Vector3(
            velocidadActual * delta,
            0,
            0
        );

        // Inicio del salto
        if (Input.GetAxis("Jump") > 0 && jugador.enSuelo)
        {
            velocidadVertical = 10f;
            jugador.enSuelo = false;
            tiempoSaltoActual = 0f;
        }

        // Salto prolongado
        if (!jugador.enSuelo && Input.GetAxis("Jump") > 0)
        {
            if (tiempoSaltoActual < tiempoMaxSalto)
            {
                velocidadVertical += 20f * delta;
                tiempoSaltoActual += delta;
            }
        }

        // Soltó la tecla
        if (Input.GetAxis("Jump") == 0)
        {
            tiempoSaltoActual = tiempoMaxSalto;
        }

        // Gravedad
        if (jugador.enSuelo)
        {
            velocidadVertical = 0f;
        }
        else
        {
            velocidadVertical += gravedad * delta;
        }

        // Movimiento vertical
        transform.position += new Vector3(
            0,
            velocidadVertical * delta,
            0
        );
    }
}