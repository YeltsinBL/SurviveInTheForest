# SurviveInTheForest

**Proyecto Universitario**

El personaje tendrá que enfrentarse a diferentes enemigos para lograr pasar el bosque.

## Proceso

Se detallará todos los pasos realizados en las diferentes escenas.

### Menú Inicio

Canvas: contiene todos los elementos que se visualizará en este escenario.

- Este Canvas escala con el tamaño de la pantalla, en el componente Canvas Scaler, se selecciona en UI Scale Module el Scale With Screen Size.
- MenuInicioScript
  - Se agrega todas las acciones que tendrán los botones, cambiar de escena y mostras u ocultar menu.
- MenuInicial
  - Background: imagen
  - Personaje: sprite
  - Título: se utilizó el UI-TextMeshPro.
    - Se seleccionó una fuente.
    - Se agregó un gradiente.
    - Se alineó al centro,
    - Se cambió el color al borde de las letra.
    - Se agregó una sombra.
  - Botones: Jugar, Selecciona Personaje, Salir
    - Se utilizó el UI-TextMeshPro.
    - En el componente Botón de cada botón
      - Se agregaron los colores: por defecto, al pasar por encima, al presionar y seleccionar.
- MenuSeleccionPersonaje
  - Se duplica el MenuIncial pero se cambian algunos Seleccionar Personaje por el boton Atrás y se agrega un nuevo botón Siguiente.
  - Se reduce a 0 el Alpha del color de fondo, en este caso de la imagen.
  - Se agregan los personajes
  - Se agrega un fondo, independiente del canvas.

> Nota: Para agregar las nuevas escenas al juego, hay que dirigirse a: File>Build Settings y arrastramos las escenas que faltan, al lado derecho de los nombres de las escenas, indica el número por orden.
