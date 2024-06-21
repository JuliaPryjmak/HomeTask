namespace ApiProject.Requests
{
    public class ResponseModel<TObject>
    {
        public TObject HttpContentObject { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }
        public string HttpContent { get; set; }
    }
}
