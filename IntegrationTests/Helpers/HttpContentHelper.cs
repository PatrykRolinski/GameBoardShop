using FluentValidation.Internal;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntegrationTests.Helpers;

   public static class HttpContentHelper
   {
       public static HttpContent ToFormUrlEncodedContent(this object obj)
       {

        var objType = obj.GetType();

        var properties = objType.GetProperties();

        var keyValuePairsList= new List<KeyValuePair<string, string>>();

        foreach ( var property in properties)
        {
            var propertyValue= property.GetValue(obj);

            if(propertyValue is not null)
            {
                var propertyType = propertyValue.GetType();
                if (propertyType == typeof(string) || propertyType.IsPrimitive)
                {
                    keyValuePairsList.Add(new KeyValuePair<string, string>(property.Name, propertyValue.ToString()!));
                }
            }
        }

        var formUrlEncodedContent = new FormUrlEncodedContent(keyValuePairsList);

        return formUrlEncodedContent;
       }
   }

