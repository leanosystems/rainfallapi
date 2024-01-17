namespace RainfallApi.Models
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public List<ErrorDetailModel> Detail { get; set; }
    }
}
