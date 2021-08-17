using OneSignalTask.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneSignalTask.Services.Interfaces
{
    public interface IOneSignalService
    {

        /// <summary>
        /// Gets the collection of Apps via sending GET async request to the OneSignal.
        /// </summary>
        /// <returns>The collection of Apps if the request was successful, else throws an exception.</returns>
        Task<IEnumerable<App>> GetAppsAsync();

        /// <summary>
        /// Gets the App via sending GET async request to the OneSignal.
        /// </summary>
        /// <param name="id">The unique identifier of the App.</param>
        /// <returns>The App if the request was successful, else throws an exception.</returns>
        Task<App> GetAppAsync(string id);

        /// <summary>
        /// Gets the created App via sending POST async request to the OneSignal.
        /// </summary>
        /// <param name="app">The new App.</param>
        /// <returns>The created App if request was executed successfully, else throws an exception.</returns>
        Task<App> CreateAppAsync(App app);

        /// <summary>
        /// Gets the updated App via sending PUT async request to the OneSignal.
        /// </summary>
        /// <param name="app">The App with the edited parameters.</param>
        /// <returns>The updated App if request was executed successfully, else throws an exception.</returns>
        Task<App> UpdateAppAsync(App app);
    }
}
