namespace LogErrorWebApi.Models
{
    public class ErrorReport
    {
        public int Id { get; set; }
        public string Headline { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Recreate { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
        public string ActualResult { get; set; } = string.Empty;
        public int Frequency { get; set; }
        public string SystemInfo { get; set; } = string.Empty;
    }
}
