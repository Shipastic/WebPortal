namespace Application.UseCases.DTO
{
    public class SdSlaDTO
    {
        public long Id { get; set; }
        public long SdCatId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual SdCategoryDTO SdCatDTO { get; set; } = null!;
        public virtual ICollection<SdGrpLinkDTO>? SdGrpLinksDTO { get; set; }
    }
}
