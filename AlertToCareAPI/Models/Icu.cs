using System.Diagnostics.CodeAnalysis;

namespace AlertToCareAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Icu
    {
        public string Id { get; set; }
        public int BedCount { get; set; }
        public string LayoutId { get; set; }
    }
}
