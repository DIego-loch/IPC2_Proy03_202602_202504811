classDiagram
    class Contribuyente {
        +string NIT
        +string nombre
        +DatoNIT() long
    }
    class NodoRTU {
        +Contribuyente NodoActual
        +NodoRTU NodoDerecha
        +NodoRTU NodoIzquierda
    }
    class ArbolRTU {
        +NodoRTU raiz
        +NuevoContribuyente(Contribuyente) bool
        +ActualizarContribuyente(string, string) bool
        +MostrarContribuyente(string) Contribuyente
        +RecorrerRTU() List~Contribuyente~
    }
    class DTE {
        +string Tiempo
        +string Referencia
        +string NitEmisor
        +string NitReceptor
        +double Valor
        +double IVA
        +double Total
    }
    class CodReferencias {
        +string referencia
        +long codigoAprobacion
    }
    class ListaDTE {
        +List~DTE~ DTEs
    }
    class ListaCodReferencias {
        +List~CodReferencias~ dato
    }
    class ValidadorNIT {
        +string NIT
        +Validacion() bool
    }
    class GeneradorCodigo {
        +string ultimaFecha$
        +int Correlativo$
        +CodigoAutorizacion(string) long
    }
    class RTUController {
        +Procesar(List~Contribuyente~)
    }
    class AutorizacionController {
        +ProcesarFactura(List~DTE~)
        +ConsultarContribuyente()
        +ResumenIva()
        +ResumenRango()
    }

    ArbolRTU "1" *-- "0..*" NodoRTU : contiene
    NodoRTU "1" --> "1" Contribuyente : almacena
    RTUController ..> ArbolRTU : usa
    RTUController ..> ValidadorNIT : usa
    AutorizacionController ..> ArbolRTU : consulta
    AutorizacionController ..> ListaDTE : llena
    AutorizacionController ..> ListaCodReferencias : llena
    AutorizacionController ..> GeneradorCodigo : usa
    ListaDTE "1" *-- "0..*" DTE : contiene
    ListaCodReferencias "1" *-- "0..*" CodReferencias : contiene
