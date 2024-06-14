using System.Reflection;

namespace Reviewer.Services.Implemintations
{
    public class FormGenerationService
    {
        private ReviewerApiService _reviewerApiServcie { get; set; }
        private EntityTypesService _entityTypesService { get; set; }

        public FormGenerationService(ReviewerApiService reviewerApiService, EntityTypesService entityTypesService)
        {
            _entityTypesService = entityTypesService;
            _reviewerApiServcie = reviewerApiService;
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
    }
}
