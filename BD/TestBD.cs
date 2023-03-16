using System;

namespace BD {
    internal class TestBD {
        static void Main(string[] args) {
            BaseDatos bd = new BaseDatos();
            bd.RealizarConsulta("SHOW FULL TABLES FROM prueba;");
            Console.ReadKey();
        }
    }
}
