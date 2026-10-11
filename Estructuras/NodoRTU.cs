using System;

namespace Proyecto_3
{
   public class NodoRTU
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
