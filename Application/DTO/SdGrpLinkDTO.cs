namespace Application.UseCases.DTO
{
    public class SdGrpLinkDTO
    {
        public long Id { get; set; }
        public long GrpObjId { get; set; }
        public long SdSlaId { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }

        public virtual SdGrpObjDTO GrpObjDTO { get; set; } = null!;
        public virtual SdSlaDTO SdSlaDTO { get; set; } = null!;
    }
}
