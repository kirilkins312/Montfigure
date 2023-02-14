using SHPTH.Models.Categories;

namespace NewSHPTH.Data.ViewModels
{
    public class NewDropDownClo
    {
        public NewDropDownClo()
        {
            ClothSeparations = new List<ClothSeparation>();
            SizeSeparations = new List<SizeSeparation>();
            
        }

        public List<ClothSeparation> ClothSeparations { get; set; }
        public List<SizeSeparation> SizeSeparations { get; set; }
        
    }
}
