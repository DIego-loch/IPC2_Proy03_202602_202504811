flowchart TD
    A([Inicio: Subir archivo JSON]) --> B[Frontend Razor Pages recibe el archivo]
    B --> C[Frontend envía POST a API con HttpClient]
    C --> D{API recibe el JSON}
    D --> E[Deserializar a List de DTE]
    E --> F[Recorrer cada Factura]
    
    F --> G{¿NIT Emisor existe en árbol?}
    G -- No --> H[Rechazar factura: Emisor Inexistente]
    G -- Sí --> I{¿NIT Receptor existe en árbol?}
    
    I -- No --> J[Rechazar factura: Receptor Inexistente]
    I -- Sí --> K[Generar código correlativo]
    K --> L[Guardar en ListaCodReferencias y ListaDTE]
    L --> M[Sumar contador aprobadas]
    
    H --> N{¿Hay más facturas?}
    J --> N
    M --> N
    
    N -- Sí --> F
    N -- No --> O[Guardar listas en archivo .json]
    O --> P[Crear objeto JSON de respuesta]
    P --> Q([Frontend muestra resultado en pantalla])
