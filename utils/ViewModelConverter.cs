
using Microsoft.Data.SqlClient;
using SigesivServer.Models;
using System;

namespace SigesivServer.utils
{
    public class ViewModelConverter
    {
        public static ViewModel_detalleDePolizaDeConductor convertToPolizaViewModel(SqlDataReader reader) {
            ViewModel_detalleDePolizaDeConductor polizaCreada = new ViewModel_detalleDePolizaDeConductor();
            while (reader.Read())
            {
                polizaCreada.idAsegurado = (int)reader[0];
                polizaCreada.fechaDeNacimiento = (DateTime)reader[1];
                polizaCreada.nombreCompleto = (string)reader[2];
                polizaCreada.numeroDeLicencia = (string)reader[3];
                polizaCreada.celular = (string)reader[4];
                polizaCreada.idPoliza = (int)reader[5];
                polizaCreada.numeroDePoliza = (string)reader[6];
                polizaCreada.fechaDeInicio = (DateTime)reader[7];
                polizaCreada.fechaDeExpiracion = (DateTime)reader[8];
                polizaCreada.tipoDeCobertura = (string)reader[9];
                polizaCreada.lapsoDeCobertura = (int)reader[10];
                polizaCreada.marca = (string)reader[11];
                polizaCreada.modelo = (string)reader[12];
                polizaCreada.numeroDePlacas = (string)reader[13];
                polizaCreada.año = (int)reader[14];
                polizaCreada.color = (string)reader[15];

            }
            reader.Close();
            return polizaCreada;   
        }
    }
}
