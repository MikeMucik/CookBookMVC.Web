using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.Services;
using CookBookMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CookBookMVC.Web.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
			_userService = userService;
            
        }
        public IActionResult Index()
		{
			//utworzyć widok dla tej akcji
			//tabela z użytkowanikami
			//filtrowanie użytkowników
			//przygotować dane
			//przekazać filtry do serwisu
			//serwis musi przygotować 
			//serwis musi zwrócić dane w odpowiednim formacie

			var model = _userService.GetAllUsersForList();
			return View(model);
		}

		[HttpGet]
		public IActionResult AddUser()
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult AddUser(UserModel model)
		//{
		//	var id = _userService.AddUser(model);
		//	return View();
		//}

		[HttpGet]
		public IActionResult AddNewUserInformation(int userId)
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult AddNewUserInformation(UserInformationModel model)
		//{
		//	return View(model);
		//}

		public IActionResult ViewUser(int userId)
		{
			var userModel = _userService.GetUser(userId);
			return View(userModel);
		}
	}
}
