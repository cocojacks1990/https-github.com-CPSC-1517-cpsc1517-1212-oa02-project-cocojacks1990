using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarTEDsystem.BLL;
using StarTEDsystem.Entities;
using StarTEDWeb.Helpers;

namespace StarTEDWeb.Pages
{
    public class EmployeesModel : PageModel
    {
        #region Define a CategoryServices field and initialize it using constructor injection
        private readonly ClubServices _clubServices;
        private readonly EmployeeServices _employeeServices;
        public EmployeesModel(ClubServices clubServices, EmployeeServices employeeServices)
        {
            _clubServices = clubServices;
            _employeeServices = employeeServices;
        }
        #endregion

        #region Define properties for data access by the page
        [TempData]
        public string FeedbackMessage { get; set; }

        public List<Club> CategoryList { get; set; } = new();
        public List<Employee> EmployeeIDList { get; private set; } = new();
        #endregion

        #region Define code that gets executed when the page is accessed using a HTTP GET request
        [BindProperty(SupportsGet = true)]
        public bool selectedRadioButton { get; set; } = true;

        #region Paginator
        private const int PAGE_SIZE = 5;

        public Paginator Pager { get; set; }
        #endregion
        public void OnGet(int? currentPage)
        {
            {
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                PageState current = new(pagenumber, PAGE_SIZE);
                int totalcount;

                CategoryList = _clubServices.Club_List(selectedRadioButton, PAGE_SIZE, pagenumber, out totalcount);
                EmployeeIDList = _employeeServices.employee_byID();

                Pager = new Paginator(totalcount, current);

                FeedbackMessage = $"Search returned {CategoryList.Count} result(s).";
                


            }
        }
        #endregion
    
        public IActionResult OnPostList()
        {
            return RedirectToPage(new { selectedRadioButton = selectedRadioButton });
        }







    }
}
