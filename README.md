# SurviveInTheForest

**Proyecto Universitario**

El personaje tendrá que enfrentarse a diferentes enemigos para lograr pasar el bosque.

## Proceso

Se detallará todos los pasos realizados en las diferentes escenas.

### Escena de Carga

AdministradorCarga: es un GameObject vacio que solo contiene el script AdministradorCargaScript que hace la carga del Slider.

- AdministradorCargaScript
  - Recibe el índice de la escena a mostrar, por defecto es la escena del Menú Principal con índice 1.
  - Recibe la referencia del Slider.
  - En el método Start se utiliza el método que inicia la carga de la escena Asincronamente, por lo cual, se tiene que hacer dentro de una Corrutina, en este caso StartCoroutine.
  -El método LoadAsyncScene, realiza la carga del Slider y dependiendo se se ha cargado todo el Slider, activará la nueva escena.

Canvas: contiene todos los elementos que se visualizará en este escenario.

- Este Canvas escala con el tamaño de la pantalla, en el componente Canvas Scaler, se selecciona en UI Scale Module el Scale With Screen Size.
  - La imagen de fondo.
  - Los personajes.
  - El Slider
    - La interacción será Falso.
    - Desactivar la transición.
    - Desactivar la navegación.
    - Agregar un texto Cargando.
    - Modificar el Fill, para cambiar el color de carga.
    - Eliminar el Handle Slide Area.
    - Ajustar el tamaño del Fill Area, para que cobra todo el espacio del Slider.

### Menú Inicio

Canvas: contiene todos los elementos que se visualizará en este escenario.

- Este Canvas escala con el tamaño de la pantalla, en el componente Canvas Scaler, se selecciona en UI Scale Module el Scale With Screen Size.
- MenuInicioScript
  - Recibe el SpriteRender de la Imagen para cambiar al personaje.
  - Recibe el Texto para diferenciar al personaje.
  - Se agrega todas las acciones que tendrán los botones, cambiar de escena y mostras u ocultar menu.
  - Realizamos la lógica para seleccionar al personaje, recibe el SpriteRender, Texto y Animator.
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
  - Script
    - Se crea Personajes para que se visualice en el Unity y sirva para pasar los datos del personaje: el objeto(prefab), imagen y nombre.
    - Se crea AdministradorPersonajesScript que se encarga de hacer la lógica de selección de personaje y pasarlo a la otra escena. Recibe los personajes en una lista.
  - Se crea la animación de los personajes.
  - Se crean los prefabs de los personajes.
  - Se crea el nuevo objeto Personaje dentro de la carpeta SeleccionPersonaje para pasarle todos los datos del personaje (prefab, imagen y nombre).
  - Pasamos el nuevo objeto Personaje a la lista del script de AdministradorPersonajesScript.
  - Eliminamos la imagen de referencia del GameObject donde se visualizarán el personaje seleccionado.

> Nota: Para agregar las nuevas escenas al juego, hay que dirigirse a: File>Build Settings y arrastramos las escenas que faltan, al lado derecho de los nombres de las escenas, indica el número por orden.

### Primera Escena

- Se agrega un nuevo Object vacio, que servirá para agregar el personaje seleccionado.
- Se copia el Object AdministradorPersonaje, para que cargue directamente el personaje seleccionado, sino se muestra la escena inicial.
