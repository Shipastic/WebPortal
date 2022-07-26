namespace Application.UseCases.DTO
{
    public class SdCategoryDTO
    {
        public long Id { get; set; }
        public long SdServId { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }
        public string? Priority { get; set; }

        public virtual SdServiceDTO SdServDTO { get; set; } = null!;
        public virtual ICollection<SdSlaDTO>? SdSlasDTO { get; set; }
    }
}
