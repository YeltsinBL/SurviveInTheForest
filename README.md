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
- Menu Audio
  - Crear una clase Serializable SonidoScript, que contiene el nombre y audio a reproducir.
  - Crear el script AdministradorAudioScript
    - Recibe como array los audios para la música y efectos, usando la clase SonidoScript.
    - Recibe los AudioSource independientes para la música y efectos.
    - Recibe los GameObject del slider de la música y efectos.
    - Recibe los valores iniciales de los sliders.
    - Recibe los GameObject de los botones de la música y efectos.
    - Recibe los GameObject los textos de los botones de la música y efectos.
    - Se hace una instancia del mismo scriplt.
    - En el método Start
      - Obtenemos los valores guardados en el PlayerPrefs de los Slider o se les asigan el valor inicial asignado.
      - Reproduce el la música de fondo.
    - En el método Awake, verificamos la instancia.
    - En la región Reproducir, se realiza la lógica para reproducir el audio de la música y efectos.
    - En la región Volumen, se realiza la lógica para aumentar o disminuir el audio de la música y efectos.
    - En la región Mutear, se realiza la lógica para activar o cancelar el audio de la música y efectos.
- Menu Nivel
  - Carrusel del Imágenes
    - Se agrega un panel, el cual contendrá un ScrollView. En el ScrollView, en la parte de Viewport, se agrega otro panel, que contendrá imagénes, en este caso son 3, que representan una demo del fondo de las escenas por nivel.
    - Dentro del ScrollView, se agrega otro GameObject vacio, el cual contendrá una imagen que representará las cantidades de escenas a mostrar, esta imagen luego se convierte en prefabs.
  - Botones: avanzar, retroceder, jugar y volver (a la menú inicial).
  - Se crea un GameObject vacio AdministradorNivel, que contiene el script que hará funcionar al Carrusel, AdministradorNivelScript.
    - Todo el código para esta acción, es obtenido desde el canal de [`Unity Vista`][Unity_Vista] en Youtube.
  - AdministradorNivelScript, recibe:
    - La imagen inicial de la primera escena.
    - La lista de las imágenes (background) de todas las escenas.
    - El GameObject donde se agregarán los prefabs para indicar la cantidad de escenas.
    - El prefabs que indica la escena.
    - Los botones para avanzar y retroceder escena.
    - Las configuraciones para el movimiento de las imágenes de la escena
      - Si se mueve automáticamente.
      - Si despues de llegar a la ultima imagen, continúa a la imagen inicial o hay que retrocerde uno a uno.
      - El tiempo del movimiento.
    - El ScrollView para verificar si se avanza de imagen desplazando por encima de la misma.
  - Desbloquear Niveles
    - Se agrega un GameObject Imagen y un texto dentro, esto indica la imagen del candadoy el texto bloqueado.
  - AdministradorNivelScript, se agrega:
    - El GameObject de la Imagen.
    - El GemeObject del Boton Jugar.
    - En el método EstadoNiveles, se activan las escenas ya disponibles.
    - En el método DesbloquearNiveles, se activa la siguiente escena.
    - En el método MostrarImagenBloqueado, se activa o desactivca el candado que indica la escena bloqueada.
    - El método SeleccionarNivel, selecciona la última escena visualizada en el carrusel.

> Nota: Para agregar las nuevas escenas al juego, hay que dirigirse a: File>Build Settings y arrastramos las escenas que faltan, al lado derecho de los nombres de las escenas, indica el número por orden.

### Primera Escena

- Se agrega un nuevo Object vacio, que servirá para agregar el personaje seleccionado.
- Se copia el Object AdministradorPersonaje, para que cargue directamente el personaje seleccionado, sino se muestra la escena inicial.

[//]: # (Enlaces a la documentación)

[Unity_Vista]: <https://www.youtube.com/watch?v=OEcpoDjSiCw>
