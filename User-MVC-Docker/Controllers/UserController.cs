using Microsoft.AspNetCore.Mvc;
using User_MVC_Docker.Common;
using User_MVC_Docker.DTO;
using User_MVC_Docker.Services;

namespace User_MVC_Docker.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayUsers()
        {
            var userList = await _user.GetUsers();
            return View(userList.ToList());
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO input)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.CreateUser(input);

                if (user.Success)
                {
                    TempData["usercreated"] = BusinessManager.UserCreated;

                    return RedirectToAction("DisplayUsers");
                }
                TempData["exception"] = user.Message;  
            }
            return View(input);
        }
    }
}
