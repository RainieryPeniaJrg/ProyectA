namespace Be_NetBanking.Core.Application.Wrappers
{
    public class Response  <T>
    {
        public Response()
        {

        }
        public Response(T data,string message = null)
        {
            Succeded = true;
            Data = data;
            Message = message;
           
        }

        public Response(string message)
        {
           Succeded = false;
           Message = message;
        }


        public bool Succeded { get; set; }
        public string Message { get; set; }
        public List<string>  Errors { get; set; }
        public T Data { get; set; }    

    }
}
