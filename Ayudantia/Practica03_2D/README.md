# Práctica 1: Física Manual de Movimiento y Salto

**Ruta:** `/Ayudantia/Practica02_2D`  
**Curso:** Desarrollo de Videojuegos 2D

##  Instrucciones de Ejecución
1. Abre **Unity Hub**.
2. Selecciona **Open** y navega hasta la carpeta `/Ayudantia/Practica02_2D`.
3. Haz clic en el botón **Play** (▶️) en la barra superior.

##  Pruebas
1. Selecciona Game
2. Selecciona lasa flecha derecha y la izquierda para mover al jugador
3. presiona la barra espaciadora para que el jugador salte.

## Justtificación de implementación:

### Variable jugador
 Para inicializar a la variable **jugador** de nuestra clase, usamos usar el metodo `GetComponent<>()`(metodo de unity) para obtener la refererencia a nuestro script Jugador(es decir, vincula nuestra clase actual con el script Jugador), de esto modo podremos saber si ej Jugador esta en el suelo o no. Otro aspecto importante es que para asignar esta referencia usamos 
 ```csharp 
 Awake()
 ```
 , cabe recalcar que a diferencia de 
 ```cssharp 
 Start()
 ```
 esta se utiliza para inicializar variables de referencias internas, tal como lo hicimos en este caso, también hay que tomar en cuenta que esta se realiza antes de `Start()` y además procesa el scrip sin importar si esta o no activo en el ispector(siempre y cuando forme parte de sus componentes del mismo GameObject, si no es parte del GameObject, entonces se usa `Start()` ).

 ### delta
 Esta variable es de suma importancia ya que representa una fracción del tiempo por cada frame, recordemos que `Update()` lo que hace es ejecutarse cada frame, asi que si queremos que el movimiento de nuestro Jugador se mantenga igual independientemente de los frames, entonces lo que hacemos es calcular `delta`. 
 
 Un ejemplo: Si una laptop corre a 120 fps, entonces cada frame dura aproximadamente 1/120 segundos: en general si corre a **n** fps, entonces cada frame dura 1/n segundos.

 Esto lo podemos logar Usando `Time.time` que devuelve el  tiempo actual (frame actual) y restandole el tiempo anterior(frame anterior).

 ### Moviemiento horizontal y vertical
 #### Hallando la dirección
 Para esto, Hacemos uso de la clase `Input` de Unity y usamos su metodo estatico `GetAxis(string axisName)`  que retorna el valor del eje virtual identificado por `axisName`, principalmente nos fijamos en **"Jump"**(para el salto) y en **"Horizontal"**(Para el moviento horizontal).
 - **"Jump"** : Si el boton de espacio esta presionado devuelve 1.0, de no estar presionado, devuelve 0.0.
 - **"Horizontal"**: Si devuelve 1.0 es porque detecta que que se mueva a la izquirrda, y se detecta -1.0 es porque se mueve a la derecha, detecta las fechas izquierda y derecha o las letras A y D.
 #### Cambio de posicion
  Para cambiar la posicion de un `GameObject` utilizamos la propiedad `position` de la transformacion de un GameObject, de modo que creamos un nuevo vector que se le suma al vector de la posicion en la que se encuentre el GameOject, `claseVector3(float x, float y, float z);`.
 ```cssharp 
        // Movimiento vertical
        transform.position += new Vector3(
            0,
            velocidadVertical * delta,
            0
        );
 ```
 como vemos en el ejemplo para el moviemineto vertical solo variamos la posicion en el eje **y**. para el horizontal es el eje **x**.
 #### Funciones matematicas

 Utilizamos dentro de la coleccion de funciones de `Mathf` 2 muy importantes: `public static float Clamp(float value, float min, float max);` que restringe un valor para que se mantenga en el intervalo. El otro es `public static float MoveTowards(float current, float target, float maxDelta);` que mueve un valor actual hacia un valor objetivo a una velocidad constante dada, además nunca sobrepasa el objetivo. De `MoveTowars()` se dá que el personaje frene hasta tener un velocidadActual de 0.
