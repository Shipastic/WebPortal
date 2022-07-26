namespace Application.UseCases.DTO
{
    public class ContractorDTO
    {
        public long Id { get; set; }
        public long EntId { get; set; }
        public long CityId { get; set; }
        public long ContractorTypeId { get; set; }
        public string? Inn { get; set; }
        public string? Bic { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public DateTime RegDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime NextRegDate { get; set; }
        public DateTime NextCloseDate { get; set; }
        public long BoardId { get; set; }
        public long EstablishmentId { get; set; }
        public string? Note { get; set; }
    }
}
