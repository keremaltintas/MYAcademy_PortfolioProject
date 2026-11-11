namespace MYAcademy_PortfolioProject.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        public string? SkillName { get; set; }

        public int SkillValue { get; set; }

        public string? SkillColor { get; set; }

        public string? SkillIcon { get; set; }

        public string? Description { get; set; }

        public int? ExperienceYear { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        // Foreign Key
        public int SkillCategoryId { get; set; }

        // Navigation Property
        public SkillCategory SkillCategory { get; set; } = null!;
    }
}
