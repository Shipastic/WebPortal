namespace Application.UseCases.DTO
{
    public class SdCompanyDTO
    {
        public long Id { get; set; }
        public string? NameIs { get; set; }
        public string? NameIs2 { get; set; }
        public string? Note { get; set; }
        public string? OtrsValue { get; set; }
        public long? CntId { get; set; }

        public virtual ICollection<SdServiceDTO>? SdServicesDTO { get; set; }
    }
}
