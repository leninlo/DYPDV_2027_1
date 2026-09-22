# Implementación de un Juego Tipo Pong en OpenGL

Para esta practica se uso `GLUT`, un kit de herramientas independiente del sistema de ventanas utilizadO para escribir programas en OpenGL. Se usa principalmente en el aprendizaje y la exploración de la programación con OpenGL.

Algo muy importante a tomar en cuenta es que la API portatil que proporciona `GLUT`  funciona tanto en laptops con arquitectura **x86(win32)** como en estaciones de trabajo **x11**. 
> La arquitectura de los procesadores hoy en dia, por lo general funcionan en x64(64 bits), sin embargo pueden ejecutar codigo en x86, asi que en tema de compatibilidad no hay problema alguno.



# Compilación del proyecto


# Implementacion:

El problema actual de la implementacion es que para que el movimiento vaya fluido se uso un contador de tiempo que hace que el movimiento vaya fluido, y esto funciona perfecto para una sola paleta, sine embargo al implementar la otra ocurre un error. se supone que si presiono w y up las dos paletas deberian de moverse al mismo tiempo, cosa que no pasa, la razon se debe a que actualmente se esta usando la version de glut 3.3 que solo cuenta con las funciones glutSpecialFunc() y glutKeyboardFunc() que sirven para sabe rcuando una tecla esta presionada, asi que para saber cuando se dejan de presionar se suele cambiar manualmente aignando flase al booleano correspondinete en la implementacion. En este caso como cuando se presionan la teclas al mismo tiempo una se congela.