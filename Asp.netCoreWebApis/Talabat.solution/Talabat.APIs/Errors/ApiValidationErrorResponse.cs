namespace Talabat.APIs.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public List<string> Errors { get; set; }

        public ApiValidationErrorResponse() : base(400, "Validation Error")
        {
        }
        public ApiValidationErrorResponse(List<string> errors) : base(400, "Validation Error")
        {
            Errors = errors;
        }

    }
}
