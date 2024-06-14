
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
        public Type GetEnumerableResponseEntityType(string entityName)
        {
            var type = getType<AdminResponseTypeAddNameAttribute>(entityName);

            return typeof(IEnumerable<>).MakeGenericType(type);
        }
        public Type GetResponseEntityType(string entityName)
        {
            var type = getType<AdminResponseTypeAddNameAttribute>(entityName);

            return type;
        }

        public Type GetCreateEntityType(string entityName)
        {
            var type = getType<AdminCreateTypeAddNameAttribute>(entityName);

            return type;
        }

        public List<string> GetEntityTypePropertyNames(Type type)
        {
            return type.GetProperties().Select(p => p.Name).ToList();
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
            TModelTypeAttr : BaseAdminTypeAddNameAttribute
        {
            var type = _assembly.GetTypes().FirstOrDefault(t => t.GetCustomAttribute<TModelTypeAttr>()?.Names.Contains(modelName) == true);

            if (type == null)
            {
                throw new ArgumentException($"{modelName} : {typeof(TModelTypeAttr).Name} does not exist!");
            }

            return type;
        }
    }
}
