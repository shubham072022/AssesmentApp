using System.Net;

namespace Todo.Application.Common.Constants
{
    public static class CustomStatusCodes
    {
        //200
        public static int Accepted => Convert.ToInt32(HttpStatusCode.Accepted);

        //400
        public static int BadRequest => Convert.ToInt32(HttpStatusCode.BadRequest);

        //404
        public static int NotFound => Convert.ToInt32(HttpStatusCode.NotFound);

        //500
        public static int InternalServerError => Convert.ToInt32(HttpStatusCode.InternalServerError);
    }
}
