using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace WebAppAsset.Models.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }

    public class MainCategory : Entity
    {
        public string MainCategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
        public List<Asset>? Assets { get; set; }
    }


    public class SubCategory : Entity
    {
        public string SubCategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? MainCategoryId { get; set; }
        public MainCategory? MainCategory { get; set; }
        public List<Asset>? Assets { get; set; }
    }

    public class Asset : Entity
    {
        public string AssetName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? MainCategoryId { get; set; }
        public MainCategory? MainCategory { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
    }
}
