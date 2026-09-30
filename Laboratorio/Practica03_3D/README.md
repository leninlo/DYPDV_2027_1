# Práctica 3: Física, Colisiones e Interacción

**Ruta:** `/Laboratorio/Practica03_3D_/`  
**Curso:** Desarrollo de Videojuegos 3D

##  Instrucciones de Ejecución
1. Abre **Unity Hub**.
2. Selecciona **Open** y navega hasta la carpeta `/Laboratorio/Practica03_3D_`.
3. Una vez dentro del editor, dirijete a proyectos.
4. Selecciona la carpeta Assets y navega hasta `/Scena/Practica03.unity`.
5. Haz clic en el botón **Play** (▶️) en la barra superior.
##  Pruebas
6. Selecciona la pantalla Game.
7. A continuación estaras en el escenario dle juego.
8. El juagador puede moverse co las teclas especiales up, down left y rigth.
9. Ahora acercate a las esferas de color amarillo, nota que las puedes recoger.
10. Nota que los cubos negros son cubos que puedes empujar.

##  Notas
Implemente dos scips de más: el primero es para signarle un material a las clases que hereden de un padre:
```csharp
public class AplicarMaterialAHijos : MonoBehaviour
{
    public Material materialComun;

    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.material = materialComun;
        }
    }
}
```
Esto en realidad no estan necesario, pero es bueno saber que puedes asignar el color de esta manera.

El segundo se  llama plataforma movil, que esta inspirado en Movimiento Cubo. Esta puede desplazar un objeto en cualquier dirección, de hecho por eso usa el vetor direccionMovimineto es publico, ya que desde ahi poodemos decidir hacia donde queremos que se mueva.
using UnityEngine;
```csharp
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
        transform.position += direccionMovimiento.normalized *
                             velocidad *
                             direccion *
                             Time.deltaTime;

        float desplazamiento =
            Vector3.Dot(transform.position - posicionInicial,
                        direccionMovimiento.normalized);

        if (desplazamiento >= distancia || desplazamiento <= 0)
        {
            direccion *= -1;
        }
    }
}
```
Sin embargo ahora faltan varios factores por implementar, por ejemplo, que el objeto se mueva junto con la plataforma.

Cabe resaltar dos componentes importantes:
1. **Box Codiller** te permite detectar coliciones entre objetos, con ellos puedes hacer que los objetos no puedan ser atravesados. Hay que destacar el atributo `Is tigger`, este lo que hace en cado de que no este activado es que el objeto tenga coliciones fisicas normales, sin embargo cuando esta activo se suele usar para mover al objeto y dejar el paso libre(Como la puerta automatica). En el caso de la plataforma movible se usó IsTigger= false ya quede esta manera el jugador no atravezara la plataforma, sino que podra quedarse ahí ariba.
2. **RigyBody** permite hcaer simulaciones fisicas, por ejemplo que el objeto pueda tener velocidd, ser empujado, caer por gravedad, etc. Esto fue de suma importancia para agregar fisica a los objetos. En el caso de la plataforma en movimiento se hace uso de ese componete para que tenga movimiento y ademas se uso el atributo Is Kinematic = true . 
 Un atributo muy impotante para este componente es `Is Kinematic`, ya que si esta en true, este te permiete manejar la fisica del objeto por medio de scripts, de otro modo lo sotros atributos activos del componente le afectaran al objeto.