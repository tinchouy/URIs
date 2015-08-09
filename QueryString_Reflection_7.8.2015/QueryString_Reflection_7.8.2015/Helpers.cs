using System;
using System.Collections;
using System.Web;
using System.Collections.Specialized;
using System.Linq;
using System.Collections.Generic;

namespace Helpers
{
    public static class Helpers
    {
        public static string ToQueryString(this object _request, string _separador = ",")
        {
            if(_request == null)
            {
                throw new ArgumentNullException("_request");
            }

            // Obtener todos las propiedades del objeto
            var propiedades = _request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(_request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(_request, null));

            // Obtener todos los nombres para todos las propiedades IEnumrable (excluyendo strings)
            var nombres = propiedades
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concatenar todas las propiedades IEnumerable en un string separado por comas
            foreach (var i in nombres)
            {
                var tipoValor = propiedades[i].GetType();
                var tipoElemValor = tipoValor.IsGenericType
                    ? tipoValor.GetGenericArguments()[0]
                    : tipoValor.GetElementType();
                
                if (tipoElemValor.IsPrimitive || tipoElemValor == typeof(string))
                {
                    var enumerable = propiedades[i] as IEnumerable;
                    propiedades[i] = string.Join(_separador, enumerable.Cast<object>());
                }
            }

            // Crear un QueryString a partir de los indices / valores
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            
            foreach (var pair in propiedades)
            {
                queryString[pair.Key] = pair.Value.ToString();
            }

            // Devuelve el QueryString como string
            return queryString.ToString();
        }

        public static string ToURL(this string _qs, string _url)
        {
            if (!(_qs is string) || 
                !(_qs is string) || 
                _qs == null || 
                _url == null)
                throw new ArgumentNullException("_qs");

            return string.Concat(_url, "?", _qs);
        }
    }
}
