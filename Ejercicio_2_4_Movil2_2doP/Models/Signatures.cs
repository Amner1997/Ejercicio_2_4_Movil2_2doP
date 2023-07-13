using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_2_4_Movil2_2doP.Models
{
    public class Signatures
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public byte[] FirmaDigital { get; set; }
    }
}
