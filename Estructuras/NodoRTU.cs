using System;

namespace Proyecto_3
{
    class NodoRTU
    {
        public Contribuyente NodoActual { get; set; }
        public NodoRTU? NodoDerecha { get; set; }
        public NodoRTU? NodoIzquierda { get; set; }

        public NodoRTU(Contribuyente dato)
        {
            NodoActual = dato;
            NodoDerecha = null;
            NodoIzquierda = null;
        }

    }
}
