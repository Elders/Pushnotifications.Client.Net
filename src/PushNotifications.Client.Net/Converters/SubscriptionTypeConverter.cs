using System;
using System.Linq;
using System.Reflection;
using PushNotifications.Api.Client;

namespace PushNotifications.Client.Net
{
    public class SubscriptionTypeConverter : GenericJsonConverter<string, SubscriptionType>
    {
        public override SubscriptionType Convert(string jObject, Type objectType)
        {
            if (ReferenceEquals(jObject, null) == true) return null;
            if (string.IsNullOrEmpty(jObject)) return null;

            return SubscriptionType.Create(jObject);
        }

        public override object GetValue(SubscriptionType instance)
        {
            return instance.ToString();
        }
    }

    public class UrnConverter : GenericJsonConverter<string, IHaveUrn>
    {
        public override IHaveUrn Convert(string jObject, Type objectType)
        {
            if (ReferenceEquals(jObject, null) == true) return null;
            if (string.IsNullOrEmpty(jObject)) return null;

            var constructor = objectType.GetConstructors().SingleOrDefault(x => Match(x));
            var bahyr = (IHaveUrn)constructor.Invoke(new object[] { jObject });
            return bahyr;
        }

        public override object GetValue(IHaveUrn instance)
        {
            return instance.Urn;
        }

        bool Match(ConstructorInfo info)
        {
            var parameterts = info.GetParameters().ToList().OrderBy(x => x.Position).ToList();
            if (parameterts.Count != 1)
                return false;
            return parameterts[0].ParameterType == (typeof(string));
        }
    }
}
