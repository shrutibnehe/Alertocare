using System.Diagnostics.CodeAnalysis;

namespace AlertToCareAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Vital
    {
        public string Id { get; set; }
        public double Bpm { get; set; }
        public double Spo2 { get; set; }
        public double RespRate { get; set; }
    }
}
