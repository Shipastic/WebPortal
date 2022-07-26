namespace Application.UseCases.DTO
{
    public class SdServiceDTO
    {
        public long Id { get; set; }
        public long SdCompId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual SdCompanyDTO SdCompDTO { get; set; } = null!;
        public virtual ICollection<SdCategoryDTO>? IrisSdCategoriesDTO { get; set; }
    }
}
