using System;
using Proyecto_3;
namespace Proyecto_3
{
    public class ArbolRTU
    {
        public NodoRTU? raiz { get; set; }

        public bool NuevoContribuyente(Contribuyente dato)
        {
            NodoRTU nodo = new NodoRTU(dato);
            if (raiz == null)
            {
                raiz = nodo;
                return true;
            }


            // Proceso de ingresar datos
            NodoRTU aux = raiz;
            while (true)
            {
                if (nodo.NodoActual.DatoNIT() > aux.NodoActual.DatoNIT())
                {
                    if (aux.NodoDerecha == null) { aux.NodoDerecha = nodo; return true; }
                    else aux = aux.NodoDerecha;

                }
                else if (nodo.NodoActual.DatoNIT() < aux.NodoActual.DatoNIT())
                {
                    if (aux.NodoIzquierda == null) { aux.NodoIzquierda = nodo; return true; }
                    else aux = aux.NodoIzquierda;
                }
                else return false;
            }

        }

        public bool ActualizarContribuyente(string NITContri, string NuevoNombre)
        {
            long NIT = long.Parse(NITContri);
            NodoRTU aux = raiz;

            while (aux != null)
            {
                if (aux.NodoActual.DatoNIT() == NIT)
                {
                    aux.NodoActual.nombre = NuevoNombre;
                    return true;
                }
                else if (NIT > aux.NodoActual.DatoNIT()) aux = aux.NodoDerecha;
                else aux = aux.NodoIzquierda;
            }

            return false;
        }

        public Contribuyente? MostrarContribuyente(string NITContri)
        {
            long NIT = long.Parse(NITContri);
            NodoRTU aux = raiz;

            while (aux != null)
            {
                if (aux.NodoActual.DatoNIT() == NIT)
                {
                    return aux.NodoActual;
                }
                else if (NIT > aux.NodoActual.DatoNIT()) aux = aux.NodoDerecha;
                else aux = aux.NodoIzquierda;
            }

            return default;
        }

        public List<Contribuyente> RecorrerRTU()
        {
            List<Contribuyente> lista = new List<Contribuyente>();
            MostrarInfo(raiz, lista);
            return lista;
        }

        private void MostrarInfo(NodoRTU aux, List<Contribuyente> lista)
        {
            if (aux == null) return;
            MostrarInfo(aux.NodoIzquierda, lista);
            lista.Add(aux.NodoActual);
            MostrarInfo(aux.NodoDerecha, lista);
        }
    }
}
