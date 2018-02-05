using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Exception
{
    public class TextPlainErrorResult: IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpRequestMessage Request { get; set; }
        public string Content { get; set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(this.StatusCode);
            response.Content = new StringContent(Content);
            response.RequestMessage = Request;
            return Task.FromResult(response);
        }
    }
}