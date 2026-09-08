using UnityEngine;

public class Jugador : MonoBehaviour{
    void Start(){
        Debug.Log(">>> SCRIPT JUGADOR ACTIVO EN LA ESCENA <<<");
    }
    // Se ejecuta cuando el objeto colisiona por primera vez con otro
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Colisión con: " + col.gameObject.name);
    }
                
    // Se ejecuta mientras el objeto sigue colisionando con otro
    void OnCollisionStay2D(Collision2D col){
        Debug.Log("Manteniendo colisión con: " + col.gameObject.name);
    }
}

