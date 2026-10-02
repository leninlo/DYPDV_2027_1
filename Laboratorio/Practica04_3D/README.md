# Práctica 3: Animación de Personaje (Animator, Estados y Root Motion)

**Ruta:** `/Laboratorio/Practica04_3D_/`  
**Curso:** Desarrollo de Videojuegos 3D

##  Instrucciones de Ejecución
1. Abre **Unity Hub**.
2. Selecciona **Open** y navega hasta la carpeta `/Laboratorio/Practica03_3D_`.
3. Una vez dentro del editor, dirijete a proyectos.
4. Selecciona la carpeta Assets y navega hasta `/Scena/Practica04.unity`.
5. Haz clic en el botón **Play** (▶️) en la barra superior.
##  Pruebas
6. Selecciona la pantalla Game.
7. A continuación estaras en el escenario dle juego.
8. El jugador puede moverse co las teclas especiales up, down left y rigth o w,s,a,d,.(No se recomienda mover el mouse dado que por ahora no se cuesnta con movimiento de rotacion sobre el jugador).
9. Nota que se ejecutan 4 animaciones del jugador, la primera es cuando esta quieto, la segunda es cuando camina, la tercera es cuando corre, y la ultima es cuando salta.

## Notas
Sobre la implemetacion de Root Motion, podemos observar que este es un atributo de el componente `Animator` que al aplicarlo nos da el root Motion de cada uno de nuestras animaciones importadas(pero pueden suceder cosas raras). En los atributos de las animaciones importadas estan 3 atributo importantes:
1. RootTransform Rotation 
2. Root Transform Position (Y), 
3. Root Transform Position (XZ).
Estas 3 tiene en común `Bake into pose` que ayuda a mantener la animacion en el mismo lugar, de modo que podemos mover al ojeto mediante un script, sin que su animacion le afecte. esto es importante, ya que por algo descargamos las animaciones con `In place` aplicado.
4.`Loop Time` que nos permite repetir la animacion siempre que la accion que la ejecute este activa. 
