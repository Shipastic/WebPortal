namespace Application.UseCases.DTO
{
    public class SdGrpObjDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<SdGrpLinkDTO>? SdGrpLinksDTO { get; set; }
    }
}
