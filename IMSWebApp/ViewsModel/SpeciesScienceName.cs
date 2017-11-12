using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMSWebApp.ViewsModel
{
    public class SpeciesScienceName
    {
        public string SpeciesID { get; set; }
        public SelectList ScientificList { get; set; }
    }
}
