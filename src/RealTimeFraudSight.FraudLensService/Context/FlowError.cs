namespace RealTimeFraudSight.FraudLensService.Context
{
    public class FlowError
    {
        public required string Code { get; set; }
        public required string Message { get; set; }
        public required string StackTrace { get; set; }
    }
}