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

    //Practica 3
    public float desaceleracion = 8f;
    public float gravedadCaida = -30f;
    public float tiempoCoyote = 0.1f;
    public float tiempoBufferSalto = 0.1f;
    private float coyoteTimer = 0f;
    private float bufferTimer = 0f;
    // Preparando parctuca 4
    public bool estaCaminando;
    public bool estaSaltando;
    public bool estaCayendo;

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
            if (velocidadActual > 0)
            {
                velocidadActual += -desaceleracion * delta;
            }
            else if (velocidadActual < 0)
            {
                velocidadActual += desaceleracion * delta;
            }
            if (Mathf.Abs(velocidadActual) < 0.1f)
            {
                velocidadActual = 0;
            }
        }

        // Añaniendo CoyoteTime
        if (jugador.enSuelo)
            coyoteTimer = tiempoCoyote;
        else
            coyoteTimer -= delta;



        // Inicio del salto
        if (Input.GetAxis("Jump") > 0 && jugador.enSuelo)
        {
            velocidadVertical = 10f;
            jugador.enSuelo = false;
            tiempoSaltoActual = 0f;
        }

        // Jump Buffering
        if (Input.GetAxis("Jump") > 0)
            bufferTimer = tiempoBufferSalto;
        else
            bufferTimer -= delta;

        // Salto con coyoteTime
        if (bufferTimer > 0 && coyoteTimer > 0)
        {
            velocidadVertical = 10;
            jugador.enSuelo = false;
            bufferTimer = 0;
            tiempoSaltoActual = 0;
            coyoteTimer = 0;
        }

        // Salto prolongado
        if (!jugador.enSuelo && Input.GetAxis("Jump") > 0)
        {
            if (tiempoSaltoActual < tiempoMaxSalto)
            {
                velocidadVertical += -gravedad * delta;
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
            // Gravedad mejorada
            if (velocidadVertical < 0)
                velocidadVertical += gravedadCaida * delta;
            else
                velocidadVertical += gravedad * delta;
        }

        // Movimiento vertical y horizontal
        transform.position += new Vector3(
        velocidadActual * delta,
        velocidadVertical * delta,
        0
        );

        // Animacion del personaje
        estaCaminando = Mathf.Abs(velocidadActual) > 0.1f;
        estaSaltando = velocidadVertical > 0.1f;
        estaCayendo = velocidadVertical < -0.1f;

    }
}