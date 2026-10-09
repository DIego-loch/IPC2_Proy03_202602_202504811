using System;
using Proyecto_2;
namespace Proyecto_3
{
    public class ArbolRTU
    {
        public NodoRTU? raiz { get; set; }

        public void NuevoContribuyente(Contribuyente dato)
        {
            NodoRTU nodo = new NodoRTU(dato);
            if (raiz == null)
            {
                raiz = nodo;
                return;
            }


            // Proceso de ingresar datos
            NodoRTU aux = raiz;
            while (true)
            {
                if (nodo.NodoActual.DatoNIT() > aux.NodoActual.DatoNIT())
                {
                    if (aux.NodoDerecha == null) { aux.NodoDerecha = nodo; return; }
                    else aux = aux.NodoDerecha;

                }
                else if (nodo.NodoActual.DatoNIT() < aux.NodoActual.DatoNIT())
                {
                    if (aux.NodoIzquierda == null) { aux.NodoIzquierda = nodo; return; }
                    else aux = aux.NodoIzquierda;
                }
                else return;
            }

        }

    }
}
