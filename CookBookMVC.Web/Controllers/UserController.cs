using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.Services;
using CookBookMVC.Application.ViewModels.User;
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
		[HttpGet]
        public IActionResult Index()
		{
			//utworzyć widok dla tej akcji
			//tabela z użytkowanikami
			//filtrowanie użytkowników
			//przygotować dane
			//przekazać filtry do serwisu
			//serwis musi przygotować 
			//serwis musi zwrócić dane w odpowiednim formacie

			var model = _userService.GetAllUsersForList(2, 1, "");// tu w pierwszej zmiennej podajmy ilośc rekordów na stronę
			return View(model);
		}
		[HttpPost]
		public IActionResult Index(int pageSize, int? pageNo, string searchString)
		{
			if (!pageNo.HasValue)
			{
				pageNo = 1;	
			}
			if (searchString is null)
			{
				searchString = String.Empty;
			}
			var model = _userService.GetAllUsersForList(pageSize, (int)pageNo, searchString);
			return View(model);
		}

		[HttpGet]
		public IActionResult AddUser()
		{
			return View(new NewUserVm());
		}

		[HttpPost]
		public IActionResult AddUser(NewUserVm model)
		{
			var id = _userService.AddUser(model);
			return View();
		}

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
			if (userModel == null)
			{
				return View("Error");
			}
			return View(userModel);
		}
	}
}
