using System;
using System.IO;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.SqlServer.Server;
namespace SigesivServer.Models.StoredProdecuresTypes
{
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true)]
    public class Pago
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public long numDeTarjeta { get; set; }
    }
}
