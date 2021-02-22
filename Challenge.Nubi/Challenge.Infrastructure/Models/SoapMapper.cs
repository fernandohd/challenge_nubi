using Challenge.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Infrastructure.Models
{
    public interface ISoapMapper<TModelBase> where TModelBase : SoapDataBaseModel
    {
        TModel MapToModel<TModel>(string[] respuestaSoap);
        IEnumerable<TModelBase> MapToModelCollection(IEnumerable<string[]> entities);
    }

    public class SoapMapper<TModelBase> : ISoapMapper<TModelBase> where TModelBase : SoapDataBaseModel
    {
        private const int LongitudCabecera = 3;
        private const int PosicionEstado = 1;
        private const int PosicionLongitudDatos = 2;

        private readonly ILogger<SoapMapper<TModelBase>> logger;

        public SoapMapper(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SoapMapper<TModelBase>>();
        }

        public TModel MapToModel<TModel>(string[] respuestaSoap)
        {
            if (respuestaSoap.Length < (LongitudCabecera - 1))
            {
                throw new Exception("Formato de cabecera inválido");
            }

            if (respuestaSoap[PosicionEstado].ToUpper() != "OK")
            {
                throw new Exception("Error en cabecera");
            }

            int longitudDatos = ObtenerLongitudDeDatos(respuestaSoap);

            var matrizDeDatos = new Dictionary<string, string>(longitudDatos)
            {
                { SoapDataBaseModel.EstadoNombre, respuestaSoap[PosicionEstado].ToUpper() }
            };

            for (int i = 0; i < longitudDatos; i++)
            {
                string campo = respuestaSoap[LongitudCabecera + i];
                string valor = respuestaSoap[LongitudCabecera + longitudDatos + i];

                if (!matrizDeDatos.ContainsKey(campo))
                {
                    matrizDeDatos.Add(campo, valor);
                }
                else
                {
                    logger.LogWarning("Clave de campo duplicada (campo)", campo);
                }
            }

            string[] datos = matrizDeDatos.Values.ToArray();

            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), datos);

            return model;
        }

        public IEnumerable<TModelBase> MapToModelCollection(IEnumerable<string[]> entities)
        {
            return entities.Select(x => MapToModel<TModelBase>(x));
        }

        private int ObtenerLongitudDeDatos(string[] respuestaSoap)
        {
            if (!int.TryParse(respuestaSoap[PosicionLongitudDatos], out int longitudDatos))
            {
                throw new Exception("Longitud de datos inválida");
            }

            return longitudDatos;
        }
    }
}