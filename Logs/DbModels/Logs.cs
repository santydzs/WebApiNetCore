using System;
using System.Collections.Generic;

namespace Log.DbModels
{
    public partial class Logs
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string LineaCodigo { get; set; }
        public string Mensaje { get; set; }
    }
}
