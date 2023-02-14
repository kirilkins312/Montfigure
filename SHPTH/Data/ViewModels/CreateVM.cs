using SHPTH.Models;
using SHPTH.Models.Categories;

namespace NewSHPTH.Data.ViewModels
{
    public class CreateVM
    {
        //public List<d>
        public int Id { get; set; }
        public string Brand { get; set; }
        public string IMGURL { get; set; }
        public int CloId { get; set; }
        public int SizeId{ get; set;}
        public GenderSeparation GenSep { get; set; }
        public double Price { get; set; }
    }
}
