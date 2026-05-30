# Informe Fase 5 — PetCare Manager
## Integración de Interfaz Gráfica al Sistema Orientado a Objetos

---

## 1. Introducción

El presente informe documenta el desarrollo de la Fase 5 del proyecto **PetCare Manager**, un sistema para la gestión integral de un refugio animal que permite administrar animales, adoptantes, procesos de adopción y registros médicos. Hasta la Fase 4 el sistema operaba exclusivamente como un modelo de objetos consumido desde consola; en esta etapa el equipo asumió el rol de desarrolladores frontend para construir una **Interfaz Gráfica de Usuario (GUI)** sobre la plataforma **Windows Forms (.NET)** en lenguaje **C#**.

La premisa metodológica que guió la fase fue la **separación de responsabilidades** (*separation of concerns*): la lógica del negocio construida en las fases anteriores no debía modificarse para acomodar la interfaz, sino que la interfaz debía adaptarse a ella. Este informe describe cómo se materializó dicho principio, qué decisiones de diseño se tomaron, qué eventos se programaron y de qué manera se blindó el sistema frente a errores de usuario.

---

## 2. Arquitectura del sistema

El proyecto conserva la **arquitectura en capas** definida en fases previas, ahora extendida con una capa de presentación. La estructura física del código refleja esta separación:

```
PetCareManager/
├── Models/
│   ├── Animal.cs              ← Lógica de negocio (entidad)
│   ├── Adoptante.cs           ← Lógica de negocio (entidad)
│   ├── Adopcion.cs            ← Lógica de negocio (entidad)
│   ├── EstadoAdopcion.cs      ← Enum de estados
│   ├── RegistroMedico.cs      ← Lógica de negocio (entidad)
│   ├── Form1.cs               ← Capa de presentación (eventos)
│   └── Form1.Designer.cs      ← Capa de presentación (controles)
└── Program.cs                 ← Punto de entrada
```

### 2.1 Capa de lógica del negocio (modelo)

Las clases del modelo encapsulan completamente las reglas de dominio. Por ejemplo:

- `Animal` controla su propio estado mediante el método `ActualizarEstado()` y expone el método consultor `EsAdoptable()`, que define internamente qué significa "estar disponible". La interfaz nunca decide esto: solo pregunta.
- `Adopcion` administra su ciclo de vida con los métodos `Aprobar()` y `Rechazar()`, que actualizan tanto el estado de la solicitud (`EstadoAdopcion`) como el estado del animal asociado.
- `Adoptante` valida internamente que el nombre no esté vacío mediante una excepción `ArgumentException`.

### 2.2 Capa de presentación

`Form1` actúa como controlador visual: instancia objetos del modelo, invoca sus métodos y refresca los controles gráficos. **No implementa lógica de dominio**: si se eliminara la interfaz y se volviera a la consola, el modelo seguiría siendo funcional sin cambio alguno. Esta es la prueba más clara de que el principio de separación de responsabilidades se respetó.

---

## 3. Diseño de la interfaz

### 3.1 Selección del patrón de navegación

El sistema gestiona cuatro módulos funcionales claramente diferenciados (Animales, Adoptantes, Adopciones y Registros Médicos). Para articularlos, se evaluaron tres alternativas:

| Patrón | Ventajas | Desventajas |
|---|---|---|
| MDI (Multiple Document Interface) | Ventanas independientes | Mayor complejidad, navegación dispersa |
| Menú con formularios separados | Modularidad | Múltiples ventanas abiertas simultáneamente |
| **Formulario único con TabControl** | **Centralización, navegación inmediata, contexto siempre visible** | Limita la apertura paralela de módulos |

Se optó por un **único formulario principal con `TabControl` de cuatro pestañas**, decisión que ofrece al usuario un punto de entrada centralizado y le permite alternar entre módulos sin cerrar ni reiniciar ventanas. Cada pestaña corresponde a una entidad del dominio.

### 3.2 Controles utilizados

La selección de controles privilegió la **usabilidad** sobre la estética:

- **`TextBox`** para entradas libres como nombre, especie, diagnóstico y tratamiento.
- **`ComboBox`** para listas cerradas como estados del animal y selección de animal/adoptante en una adopción. Esto **previene errores de digitación**, ya que el usuario solo puede elegir valores válidos.
- **`DataGridView`** para listar registros existentes en formato tabular con columnas tipadas (`colAnimalId`, etc.).
- **`Button`** con colores semánticos (verde para acciones constructivas como "Registrar"; tonalidades neutras o de advertencia para "Rechazar").

### 3.3 Justificación visual

El uso de colores corporativos (`Color.FromArgb(76, 175, 80)` para confirmaciones) y el `FlatStyle = Flat` aportan coherencia visual y reducen la carga cognitiva del usuario. Cada `TabPage` mantiene la misma disposición vertical (etiquetas a la izquierda, controles a la derecha, botones de acción al final, `DataGridView` en la parte inferior), reforzando el aprendizaje por consistencia.

---

## 4. Programación orientada a eventos

El paso de un paradigma secuencial (consola) a uno **orientado a eventos** fue uno de los aprendizajes más significativos de la fase. A continuación se documentan los eventos implementados y su conexión con la lógica del negocio.

### 4.1 Eventos `Click` de botones

Cada botón actúa como puente entre la acción del usuario y un método del modelo:

| Botón | Evento | Acción sobre el modelo |
|---|---|---|
| `btnRegistrarAnimal` | `Click` | Instancia `new Animal(id, nombre, especie)` |
| `btnActualizarEstado` | `Click` | Invoca `animal.ActualizarEstado(nuevoEstado)` |
| `btnRegistrarAdoptante` | `Click` | Instancia `new Adoptante(id, nombre, telefono)` |
| `btnCrearAdopcion` | `Click` | Instancia `new Adopcion(id, animal, adoptante)` |
| `btnAprobarAdopcion` | `Click` | Invoca `adopcion.Aprobar()` |
| `btnRechazarAdopcion` | `Click` | Invoca `adopcion.Rechazar()` (con confirmación previa) |
| `btnAgregarRegistro` | `Click` | Instancia `new RegistroMedico(id, animal, diagnostico, tratamiento)` |

### 4.2 Evento `Load` y carga inicial

En el constructor de `Form1` se invoca `CargarDatosIniciales()`, método que precarga animales y adoptantes de muestra (Luna, Michi, Carlos Pérez) para que el sistema sea evaluable desde el primer arranque sin requerir captura previa de datos.

### 4.3 Eventos de teclado

Para el campo de teléfono del adoptante se implementó un evento **`KeyPress`** que descarta cualquier carácter no numérico en tiempo real:

```csharp
private void txtTelefonoAdoptante_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        e.Handled = true;
}
```

Este evento, combinado con la propiedad `MaxLength = 10` configurada en el diseñador, garantiza que el usuario solo pueda capturar números y como máximo diez dígitos (formato de teléfono colombiano). Es el ejemplo más claro de cómo el manejo de eventos transforma la experiencia: el sistema ya no espera al `Click` de "Registrar" para corregir al usuario; lo guía mientras escribe.

### 4.4 Eventos de selección

Los `ComboBox` de animal y adoptante en la pestaña de adopciones se refrescan dinámicamente cada vez que se registra un nuevo elemento (`RefrescarCombosAdopcion()`), garantizando que las listas siempre reflejen el estado actual del modelo.

---

## 5. Mecanismos de validación

La interfaz implementa **validación en dos niveles** para impedir que datos inconsistentes lleguen al modelo:

### 5.1 Validación previa a la invocación del modelo

Antes de instanciar cualquier objeto, se verifica:

- **Campos obligatorios**: uso de `string.IsNullOrWhiteSpace()` sobre cada `TextBox`. Si algún campo está vacío, se muestra un `MessageBox` con `MessageBoxIcon.Warning` y se aborta la operación.
- **Selecciones requeridas**: para `ComboBox` y `DataGridView` se valida `SelectedIndex < 0` o `SelectedRows.Count == 0` antes de proceder.
- **Formato del teléfono**: además del `KeyPress`, se recorre el texto carácter por carácter para detectar entradas pegadas con Ctrl+V que pudieran burlar el filtro, y se exige una longitud exacta de 10 dígitos.

### 5.2 Validación dentro del modelo

Las clases del dominio mantienen sus propias validaciones (lanzando `ArgumentException` cuando reciben datos inválidos), de modo que el modelo es robusto incluso si en el futuro se conecta a otra interfaz que no valide.

### 5.3 Retroalimentación visual al usuario

Toda validación fallida genera un `MessageBox` con:

- Mensaje **descriptivo y en lenguaje natural** ("El teléfono solo puede contener números").
- **Ícono semántico** (`Warning` para validaciones, `Error` para excepciones, `Information` para confirmaciones).
- **Devolución del foco** al campo problemático (`txtTelefonoAdoptante.Focus()`), agilizando la corrección.

---

## 6. Manejo de excepciones (blindaje)

Cada manejador de evento que invoca al modelo está envuelto en un bloque **`try-catch`** estructurado en dos niveles:

```csharp
try
{
    // ... validaciones e invocación del modelo
}
catch (ArgumentException ex)
{
    MessageBox.Show("Dato inválido: " + ex.Message,
        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception ex)
{
    MessageBox.Show("Error inesperado: " + ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

El primer `catch` captura específicamente las excepciones de validación lanzadas por el modelo (`ArgumentException`), traduciéndolas en mensajes que el usuario final puede entender. El segundo actúa como red de seguridad contra cualquier excepción no anticipada, **garantizando que el programa nunca se cierre abruptamente**. Incluso `CargarDatosIniciales()` está protegido, evitando que un fallo en el bootstrap deje al usuario frente a una ventana en blanco.

---

## 7. Retroalimentación al usuario

Toda acción significativa concluye con un `MessageBox` informativo:

- **Confirmación de éxito**: "Animal 'Luna' registrado exitosamente. ID asignado: 1" — informa al usuario que la operación se completó **e** indica el identificador generado, útil para acciones posteriores.
- **Confirmación previa para acciones destructivas**: el rechazo de adopciones solicita confirmación con `MessageBoxButtons.YesNo` antes de ejecutarse.
- **Mensajes de operación no permitida**: por ejemplo, intentar aprobar una adopción que ya está aprobada produce un mensaje claro en lugar de fallar silenciosamente.

El usuario nunca queda con la duda de si su acción se ejecutó.

---

## 8. Integración con el backend

La integración respeta estrictamente el contrato de las fases previas: **no se introdujo lógica de negocio en la capa de presentación**. Toda creación o modificación de entidades pasa por los constructores y métodos públicos definidos en las clases del modelo. Las listas en memoria (`listaAnimales`, `listaAdoptantes`, `listaAdopciones`, `listaRegistrosMedicos`) actúan como repositorio temporal, pero los objetos que contienen son instancias íntegras del dominio, con su estado y comportamiento intactos.

Un ejemplo de esta integración correcta es la **propagación de estado**: cuando el usuario aprueba una adopción, la interfaz invoca `adopcion.Aprobar()`. Es el método del modelo el que internamente actualiza el `Estado` de la `Adopcion` **y** llama a `Animal.ActualizarEstado("Adoptado")`. La interfaz solo refresca las grillas (`RefrescarGridAdopciones()`, `RefrescarGridAnimales()`); no decide qué cambia ni cómo.

---

## 9. Cumplimiento de los criterios de entrega

| Nº | Criterio | Estado | Evidencia en el código |
|---|---|---|---|
| 1 | Compilación y ejecución limpia | Cumplido | El proyecto compila con `dotnet build` sin advertencias críticas y arranca con `dotnet run` |
| 2 | Arquitectura en capas | Cumplido | Separación física en `Models/` entre entidades y formularios |
| 3 | Menú principal de navegación | Cumplido | `TabControl` con cuatro pestañas en `Form1` |
| 4 | Validación visual | Cumplido | `MessageBox` previos a la invocación del modelo + `KeyPress` en tiempo real |
| 5 | Bloques `try-catch` | Cumplido | Presentes en todos los manejadores `*_Click` y en `CargarDatosIniciales()` |
| 6 | Retroalimentación al usuario | Cumplido | `MessageBox` con íconos semánticos en cada acción importante |
| 7 | Demostración funcional (video) | Por entregar | Video de 6–10 minutos navegando por todos los módulos |
| 8 | Justificación técnica (video) | Por entregar | Audio que explica eventos y conexión con clases previas |

---

## 10. Reflexiones sobre decisiones de diseño

1. **Validación en dos niveles vs. validación única**: optamos por validar tanto en la interfaz como en el modelo. Aunque hay duplicación aparente, esto desacopla las capas: el modelo no confía en que la interfaz valide, y la interfaz protege al usuario de ver excepciones técnicas.

2. **`TabControl` vs. MDI**: descartamos MDI por considerarlo sobredimensionado para un sistema con cuatro módulos. La centralización en un único formulario reduce la curva de aprendizaje y mantiene visible el contexto.

3. **Listas en memoria vs. persistencia**: se mantuvieron las listas como en fases previas. La persistencia (archivo o base de datos) está fuera del alcance de la fase, pero la arquitectura actual permite añadirla sin tocar la interfaz: bastaría con sustituir las listas por un repositorio.

4. **Eventos `KeyPress` para validación temprana**: validar al teclear es más amable que validar al enviar. El usuario corrige antes de cometer el error, no después.

---

## 11. Conclusión

La Fase 5 consolidó el sistema PetCare Manager como una aplicación funcional, robusta y orientada al usuario final. Más allá de "agregar ventanas", el ejercicio permitió experimentar la transición entre paradigmas (secuencial → orientado a eventos) y aplicar de manera concreta principios de ingeniería de software como la separación de responsabilidades, el encapsulamiento y el manejo defensivo de errores. El resultado es un sistema cuya lógica de negocio sigue siendo independiente y reutilizable, ahora acompañada de una capa de presentación que la hace accesible.
