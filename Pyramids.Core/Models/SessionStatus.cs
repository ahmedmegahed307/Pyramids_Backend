namespace Pyramids.Core.Models
{
    public class SessionStatus    
    {
        public int Id { get; set; }
        public required string SessionStatusCode { get; set; }
        public required string Name { get; set; }
        public double StepOrder { get; set; }
    }
}
