# Implementación de un Juego Tipo Pong en OpenGL

Para esta practica se uso `GLUT`, un kit de herramientas independiente del sistema de ventanas utilizadO para escribir programas en OpenGL. Se usa principalmente en el aprendizaje y la exploración de la programación con OpenGL.

Algo muy importante a tomar en cuenta es que la API portatil que proporciona `GLUT`  funciona tanto en laptops con arquitectura **x86(win32)** como en estaciones de trabajo **x11**. 
> La arquitectura de los procesadores hoy en dia, por lo general funcionan en x64(64 bits), sin embargo pueden ejecutar codigo en x86, asi que en tema de compatibilidad no hay problema alguno.



# Compilación del proyecto


# Implementacion con GLUT 3.3

El problema actual de la implementacion es que para saber que una de las teclas no esta precionada necesitamos modificar la variable booleana correspondiente en dispaly, es este caso para que el movimiento vaya fluido se uso un contador de tiempo que hace en el que cuando llega asigna False a la variable, y esto funciona perfecto para una sola paleta, sin embargo al implementar la otra ocurre un error. se supone que si presiono w y up las dos paletas deberian de moverse al mismo tiempo, cosa que no pasa, la razon se debe a que actualmente se esta usando la version de glut 3.3 que solo cuenta con las funciones `glutSpecialFunc()` y `glutKeyboardFunc()` que sirven para sabe rcuando una tecla esta presionada, asi que para saber cuando se dejan de presionar se suele cambiar manualmente aignando false al booleano correspondinete en la implementacion. Esto genera un problema pues si mantengo presionado w y luego s sin soltar w, lo que ocurre que la paleta izquierda deja de moverse, lo cual no deberia de ocurrir, pero ocurre porque al presionar s pasado el tiempo del contador, este hace que se ponga en falso la tecla w cuando en realidad esta presionada, sin embargo deberia de ponerse true ya que la tecla sigue presionada, pero eso ya no ocurre, asi que debe ser un problema de compatibilidad con el SO y el manejo del teclado, pues lo curioso es que con una sola paleta el movimiento es perfecto, pero con la otra no.

con glut 3.7 ahora puedo hacer uso de los metodos `glutSpecialUpFunc()` y `glutKeyboardUpFunc()`  que nos devuelven si una tecla ya se solto, de esta manera las teclas para el movieminto(w,s,up,down) se modifican unicamente por estas y las otras funciones, asi que en Display no es necesario modificar los valores booleanos de estas teclas. 

# Implementación
Es iportante saber como de distribuyen las coordenadas de la ventana, bueno en relidad es las que usamos para nuestro mundo, en este caso esta dadas por el metodo `gluOrtho2D(left, right, bottom, top);` de OpenGL donde left y bottom dan las cordenadas de la ezquina inferior, y right y top de dan las cordenadas de la ezquina superior. con ello es facil saber en que coordenadas se dan las colisiones.