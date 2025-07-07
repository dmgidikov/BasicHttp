namespace BasicWebServer.Server.Controllers
{
    using HTTP;
    using Responses;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller(Request request)
        {
            Request = request;
        }

        protected Request Request { get; private init; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string html, CookieCollection? cookies = null)
        {
            var response = new HtmlResponse(html);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }
            return response;
        }

        protected Response BadRequest() => new BadReqeustResponse();

        protected Response Unauthorized() => new UnauthorizedResponse();

        protected Response NotFound() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string filePath) => new TextFileResponse(filePath);

        protected Response View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName());

        protected Response View(object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName(), model);

        private string GetControllerName()
            => GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}