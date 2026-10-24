flowchart TD
 ```mermaid
    A[Inicio: Subir archivo JSON] --> B[Frontend recibe el archivo]
    B --> C[Frontend envia POST a API]
    C --> D[API recibe el JSON]
    D --> E[Deserializar a Lista de DTE]
    E --> F[Recorrer cada Factura]
    
    F --> G{NIT Emisor existe?}
    G -- No --> H[Rechazar: Emisor Inexistente]
    G -- Si --> I{NIT Receptor existe?}
    
    I -- No --> J[Rechazar: Receptor Inexistente]
    I -- Si --> K[Generar codigo correlativo]
    K --> L[Guardar en Listas Globales]
    L --> M[Sumar contador aprobadas]
    
    H --> N{Hay mas facturas?}
    J --> N
    M --> N
    
    N -- Si --> F
    N -- No --> O[Guardar listas en archivo .json]
    O --> P[Crear objeto JSON de respuesta]
    P --> Q[Frontend muestra resultado]
   ```
