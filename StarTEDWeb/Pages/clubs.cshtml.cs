using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarTEDsystem.BLL;
using StarTEDsystem.Entities;

namespace StarTEDWeb.Pages
{
    public class ClubsModel : PageModel
    {
        #region Define a CategoryServices field and initialize it using constructor injection
        private readonly ClubServices _clubServices;
        public ClubsModel(ClubServices clubServices)
        {
            _clubServices = clubServices;
        }
        #endregion

        #region Define properties for data access by the page
        [TempData]
        public string FeedbackMessage { get; set; }

        public List<Club> CategoryList { get; set; } = new();
        #endregion

        #region Define code that gets executed when the page is accessed using a HTTP GET request
        public void OnGet()
        {
            // Fetch a list of category from the database using our BLL object
/*            CategoryList = _clubServices.Club_List();
*/        }
        #endregion

        public IActionResult Edit(bool active)
        {
            return RedirectToPage();
        }

    }
}
