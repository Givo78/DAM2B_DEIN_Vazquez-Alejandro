using Microsoft.Data.Sqlite;
using System;

namespace ProyectoFigma
{
    public static class DatabaseHelper
    {
    

        private static readonly string DbFile = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ProyectoFigma",
                    "usuarios.db");

        private static SqliteConnection GetConnection()
        {
            var folder = System.IO.Path.GetDirectoryName(DbFile);
            if (!string.IsNullOrEmpty(folder) && !System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            var connection = new SqliteConnection($"Data Source={DbFile}");
            connection.Open();
            return connection;
        }

        public static void Inicializar()
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Usuario TEXT NOT NULL UNIQUE,
                Contraseña TEXT NOT NULL
            );";
                cmd.ExecuteNonQuery();
            }
        }



        public static bool RegistrarUsuario(string usuario, string contraseña)
        {
                using (var conn = GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@usuario, @contraseña)";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    cmd.ExecuteNonQuery();
                }
                return true;
        }

        public static bool ValidarUsuario(string usuario, string contraseña)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(1) FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

    }
}
