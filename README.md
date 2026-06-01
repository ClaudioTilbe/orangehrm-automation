# OrangeHRM Automation Framework

## Descripción

Este repositorio contiene un framework de automatización de pruebas desarrollado en **C# (.NET)** utilizando **Selenium WebDriver** y **xUnit**, siguiendo el patrón de diseño **Page Object Model (POM)**.

El objetivo del proyecto fue implementar una solución de automatización mantenible y escalable capaz de realizar operaciones de Alta, Modificación y Baja (ABM) sobre empleados dentro de la plataforma OrangeHRM, aplicando buenas prácticas de desarrollo y testing.

---

## Objetivos del Proyecto

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

## Proceso de Aprendizaje

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

## Casos de Prueba Implementados

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

## Arquitectura del Proyecto

El framework fue desarrollado utilizando el patrón **Page Object Model (POM)** para desacoplar la lógica de negocio de la interacción con la interfaz gráfica.

### Estructura General

```text
OrangeHRM.Automation
│
├── Pages
├── Tests
├── Drivers
├── Utilities
├── Models
├── Database
├── Configuration
└── Resources
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

## Tecnologías Utilizadas

* C#
* .NET
* Selenium WebDriver
* xUnit
* ChromeDriver
* EdgeDriver

---



## Conclusiones

Este proyecto representa el desarrollo de un framework de automatización completo orientado a buenas prácticas de ingeniería de software y testing.

Además de cubrir los requerimientos funcionales solicitados, se priorizó la construcción de una arquitectura reutilizable, mantenible y preparada para evolucionar hacia escenarios de automatización más complejos.
