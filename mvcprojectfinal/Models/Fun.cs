namespace mvcprojectfinal.Models
{
    public class Fun
    {
        public int Id { get; set; }
        public bool IsOpenBuffit { get; set; }
        public bool IsContaintsSwimmingPool { get; set; }
        public bool IsContainsBeach { get; set; }
        public bool IsContainsAquaBark { get; set; }
        public bool IsContainsDesco { get; set; }
        public int Stars { get; set; }
        public bool IsHavingParking { get; set; }
        public bool IsHavingKidsArea { get; set; }
        public bool IsHavingElevator { get; set; }
        public List<Hotels> hotels { get; set; }
    }
}
