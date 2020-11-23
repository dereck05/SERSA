using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sersa.Models
{
    public static class Autenticacion
    {
        private static int tipo;
        private static int idUsuario;
        private static string idAsada;


        public static int get_tipo() {
            return tipo;
        }
        public static int get_idUsuario() {
            return idUsuario;
        }
        public static string get_idAsada() {
            return idAsada;
        }
        public static void set_tipo(int pTipo) {
            tipo = pTipo;
        }
        public static void set_idUsuario(int pId) {
            idUsuario = pId;
        }
        public static void set_idAsada(string pID) {
            idAsada = pID;
        }


    }
}
