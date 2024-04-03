using System.Net;

namespace Pyramids.API.DTOs.Response
{
    public class ResponseDataDto
    {
        public HttpStatusCode Code { get; set; }
        public string Status { get; set; }
        public object Message { get; set; }
        public object Data { get; set; }
    }
}
