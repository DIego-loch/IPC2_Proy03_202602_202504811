flowchart LR
    subgraph Cliente [Navegador Web del Usuario]
        UI[Interfaz Gráfica\nRazor Pages HTML/CSS/JS]
    end

    subgraph Servidor_Frontend [Servidor Frontend .NET Core]
        F_App[Proyecto_3_Fronted\nPuerto 5223]
    end

    subgraph Servidor_Backend [Servidor Backend .NET Core]
        B_App[Proyecto_3 API\nPuerto 5038]
        B_DB[(Archivos JSON\nDatos/InfoRTU.json\nDatos/InfoDTE.json)]
    end

    UI -- Interacción del Usuario\n(HTTP) --> F_App
    F_App -- Peticiones GET/POST\nHTTP + JSON (CORS) --> B_App
    B_App -- Lectura/Escritura\n(System.IO) --> B_DB
