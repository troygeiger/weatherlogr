using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper.Internal;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;
using weatherlogr.Repository.MySql.Internal;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql.Repositories
{
    public sealed class ConfigurationRepository : IConfigurationRepository
    {
        private static Dictionary<Type, ClassMetadata> entryMetadata;
        private static JsonSerializerOptions jsonOptions;

        static ConfigurationRepository()
        {
            entryMetadata = new Dictionary<Type, ClassMetadata>();
            jsonOptions = new();
            jsonOptions.Converters.Add(new JsonColorConverter());
        }

        static ClassMetadata GetClassMetadata(Type type)
        {
            if (entryMetadata.TryGetValue(type, out ClassMetadata? metadata))
            {
                return metadata;
            }

            metadata = new();
            metadata.Constructor = type.GetConstructors().FirstOrDefault(w => w.GetParameters().Length == 0);
            if (metadata.Constructor is null)
                throw new ArgumentOutOfRangeException($"Type {type.FullName} does not contain a parameterless constructor!");
            metadata.Properties = type.GetProperties();
            metadata.ClassName = type.FullName ?? type.Name;
            entryMetadata.Add(type, metadata);
            return metadata;
        }

        private readonly WeatherContext context;

        public ConfigurationRepository(WeatherContext context)
        {
            this.context = context;

        }

        public T GetValue<T>() where T : class
        {
            var metadata = GetClassMetadata(typeof(T));

            T entry = (T)metadata.Constructor!.Invoke(null);

            foreach (ObjectProperty item in context.ObjectProperties.Where(c => c.ClassName == metadata.ClassName))
            {
                var property = metadata.Properties.FirstOrDefault(p => p.Name == item.EntryName);
                if (property is null) continue;
                bool isNullable = property.PropertyType.IsNullableType();
                var propTypeCode = isNullable
                    ? Type.GetTypeCode(property.PropertyType.GenericTypeArguments[0])
                    : Type.GetTypeCode(property.PropertyType);

                switch (propTypeCode)
                {
                    case TypeCode.String:
                        property.SetValue(
                            entry,
                            isNullable ? item.StringValue : item.StringValue ?? property.GetValue(entry));
                        break;

                    case TypeCode.Char:
                        property.SetValue(
                            entry,
                            isNullable ? (item.StringValue is null ? null : (item.StringValue.Length > 0 ? item.StringValue[0] : null))
                                : item.StringValue is not null && item.StringValue.Length > 0 ? item.StringValue[0] : '\0'
                        );
                        break;

                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Byte:
                        property.SetValue(
                            entry,
                            isNullable ? item.IntValue : item.IntValue ?? property.GetValue(entry)
                        );
                        break;

                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        property.SetValue(
                            entry,
                            isNullable ? item.DecimalValue : item.DecimalValue ?? property.GetValue(entry)
                        );
                        break;

                    case TypeCode.Boolean:
                        property.SetValue(
                            entry,
                            isNullable ? item.BoolValue : item.BoolValue ?? property.GetValue(entry)
                        );
                        break;

                    case TypeCode.DateTime:
                        if (DateTime.TryParse(item.StringValue, out DateTime result))
                            property.SetValue(entry, result);
                        break;

                    case TypeCode.Object:
                        SetComplexProperty(entry, property, item, isNullable);
                        break;

                    default:
                        break;
                }
            }

            return entry;
        }

        private void SetComplexProperty(object entry,
                                        PropertyInfo property,
                                        ObjectProperty configEntity,
                                        bool isNullable)
        {
            if (isNullable && configEntity.StringValue is null) return;
            try
            {
                object? value = JsonSerializer.Deserialize(configEntity.StringValue!, property.PropertyType, jsonOptions);
                property.SetValue(entry, value);
            }
            catch (System.Exception)
            {
            }
        }

        public void SaveValue<T>(T value)
            where T : class
        {
            var metadata = GetClassMetadata(typeof(T));

            var entities = context.ObjectProperties.Where(c => c.ClassName == metadata.ClassName).ToArray();

            foreach (PropertyInfo property in metadata.Properties)
            {
                var entity = entities.FirstOrDefault(e => e.EntryName == property.Name);
                if (entity is null)
                {
                    entity = new()
                    {
                        ClassName = metadata.ClassName,
                        EntryName = property.Name
                    };
                    context.ObjectProperties.Add(entity);
                }

                bool isNullable = property.PropertyType.IsNullableType();
                var propType = isNullable ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;
                var propTypeCode = Type.GetTypeCode(propType);

                object? propValue = property.GetValue(value);

                switch (propTypeCode)
                {
                    case TypeCode.String:
                        entity.StringValue = propValue as string;
                        break;
                    case TypeCode.Char:
                        entity.StringValue = (propValue as char? ?? '\0').ToString();
                        break;
                    case TypeCode.Boolean:
                        entity.BoolValue = propValue as bool?;
                        break;
                    case TypeCode.DateTime:
                        DateTime? dt = propValue as DateTime?;
                        entity.StringValue = dt?.ToString("O");
                        break;
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                        entity.IntValue = propValue is null ? null : Convert.ChangeType(propValue, typeof(int)) as int?;
                        break;
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                        entity.LongValue = propValue is null ? null : Convert.ChangeType(propValue, typeof(long)) as long?;
                        break;
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        entity.DecimalValue = propValue is null ? null : Convert.ChangeType(propValue, typeof(decimal)) as decimal?;
                        break;
                    case TypeCode.Object:
                        entity.StringValue = propValue is null ? null : JsonSerializer.Serialize(propValue, property.PropertyType, jsonOptions);
                        break;
                    default:
                        break;
                }


            }

            // Remove Entities that are not part of the object.
            context.ObjectProperties.RemoveRange(from e in entities
                                                     join p in metadata.Properties on e.EntryName equals p.Name into pG
                                                     from loP in pG.DefaultIfEmpty()
                                                     where loP is null
                                                     select e);


            context.SaveChanges();
        }



    }
}