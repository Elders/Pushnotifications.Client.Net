using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PushNotifications.Client.Net
{
    public static class SerializerFactory
    {
        static JsonSerializer serializer;

        public static JsonSerializer GetSerializer()
        {
            if (serializer == null)
            {
                var settings = DefaultSettings();
                settings.RegisterContractsConverters();
                serializer = JsonSerializer.Create(settings);
            }

            return serializer;
        }

        static JsonSerializerSettings DefaultSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
            settings.MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            var contractReslover = new PrivateSetterCamelCasePropertyNamesContractResolver();
            settings.ContractResolver = contractReslover;

            return settings;
        }
    }

    public class PrivateSetterCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            return objectType.GetProperties(flags).Cast<MemberInfo>().ToList();
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (prop.Writable)
                return prop;

            var property = member as PropertyInfo;
            if (ReferenceEquals(null, property))
                return prop;

            prop.Writable = property.DeclaringType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Any(m => m.Name == "set_" + property.Name);

            return prop;
        }
    }

    public static class JsonConverterRegistration
    {
        public static void RegisterContractsConverters(this JsonSerializerSettings settings)
        {
            var assemblies = new[]
            {
                typeof(JsonConverterRegistration).Assembly,
            };
            var converters = assemblies.SelectMany(x => x.GetTypes()).Where(x => typeof(JsonConverter).IsAssignableFrom(x) && x.IsAbstract == false);

            foreach (var converterType in converters.Union(converters))
            {
                JsonConverter converter = Activator.CreateInstance(converterType) as JsonConverter;
                settings.Converters.Add(converter);
            }
        }
    }
}
