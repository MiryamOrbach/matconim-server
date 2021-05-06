using Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class MenuBL
    {
        public static List<DishDto> Menu(int statusMeal)
        {
            List<Dish> menus = MenuDal.Menu(statusMeal);
            List<Dto.DishDto> m = menus.Select(menu => new Dto.DishDto(menu)).ToList();
            return m;
        }
    }
}
