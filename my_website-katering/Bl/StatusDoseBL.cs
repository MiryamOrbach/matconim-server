using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class StatusDoseBL
    {
        public static List<StatusDoseDto> GetALlStatusWithDishes(int statusMeal)
        {
            List<StatusDoseDto> s;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    s = db.StatusDoses.ToList().Select(x => new StatusDoseDto(x)
                    {
                        Dishes = db.Dishes.Where(d => d.typeDose == x.idStatusDose && d.statusMeal == statusMeal).ToList().Select(xx => new DishDto(xx)).ToList()
                    }
                  ).ToList();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
            return s;
        }
        public static StatusDoseDto GetStatusById(int statusId)
        {
            StatusDoseDto tt;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    var t = db.StatusDoses.FirstOrDefault(p => p.idStatusDose == statusId);
                    tt = new StatusDoseDto(t);
                }
                catch (Exception e)
                {

                    return null;
                }

            }
            return tt;
        }

        public static List<StatusDoseDto> GetStatusWithDishes(int statusMeal, int statusShabbat, bool isBasic)
        {
            List<StatusDoseDto> s;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    if (isBasic)
                        s = db.StatusDoses.Where(st => st.IsDisplayBase == true).ToList().Select(x => new StatusDoseDto(x)
                        {
                            Dishes = statusShabbat != 0 ?
                            GetDishesByStatusShabbat(x.idStatusDose, statusShabbat) : GetDishesByStatusMeal(x.idStatusDose, statusMeal)
                            //Dishes = db.Dishes.Where(d => d.typeDose == x.idStatusDose && d.statusMeal == statusMeal).ToList().Select(xx => new DishDto(xx)).ToList()
                        }
                      ).ToList();

                    else s = db.StatusDoses.ToList().Select(x => new StatusDoseDto(x)
                    {
                        Dishes = statusShabbat != 0 ?
                            GetDishesByStatusShabbat(x.idStatusDose, statusShabbat) : GetDishesByStatusMeal(x.idStatusDose, statusMeal)
                    }
                   ).ToList();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
            return s;
        }

        public static List<DishDto> GetDishesByStatusShabbat(int typeDose, int statusShabbat)
        {
            List<DishDto> d;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {

                    d = db.Dishes.Where(dish => dish.typeDose == typeDose && dish.statusShabbat == statusShabbat).ToList().Select(x => new DishDto(x)).ToList();
                    return d;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static List<DishDto> GetDishesByStatusMeal(int typeDose, int statusMeal)
        {
            List<DishDto> d;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {

                    d = db.Dishes.Where(dish => dish.typeDose == typeDose && dish.statusMeal == statusMeal).ToList().Select(x => new DishDto(x)).ToList();
                    return d;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }

    }
}
