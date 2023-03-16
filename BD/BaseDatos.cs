using System;

using MySql.Data.MySqlClient;

namespace BD
{
    internal class BaseDatos
    {
        private readonly MySqlConnection myConnection;
        private readonly MySqlCommand myCommand;
        private readonly string sHost;
        private readonly string sUser;
        private readonly string sPassword;

        //Contructor de la clase
        public BaseDatos(string sHost, string sUser, string sPassword) {
            this.sHost = sHost;
            this.sUser = sUser;
            this.sPassword = sPassword;

            this.myConnection = new MySqlConnection($"server={sHost};" +
                                                    $"user id={sUser};" +
                                                    $"password={sPassword};");
            this.myCommand = new MySqlCommand("", this.myConnection);
            VerificarConexion();
        }

        public BaseDatos() {
            this.sHost = "localhost";
            this.sUser = "root";
            this.sPassword = "12345678";
            this.myConnection = new MySqlConnection($"server={sHost};" +
                                                    $"user id={sUser};" +
                                                    $"password={sPassword};");
            VerificarConexion();
            this.myCommand = new MySqlCommand("", this.myConnection);
        }

        /// <summary>
        /// Método para coprobar si la conexión está abierta y cerrarla en caso contrario
        /// </summary>
        public void VerificarConexion() {
            if (myConnection.State != System.Data.ConnectionState.Open) {
                myConnection.Open();
                Console.WriteLine("Se ha abierto la conexión con el servidor");
            } else {
                myConnection.Close();
                Console.WriteLine("Se ha cerrado la conexión con el servidor");
            }
        }

        // Método para realizar una consulta SQL
        public void RealizarConsulta(string sql) {
            try {
                this.myCommand.CommandText = sql;
                var myReader = myCommand.ExecuteReader();
                Console.WriteLine("Esta es la salida de la instrucción que has ingresado:");
                while (myReader.Read()) {
                    Console.WriteLine(myReader.GetString(0));
                }
                VerificarConexion();
            }
            catch (Exception ex) {
                Console.WriteLine("Ocurrio un error. Revisa la instrucción SQL");
                Console.WriteLine(ex.ToString());
                VerificarConexion();
                throw ex.InnerException;
            }
        }
    }
}
