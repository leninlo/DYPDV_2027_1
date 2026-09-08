using UnityEngine;

public class ControlJugador : MonoBehaviour{
    private Rigidbody2D rb;

    private void Awake(){
        // Guardamos la referencia al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // Movimiento horizontal (flechas izquierda/derecha)
        float h = Input.GetAxis("Horizontal");
        if (h != 0){
            Debug.Log("Movimiento horizontal: " + h);
        }

        // Salto
        if (Input.GetButtonDown("Jump")){
            Debug.Log("Salto detectado");
        }
    }

    void FixedUpdate(){
        // Movimiento horizontal para caminar
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * 5f, rb.velocity.y);
    }
}