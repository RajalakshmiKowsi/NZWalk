namespace NzWalksAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultId { get; set; }

        //Navigation Property

        public Region Region { get; set; }
        public WalkDifficult WalkDifficult { get; set; }
    }
}
