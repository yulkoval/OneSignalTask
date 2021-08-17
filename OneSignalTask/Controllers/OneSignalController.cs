using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneSignalTask.Domain.Models;
using OneSignalTask.Services.Interfaces;
using System.Threading.Tasks;

namespace OneSignalTask.Controllers
{
    public class OneSignalController : Controller
    {
        private readonly IOneSignalService _oneSignalService;

        public OneSignalController(IOneSignalService oneSignalService)
        {
            _oneSignalService = oneSignalService;
        }

        /// <summary>
        /// HTTP GET request to "/OneSignal".
        /// Available to all users.
        /// </summary>
        /// <returns>Index view with the IEnumerable of Apps.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _oneSignalService.GetAppsAsync());
        }

        /// <summary>
        /// HTTP GET request to "/OneSignal/Details/{id}".
        /// Gets the App detail information by specified id.
        /// Available to all users.
        /// </summary>
        /// <param name="id">The unique identifier of App.</param>
        /// <returns>Details view with information about the App.</returns>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            App app = await _oneSignalService.GetAppAsync(id);

            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        /// <summary>
        /// HTTP GET request to "/OneSignal/Create".
        /// Allows the user to create an App.
        /// Available to users with the role "Admin".
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// HTTP POST request to "/OneSignal/Create".
        /// Available to users with the role "Admin".
        /// </summary>
        /// <param name="app">The new App, created by the user.</param>
        /// <returns>Index view if the App was created, else Create view with entered App's parameters.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(App app)
        {
            if (ModelState.IsValid && app.Name != null)
            {
                await _oneSignalService.CreateAppAsync(app);
                return RedirectToAction(actionName: nameof(Index));
            }
            else
            {
                return View(app);
            }
        }

        /// <summary>
        /// HTTP GET request to "/OneSignal/Edit/{id}".
        /// Allows the user to edit the App.
        /// Available to users with the role "Admin".
        /// </summary>
        /// <param name="id">The unique identifier of the App.</param>
        /// <returns>Bed Request if the id is null, Not Found if there is no App with the same unique identifier, else Edit view with entered App's parameters.</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            App app = await _oneSignalService.GetAppAsync(id);

            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        /// <summary>
        /// HTTP POST request to "/OneSignal/Edit".
        /// Validates App and sends request request to update its data.
        /// Available to users with the role "Admin".
        /// </summary>
        /// <param name="app">The App with the edited parameters.</param>
        /// <returns>Index view if App was updated, else Edit view with entered App's parameters.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(App app)
        {
            if (ModelState.IsValid && app.Name != null)
            {
                await _oneSignalService.UpdateAppAsync(app);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(app);
            }
        }
    }
}
