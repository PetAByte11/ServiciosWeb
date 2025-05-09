namespace API.Controllers;

using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
public class BuggyController(DataContext context): BaseApiController
=======
public class BuggyController(DataContext context) : BaseApiController
>>>>>>> datingapp/main
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth() => "secret text";

    [HttpGet("not-found")]
    public ActionResult<string> GetNotFound() => NotFound();

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
<<<<<<< HEAD
        try{
            var result = context.Users.Find(-1) ??
            throw new ArgumentException("Server error ocurred!");
            return "random text";
        }
        catch (ArgumentException) //Changed the ex var
        {
            return StatusCode(500, "No way!");
        }
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest() => BadRequest("Bad request happend");

=======
        var result = context.Users.Find(-1) ??
            throw new ArgumentException("Server error occured!");
        return "random text";
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest() => BadRequest("Bad request happened");
>>>>>>> datingapp/main
}