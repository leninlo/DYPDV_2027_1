# Práctica 2: Terreno y Navegación (NavMesh)

**Ruta:** `/Laboratorio/Practica02_3D_/`  
**Curso:** Desarrollo de Videojuegos 2D

##  Instrucciones de Ejecución
1. Abre **Unity Hub**.
2. Selecciona **Open** y navega hasta la carpeta `/Laboratorio/Practica02_3D_`.
3. Una vez dentro del editor, dirijete a proyectos.
4. Selecciona la carpeta Assets y navega hasta `/Scena/Practica02.unity`.
5. Haz clic en el botón **Play** (▶️) en la barra superior.
##  Pruebas
6. Selecciona la pantalla Game.
7. A continuación podrás obsevar al Agent en movimiento.
8. Presiona cualquier parte con el mouse y verás como el Agent se dirige hacia ese lugar.

##  Notas
NavMesh es un sistema de Unity que permite que los personajes encuentren rutas de forma automatica mediante la IA.
Lo importante de esto es que dado nuestro Agente(juagdor), se puede detectar en que parte hay obstaculos Y EN CONSECUENCIA por donde no puede pasar.
Para ello se hace uso de dos componentes importantes:
1. NavMesh Surface: es el encargado de analizar a los objetos en la escena y mediante una malla decide que parte son navegables(donde el Agente puede transitar). Es importante recordar que el boton `Bake` es el encargado de ejecutar estas acciones(así que si añades o mueves un objeto a tu escenario, recuerda siempre precionar `Bake`).
2. NavMesh Agent: se usa en los personajes para que puedan detectar la malla creada por NavMeshSurface.