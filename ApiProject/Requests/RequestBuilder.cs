using ApiProject.Models.Serialize;

namespace ApiProject.Requests
{
    public class RequestBuilder
    {
        public SResetLoginFailTotal ResetLoginFailBody(string username)
        {
            var ResetBody = new SResetLoginFailTotal()
            {
                Username = username
            };

            return ResetBody;
        }
    }
}
