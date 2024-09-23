
using System.Reflection;
using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Implemintations
{
    public class EntityTypesService
    {
        private readonly Assembly _assembly;

        public EntityTypesService()
        {
            _assembly = typeof(AdminApiPathAttribute).Assembly;
        }
        public Type GetEnumerableEntityType<TAttr>(string entityName) where
            TAttr : BaseAdminTypeApiNameAttribute
        {
            var type = getType<TAttr>(entityName);

            return typeof(IEnumerable<>).MakeGenericType(type);
        }
        public Type GetEnumerableEntityType<TAttr>(Type entityType) where
            TAttr : BaseAdminTypeApiNameAttribute
        {
            return typeof(IEnumerable<>).MakeGenericType(entityType);
        }

        public Type GetEntityType<TAttr>(string entityName) where
            TAttr : BaseAdminTypeApiNameAttribute
        {
            var type = getType<TAttr>(entityName);

            return type;
        }

        public IEnumerable<PropertyInfo> GetSimpleProps(Type entityType)
        {
            return entityType.GetProperties().Where(p => p.PropertyType.IsPrimitive ||
                p.PropertyType == typeof(string) ||
                p.PropertyType == typeof(TimeOnly) ||
                p.PropertyType == typeof(DateOnly) ||
                p.PropertyType == typeof(DateTime));
        }

        public IEnumerable<string> GetCollectionReferenceProps(Type entityType)
        {
            var props = entityType.GetProperties().Where(p => p.PropertyType.IsGenericType ?
                p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) :
                false).Select(p => p.Name);

            return props;
        }

        public IEnumerable<string> GetReferenceProps(Type entityType)
        {
            var props = entityType.GetProperties()
                .Where(p => p.PropertyType == typeof(Guid) && p.Name != "Id")
                .Select(p => p.Name);

            return props;
        }

        public string GetEntityObjectPropertyValue(object entity, string propertyName)
        {
            return entity.GetType().GetProperty(propertyName).GetValue(entity)?.ToString();
        }

        public string GetPropertyPath(Type type, string propName)
        {
            return type.GetProperty(propName).GetCustomAttribute<AdminApiPathAttribute>()?.Value ?? propName;
        }

        private Type getType<TModelTypeAttr>(string modelName) where
            TModelTypeAttr : BaseAdminTypeApiNameAttribute
        {
            var type = _assembly.GetTypes().FirstOrDefault(t => t.GetCustomAttribute<TModelTypeAttr>()?.Name == modelName);

            if (type == null)
            {
                throw new ArgumentException($"{modelName} : {typeof(TModelTypeAttr).Name} does not exist!");
            }

            return type;
        }
    }
}
