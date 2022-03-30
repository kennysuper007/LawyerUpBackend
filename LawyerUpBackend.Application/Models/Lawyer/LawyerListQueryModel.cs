using LawyerUpBackend.Application.Dtos;

namespace LawyerUpBackend.Application.Models.Lawyer
{
    public class LawyerListQueryModel:PagedSortedAndFilterInput
    {
        public LawyerListQueryModel()
        {
            Sorting = "Name";
            FilterText = "";
        }
        public string? Name { get; set; }
        public string? Sex { get; set; }

        
    }
}
