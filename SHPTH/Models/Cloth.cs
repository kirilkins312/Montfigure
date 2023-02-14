using SHPTH.Data.Base;
using SHPTH.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SHPTH.Models
{
    public class Cloth 
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        [Display(Name ="Image")]
        public string IMGURL { get; set; }
        [Display(Name = "Type")]
        public int CloId { get; set; }
        [ForeignKey(nameof(CloId))]
        public Categories.ClothSeparation ClothSepar{ get; set; }
        //[Display(Name = "Size")]
        //public SizeSeparation SizeSeparation{ get; set; }
        public int SizeId { get; set; }
        [Display(Name = "Size")]
        [ForeignKey(nameof(SizeId))]
        public Categories.SizeSeparation SizeSep { get; set; }    
        public GenderSeparation GenderSeparation { get; set; }
        public double Price { get; set; }
    }
}
