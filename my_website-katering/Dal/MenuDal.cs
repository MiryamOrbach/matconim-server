using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MenuDal
    {
        public static List<Dish> Menu(int statusMeal)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    List<Dish> dish = db.Dishes.Where(d => d.statusMeal == statusMeal).ToList();
                    return dish;
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
    }
}
