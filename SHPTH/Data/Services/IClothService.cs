using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeFixes;
using NewSHPTH.Data.ViewModels;
using SHPTH.Data.ViewModels;
using SHPTH.Models;
using SHPTH.Models.Categories;

namespace SHPTH.Data.Services
{
    public interface IClothService
    {

        List<Cloth> GetCloList(int GenSep);
        List<Cloth> ResetFilters(int GenSep);
        List<ClothSeparation> GetCloSepList();
        List<SizeSeparation> GetSizeSepList();
        List<Cloth> GetFilteredCloList(ShopVM shVM);
        Task AddAsync(CreateVM data);
        Task UpdateAsync(CreateVM data);
        Task<Cloth> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<NewDropDownClo> GetNewMovieDropdownsValues();
      


    }
}
