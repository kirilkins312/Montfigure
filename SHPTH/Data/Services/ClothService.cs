using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.EntityFrameworkCore;
using NewSHPTH.Data.ViewModels;
using SHPTH.Data.ViewModels;
using SHPTH.Models;
using SHPTH.Models.Categories;

namespace SHPTH.Data.Services
{
    public class ClothService : IClothService
    {
        private readonly SHPTHContext _context;
        public ClothService(SHPTHContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CreateVM data)
        {
            var newCloth = new Cloth()
            {
                Brand = data.Brand,
                IMGURL = data.IMGURL,
                CloId = data.CloId,
                SizeId= data.SizeId,
                GenderSeparation= data.GenSep,
                Price = data.Price,
              
            };
            await _context.Cloth.AddAsync(newCloth);
            await _context.SaveChangesAsync();

           
            
            await _context.SaveChangesAsync();


        }

        public async Task UpdateAsync(CreateVM data)
        {

            var cloth = await _context.Cloth.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (cloth != null)
            {
                cloth.Brand = data.Brand;
                cloth.IMGURL = data.IMGURL;
                cloth.CloId = data.CloId;
                cloth.SizeId = data.SizeId;
                cloth.GenderSeparation = data.GenSep;
                cloth.Price = data.Price;
              
                await _context.SaveChangesAsync();
            };


        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Cloth.FirstOrDefaultAsync(x=>x.Id == id);
             _context.Cloth.Remove(item);
            await _context.SaveChangesAsync();  
                
        }

        public async Task<Cloth> GetByIdAsync(int id)
        {
           var cloth = await _context.Cloth.FirstOrDefaultAsync(x=>x.Id == id);
           return cloth;
        }
       

        public List<Cloth> GetCloList(int GenSep)
        {
           var cloth = _context.Cloth.Where(x=>((int)x.GenderSeparation)==GenSep).ToList();
           return cloth;
        }

        public async Task<NewDropDownClo> GetNewMovieDropdownsValues()
        {
            var response = new NewDropDownClo()
            {
                ClothSeparations = await _context.ClothSeparation.OrderBy(n => n.Name).ToListAsync(),
                SizeSeparations = await _context.SizeSeparations.OrderBy(n => n.Name).ToListAsync(),
               
            };

            return response;
        }

        public List<ClothSeparation> GetCloSepList()
        {
            var CloSep = _context.ClothSeparation.ToList();
            return CloSep;
        }

        public List<SizeSeparation> GetSizeSepList()
        {
            var SizeSep = _context.SizeSeparations.ToList();
            return SizeSep;
        }

        public List<Cloth> GetFilteredCloList(ShopVM shVM)
        {
            var cloth = _context.Cloth.Where(x => ((int)x.GenderSeparation) == shVM.GenderSeparate).ToList();
            
            if(shVM.UnikName != null)
            {
                cloth = cloth.Where(x => x.CloId == shVM.UnikName).ToList();
            }
            if (shVM.UnikName2 != null)
            {
                cloth = cloth.Where(x => x.SizeId == shVM.UnikName2).ToList();
            }
            if(shVM.searchString!= null)
            {
                cloth = cloth.Where(n => n.Brand.ToLower().Contains(shVM.searchString.ToLower())).ToList(); 
            }
            if(shVM.MaxPrice!= null || shVM.MinPrice != null)
            {
                if(shVM.MinPrice != null && shVM.MaxPrice != null)
                {
                    cloth = cloth.Where(x=>x.Price >= shVM.MinPrice && x.Price <= shVM.MaxPrice).ToList();
                }
                if (shVM.MinPrice != null && shVM.MaxPrice == null)
                {
                    cloth = cloth.Where(x => x.Price >= shVM.MinPrice).ToList();
                }
                if (shVM.MinPrice == null && shVM.MaxPrice != null)
                {
                    cloth = cloth.Where(x => x.Price <= shVM.MaxPrice).ToList();
                }
            }
            if (shVM.reset == 1)
            {
                cloth = cloth.Where(x => ((int)x.GenderSeparation) == shVM.GenderSeparate).ToList();
            }

            return cloth;
        }

        public List<Cloth> ResetFilters(int GenSep)
        {
            var cloth = _context.Cloth.Where(x => ((int)x.GenderSeparation) == GenSep).ToList();
            return cloth;

        }
    }
}
