# SISTEMA DE AUTORIZACIÓN DE DOCUMENTOS TRIBUTARIOS ELECTRÓNICOS (DTE) USANDO ÁRBOLES BINARIOS Y APIS REST
Proyecto 3

Introducción a la Programación y Computación 2

Autor: Diego Alexander Loch Cocón Carnet: 202504811

Guatemala, octubre de 2026

### Resumen:
El presente proyecto aborda el desarrollo de un sistema de autorización de Documentos Tributarios Electrónicos (DTE) para la Superintendencia de Administración Tributaria (SAT). El sistema se implementa bajo una arquitectura Cliente-Servidor, utilizando el lenguaje de programación C# y el paradigma de programación orientada a objetos. El Backend consiste en una API REST construida con .NET Core, la cual se encarga de procesar los archivos JSON, validar los NITs mediante el algoritmo del módulo 11, gestionar un Registro Tributario Unificado (RTU) implementado con un Árbol Binario de Búsqueda (ABB) propio, y generar códigos de autorización correlativos diarios utilizando expresiones regulares (Regex) para el manejo de fechas. El Frontend, desarrollado con Razor Pages, permite a los usuarios subir archivos JSON, consumir la API mediante peticiones HTTP y visualizar los resultados. La solución incluye persistencia de datos en archivos JSON locales, garantizando que la información de contribuyentes y facturas no se pierda entre ejecuciones del servidor.

Palabras clave: API REST, .NET Core, Razor Pages, Árbol Binario de Búsqueda, JSON, Regex, HTTP, CORS.

### Abstract
This project addresses the development of an electronic tax document (DTE) authorization system for the Tax Administration Superintendence (SAT). The system is implemented under a Client-Server architecture, using the C# programming language and the object-oriented programming paradigm. The Backend consists of a REST API built with .NET Core, which is responsible for processing JSON files, validating NITs using the modulo 11 algorithm, managing a Unified Tax Registry (RTU) implemented with a custom Binary Search Tree (BST), and generating daily sequential authorization codes using regular expressions (Regex) for date handling. The Frontend, developed with Razor Pages, allows users to upload JSON files, consume the API through HTTP requests, and visualize the results. The solution includes data persistence in local JSON files, ensuring that taxpayer and invoice information is not lost between server executions.

Keywords: REST API, .NET Core, Razor Pages, Binary Search Tree, JSON, Regex, HTTP, CORS.

#### 1. Introducción
En la actualidad, la digitalización de los procesos tributarios es un pilar fundamental para la modernización de las instituciones gubernamentales. La Superintendencia de Administración Tributaria (SAT) requiere sistemas capaces de procesar grandes volúmenes de facturas electrónicas de manera rápida, segura y confiable, validando la autenticidad de los contribuyentes y asegurando la integridad de los montos facturados.

El presente proyecto tiene como objetivo modelar e implementar una solución integral que permita recibir mensajes en formato JSON, validar la información de los Documentos Tributarios Electrónicos (DTE) y generar códigos únicos de autorización. Para ello, se desarrolló una API en .NET Core que utiliza estructuras de datos dinámicas implementadas desde cero (un Árbol Binario de Búsqueda) para la gestión eficiente del RTU, y una interfaz web en Razor Pages que actúa como cliente para el envío de archivos y la visualización de reportes. El sistema también incorpora el uso de expresiones regulares para el procesamiento de fechas y algoritmos matemáticos para la validación del dígito verificador de los NITs.

#### 2. Desarrollo del tema
2.1 Tipos de Datos Abstractos (TDA) y Estructuras de Datos
El proyecto requiere el uso de estructuras de datos que permitan un acceso eficiente a la información. Para la gestión del Registro Tributario Unificado (RTU), se implementó un Árbol Binario de Búsqueda (ABB).

2.1.1 Nodo del Árbol (NodoRTU)
El TDA Nodo es la base del árbol. Cada nodo almacena un objeto de tipo Contribuyente (que contiene el NIT y el nombre) y dos punteros: uno al hijo izquierdo y otro al hijo derecho.

2.1.2 Árbol Binario de Búsqueda (ArbolRTU)
El árbol binario de búsqueda permite almacenar a los contribuyentes ordenados por su NIT. Esto garantiza que las operaciones de inserción, búsqueda y actualización se realicen en un tiempo de ejecución logarítmico (O(log n)), lo cual es vital cuando se procesan miles de facturas que requieren verificar si un emisor o receptor existe en el padrón.

2.2 Arquitectura de la Solución (Cliente-Servidor)
El sistema se divide en dos componentes principales que se comunican a través del protocolo HTTP:

Servicio 2 (Backend / API): Desarrollado en .NET Core, expone endpoints (rutas) para procesar el RTU y las Autorizaciones. Recibe los JSON, realiza las validaciones (NIT válido, existencia en el padrón, cálculo de IVA, duplicidad de referencias) y devuelve respuestas estructuradas en JSON.

Programa 1 (Frontend / Razor Pages): Desarrollado como una aplicación web. Proporciona una interfaz gráfica amigable donde el usuario puede cargar los archivos JSON, consultar el resumen de facturas y reiniciar el sistema.

2.3 Procesamiento de Mensajes JSON y Validación de NITs
La API utiliza la librería System.Text.Json para deserializar los archivos JSON entrantes. Una vez en memoria, se procesa cada contribuyente o factura:

Validación de NIT: Se implementó el algoritmo del módulo 11. Se multiplica cada dígito por su posición de derecha a izquierda (exceptuando el primero), se suma el resultado, se calcula el módulo 11 y se resta de 11 para obtener el dígito verificador, comparándolo con el último carácter del NIT.

Validación de Facturas: Se verifica que el NIT emisor y receptor existan en el árbol del RTU. Además, se valida que la REFERENCIA de la factura sea única y que los cálculos de IVA y TOTAL coincidan con las reglas matemáticas preestablecidas.

2.4 Generación de Códigos de Autorización y Uso de Regex
Para autorizar una factura, el sistema debe generar un código único con el formato yyyymmdd#######.

Se utilizó Regex (Expresiones Regulares) para extraer la fecha del string TIEMPO (que incluía texto como "Guatemala," y "hrs."). El patrón implementado permitió aislar el día, mes y año.

Se implementó un correlativo diario utilizando variables estáticas en memoria. Si el día de la factura cambia, el correlativo se reinicia a 1; si es el mismo día, el contador se incrementa.

2.5 Persistencia de Datos
Para evitar la pérdida de información al reiniciar el servidor, el sistema implementa persistencia en archivos planos:

Al procesar datos, las clases Guardar y GuardarFacturas se encargan de serializar las listas y el árbol a texto JSON y escribirlos en la carpeta Datos/.

Al iniciar la API, la clase Cargar lee estos archivos y reconstruye el árbol en memoria y las listas globales.

2.6 Comunicación Frontend-Backend y CORS
La comunicación se realiza mediante la clase HttpClient de C#. El Frontend lee el archivo subido por el usuario y lo envía a la API mediante peticiones POST. Para permitir esta comunicación, fue necesario configurar CORS (Cross-Origin Resource Sharing) en el Backend, autorizando explícitamente el origen del Frontend para evitar bloqueos de seguridad del navegador.

2.7 Interfaz Gráfica de Usuario
La interfaz web, construida con Razor Pages y estilizada con Bootstrap, cuenta con un menú principal. Permite al usuario seleccionar y enviar archivos JSON, visualizar reportes de IVA, consultar facturas por NIT y rangos de fechas, y reiniciar los datos del sistema para realizar nuevas pruebas.

#### 3. Conclusiones
El desarrollo del sistema de autorización de DTE ha permitido cumplir con los objetivos planteados, demostrando la viabilidad de implementar una solución web completa y robusta utilizando C# y .NET Core.

La implementación de un Árbol Binario de Búsqueda propio para el RTU demostró ser altamente eficiente para validar la existencia de contribuyentes en tiempo récord, superando las limitaciones de búsquedas lineales. Esto evidencia una comprensión profunda de las estructuras de datos dinámicas.

El uso de expresiones regulares (Regex) para la extracción de fechas a partir de cadenas de texto no estructuradas facilitó la generación automática de los correlativos diarios, garantizando que los códigos de autorización cumplieran estrictamente con el formato exigido y sin duplicidades dentro del mismo día.

La arquitectura Cliente-Servidor permitió separar las responsabilidades del sistema: el Backend se encargó de la lógica pesada y la seguridad de los datos, mientras que el Frontend ofreció una experiencia de usuario fluida mediante Razor Pages. La configuración de CORS y el uso de HttpClient para el envío de archivos JSON evidenciaron la importancia de los estándares de comunicación web.

Finalmente, la implementación de persistencia mediante archivos JSON permitió que el sistema mantuviera su estado a través de reinicios del servidor, asegurando que los contribuyentes y las facturas autorizadas estuvieran siempre disponibles para futuras consultas y auditorías.

Referencias bibliográficas
Microsoft Corporation. (2026). Documentación de ASP.NET Core y Razor Pages. Recuperado de https://learn.microsoft.com/es-es/aspnet/core/

Microsoft Corporation. (2026). System.Text.Json Namespace. Recuperado de https://learn.microsoft.com/es-es/dotnet/api/system.text.json

Microsoft Corporation. (2026). Expresiones regulares en .NET. Recuperado de https://learn.microsoft.com/es-es/dotnet/standard/base-types/regular-expressions

Galdámez, J. (2020). Programación orientada a objetos con C#. Editorial Universitaria, Universidad de San Carlos de Guatemala.

Sedgewick, R., & Wayne, K. (2011). Algorithms (4th ed.). Addison-Wesley.
