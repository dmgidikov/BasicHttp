namespace BasicWebServer.Demo.Controllers
{
    using Server.HTTP;
    using Server.Controllers;

    public class UserController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method = 'POST'>
Username: <input type='text' name='Username'/>
Password: <input type='text' name='Password'/>
<input type='submit' value='Log In'/>
</form>";

        private const string UserName = "user";

        private const string Password = "user123";

        public UserController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            Request.Session.Clear();

            var usernameMatches = Request.Form["Username"] == UserName;
            var passwordMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection
                    {
                        { Session.SessionCookieName, Request.Session.Id }
                    };

                    return Html($"<h3>Logged in successfully!</h3>", cookies);
                }

                return Html($"<h3>Logged successfully!</h3>");
            }

            return Redirect("/Login");
        }

        public Response Logout()
        {
            Request.Session.Clear();
            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is with username '{UserName}'</h3>");
            }

            return Redirect("/Login");
        }
    }
}