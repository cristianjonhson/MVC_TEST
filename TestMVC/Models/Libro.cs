using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Libro
    {
        [Required(ErrorMessage="Debe ingresar el codigo")]
        public int codigo { get; set; }

        [Required(ErrorMessage="No puede quedar vacio")]
        [StringLength(10,MinimumLength=3)]
        public string nombre { get; set; }
        public int precio { get; set; }

        public void grabar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = "Server=PMT_LAB0224;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into libro values (@cod,@nom,@pre)";
            cmd.Parameters.AddWithValue("@cod", this.codigo);
            cmd.Parameters.AddWithValue("@nom", this.nombre);
            cmd.Parameters.AddWithValue("@pre", this.precio);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void actualizar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = "Server=PMT_LAB0224;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update libro set nombre=@nom,precio=@pre where codigo=@cod";
            cmd.Parameters.AddWithValue("@cod", this.codigo);
            cmd.Parameters.AddWithValue("@nom", this.nombre);
            cmd.Parameters.AddWithValue("@pre", this.precio);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void eliminar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = "Server=PMT_LAB0224;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from libro where codigo=" + this.codigo;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void leer()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lee;

            conn.ConnectionString = "Server=PMT_LAB0224;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from libro where codigo=" + this.codigo;
            conn.Open();
            lee = cmd.ExecuteReader();
            while (lee.Read())
            {
                this.nombre = lee.GetString(1);
                this.precio = lee.GetInt32(2);
            }
            conn.Close();
        }


        static public List<Libro> Catalogo()
        {
            List<Libro> lista = new List<Libro>();
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lee;

            conn.ConnectionString = "Server=PMT_LAB0224;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from libro";
            conn.Open();
            lee=cmd.ExecuteReader();
            while (lee.Read())
            {
                Libro l = new Libro();
                l.codigo = lee.GetInt32(0);
                l.nombre = lee.GetString(1);
                l.precio = lee.GetInt32(2);
                lista.Add(l);
            }
            conn.Close();
            return lista;
        }
    }
}