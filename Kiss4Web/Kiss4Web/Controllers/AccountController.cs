namespace Kiss4Web.Controllers
{
    //[Route("api/Account")]
    //public class AccountController : Controller
    //{
    //    private readonly ICredentialsValidator _credentialsValidator;
    //    private readonly TimeSpan _validityDuration = TimeSpan.FromDays(2);

    //    public AccountController(ICredentialsValidator credentialsValidator)
    //    {
    //        _credentialsValidator = credentialsValidator;
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    public async Task<IHttpActionResult> Token(KeyValuePair<string, string> tempUserPwd) //string username, string password)
    //    {
    //        var username = tempUserPwd.Key;
    //        var password = tempUserPwd.Value;
    //        var identity = await _credentialsValidator.ValidateCredentials(username, password);
    //        if (identity == null)
    //        {
    //            return BadRequest(Resources.InvalidUsernamePassword);
    //        }

    //        var currentUtc = new SystemClock().UtcNow;
    //        var expiresUtc = currentUtc.Add(_validityDuration);
    //        var ticketProperties = new AuthenticationProperties
    //        {
    //            IssuedUtc = currentUtc,
    //            ExpiresUtc = expiresUtc
    //        };
    //        var ticket = new AuthenticationTicket(identity, ticketProperties);
    //        var token = AuthenticationConfig.OAuthOptions.AccessTokenFormat.Protect(ticket);
    //        var result = new AuthenticationResult()
    //        {
    //            Username = username,
    //            AccessToken = token,
    //            ExpiresUtc = expiresUtc
    //        };
    //        return Ok(result);
    //    }
    //}
}