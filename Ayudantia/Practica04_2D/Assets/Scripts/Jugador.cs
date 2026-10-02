using UnityEngine;

public class Jugador : MonoBehaviour{
    public bool enSuelo = false;
    void Start(){
        Debug.Log(">>> SCRIPT JUGADOR ACTIVO EN LA ESCENA <<<");
    }
    // Se ejecuta cuando el objeto colisiona por primera vez con otro
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
                
    // Se ejecuta mientras el objeto sigue colisionando con otro
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}

