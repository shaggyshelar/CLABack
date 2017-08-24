using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance.Helper
{
    public static class DataMapper
    {
        public static void MapObject(object model, AttributeCollection fields)
        {
            PropertyInfo[] propperties = model.GetType().GetProperties();
            foreach (PropertyInfo prop in propperties)
            {
                Attribute bindable = prop.GetCustomAttribute(typeof(Bindable));
                if (bindable != null)
                {
                    var attribute = fields.Where(a => a.Key == prop.Name).ToList();
                    if (attribute.Count > 0 && null != prop && prop.CanWrite)
                    {
                        AliasedValue value = (AliasedValue)attribute[0].Value;
                        if (value.Value.GetType() == typeof(OptionSetValue))
                        {
                            prop.SetValue(model, ((OptionSetValue)value.Value).Value.ToString(), null);
                        }
                        else if (value.Value.GetType() == typeof(Money))
                        {
                            prop.SetValue(model, ((Money)value.Value).Value, null);
                        }
                        else if (value.Value.GetType() == typeof(EntityReference))
                        {
                            prop.SetValue(model, ((EntityReference)value.Value).Id, null);
                        }
                        else if (value.Value.GetType() == typeof(Guid))
                        {
                            prop.SetValue(model, ((Guid)value.Value), null);
                        }
                        else
                            prop.SetValue(model, value.Value, null);
                    }
                }
            }
        }
    }
}
