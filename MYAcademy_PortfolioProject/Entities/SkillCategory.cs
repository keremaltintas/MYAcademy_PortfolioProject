using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class SkillCategory
    {
        public int SkillCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = null!;

        [StringLength(250)]
        public string? Description { get; set; }

        public string? CategoryIcon { get; set; }

        public string? CategoryColor { get; set; }
        public string CategoryBackgroundColor { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        // Bir kategorinin birden fazla yeteneği olabilir.
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}