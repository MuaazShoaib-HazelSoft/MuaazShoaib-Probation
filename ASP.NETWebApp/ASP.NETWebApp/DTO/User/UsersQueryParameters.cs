using ASP.NETWebApp.Models;

namespace ASP.NETWebApp.DTO.User
{
    public class UsersQueryParameters
    {
        public string SearchItem { get; set; } = "";
        public string SortBy { get; set; } = "";
        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 1;
        public bool isDescending { get; set; } = false;
    }
}
