# OrangeHRM Automation Framework

Este repositorio contiene un framework de automatización de pruebas desarrollado en C# (.NET) utilizando Selenium WebDriver y xUnit, siguiendo el patrón de diseño Page Object Model (POM).

El proyecto fue desarrollado sobre la plataforma [OrangeHRM](https://opensource-demo.orangehrmlive.com/web/index.php/auth/login), un sistema de gestión de recursos humanos (HRM) de código abierto que dispone de un entorno demo público ampliamente utilizado para la práctica de testing manual y automatizado.

El objetivo del proyecto fue implementar una solución de automatización mantenible y escalable capaz de realizar operaciones de Alta, Modificación y Baja (ABM) sobre empleados dentro de la plataforma, aplicando buenas prácticas de desarrollo y testing.

---


# Índice

* **[1 - Objetivos](#link-objetivos-1)**

* **[2 - Tecnologías utilizadas](#link-tecnologías-utilizadas-2)**

* **[3 - Proceso de aprendisaje](#link-proceso-de-aprendizaje-3)**

* **[4 - Casos de prueba implementados](#link-casos-de-prueba-implementados-4)**

* **[5 - Arquitectura](#link-arquitectura-5)**

---


# :link: OBJETIVOS (1)

Durante el desarrollo se buscó cumplir los siguientes objetivos:

* Implementar pruebas automatizadas utilizando Selenium WebDriver.
* Aplicar el patrón Page Object Model (POM).
* Mantener una arquitectura clara y reutilizable.
* Ejecutar pruebas en múltiples navegadores.
* Implementar ejecución paralela de pruebas.
* Diseñar una capa de acceso a datos desacoplada.
* Aplicar validaciones mediante asserts para cada escenario.
* Utilizar buenas prácticas de programación orientadas a mantenibilidad y escalabilidad.

---


# :link: TECNOLOGÍAS UTILIZADAS (2)

* C#
* .NET
* Selenium WebDriver
* xUnit
* ChromeDriver
* EdgeDriver


# :link: PROCESO DE APRENDIZAJE (3)

Este proyecto fue desarrollado a lo largo de aproximadamente dos semanas como parte de un proceso intensivo de aprendizaje en automatización de pruebas.

Al inicio del proyecto no se contaba con experiencia previa en herramientas de automatización. Durante el desarrollo se investigaron y aplicaron conceptos fundamentales como:

* Selenium WebDriver.
* xUnit.
* Page Object Model (POM).
* Gestión de WebDrivers.
* Esperas explícitas (Explicit Waits).
* Ejecución paralela de pruebas.
* Automatización Cross-Browser.
* Diseño de frameworks de automatización.
* Abstracción de acceso a bases de datos.

El foco principal fue construir una solución que no solamente funcionara, sino que también pudiera ser mantenida y ampliada fácilmente.

---


# :link: CASOS DE PRUEBA IMPLEMENTADOS (4)

### Alta de Empleado

* Inicio de sesión en OrangeHRM.
* Navegación al módulo correspondiente.
* Creación de un nuevo empleado.
* Guardado de la información.
* Validación de la operación mediante asserts.

### Modificación de Empleado

* Búsqueda de un empleado existente.
* Actualización de información.
* Guardado de cambios.
* Validación de la modificación realizada.

### Baja de Empleado

* Localización de un empleado existente.
* Eliminación del registro.
* Confirmación de la operación.
* Validación de la eliminación mediante asserts.

---


# :link: ARQUITECTURA (5)

El framework fue desarrollado utilizando el patrón **Page Object Model (POM)** para desacoplar la lógica de negocio de la interacción con la interfaz gráfica.

## Estructura

```text
OrangeHRM.Automation
│
├── Builders
│   └── Construcción de objetos y datos de prueba
│
├── Components
│   └── Componentes reutilizables de la interfaz
│
├── Core
│   └── Gestión de WebDriver, configuración y utilidades base
│
├── Database
│   └── Capa de acceso y abstracción de base de datos
│
├── Models
│   └── Modelos de datos utilizados por los tests
│
├── Pages
│   └── Implementación del patrón Page Object Model (POM)
│
├── Resources
│   └── Recursos auxiliares e imágenes utilizadas por el proyecto
│
├── Tests
│   └── Casos de prueba automatizados
│
├── AssemblyInfo.cs
├── OrangeHRM.Automation.csproj
├── OrangeHRM.Automation.sln
├── appsettings.json
└── xunit.runner.json

```

### Principios Aplicados

* Separación de responsabilidades.
* Reutilización de componentes.
* Centralización de la gestión de drivers.
* Uso de esperas explícitas.
* Independencia entre casos de prueba.
* Código mantenible y escalable.

---

## Capa de Base de Datos

Como parte de los requisitos del ejercicio, se diseñó una capa de acceso a base de datos que permite abstraer futuras integraciones con sistemas reales.

Si bien no se disponía de una base de datos para validar la información, se implementó la estructura necesaria para:

* Gestión de conexiones.
* Ejecución de consultas.
* Validación de resultados.
* Escalabilidad para futuras integraciones.

---

## Ejecución Multinavegador

La solución permite ejecutar los mismos casos de prueba sobre distintos navegadores sin modificar el código de los tests.

Actualmente se encuentra preparada para:

* Google Chrome
* Microsoft Edge

---

## Ejecución Paralela

El framework soporta ejecución paralela de pruebas, permitiendo correr los escenarios sobre múltiples navegadores durante una misma ejecución.

Esta característica reduce tiempos de ejecución y acerca la solución a escenarios reales de integración continua.

---

## Captura de Evidencias

El framework incorpora un mecanismo de captura automática de pantallas ante errores o fallos durante la ejecución de las pruebas.

Cuando un escenario no finaliza correctamente, se genera una evidencia visual del estado de la aplicación en el momento del fallo, facilitando el análisis, la depuración y la identificación de la causa del problema.

Esta funcionalidad resulta especialmente útil durante la ejecución desatendida de pruebas y en entornos de integración continua, donde permite disponer de información adicional para el diagnóstico de incidencias.


