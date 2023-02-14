using SHPTH.Models;
using SHPTH.Models.Categories;

namespace NewSHPTH.Data.ViewModels
{
    public class ShopVM
    {
        public List<Cloth> CloList { get; set; }
        public List<ClothSeparation> clothSeparations { get; set; }
        public List<SizeSeparation> SizeSeparations{ get; set; }
        public int? GenderSeparate { get; set; } = null;
        public int? UnikName { get; set; } = null;
        public int? UnikName2 { get; set; } = null;
        public string? searchString { get; set; } = null;
        public double? MaxPrice { get; set; } = null;
        public double? MinPrice { get; set; } = null;
        public int? reset { get; set; } = null;





    }
}
