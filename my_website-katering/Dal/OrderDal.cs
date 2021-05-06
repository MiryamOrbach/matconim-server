using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class OrderDal
    {
        public static int AddOrders(Order model)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    db.Orders.Add(model);
                    db.SaveChanges();
                    return model.idOrder;
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }
        public static int AddOrderDish(List<OrderDish> model)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    db.OrderDishes.AddRange(model);
                   return db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }

        public static List<Dish> GetOrderDish(int orderId)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    //return db.OrderDishes.Include("Dish").Where(o => o.idOrder == orderId).ToList();
                    return db.Dishes.Where(o => o.OrderDishes.Any(p=>p.idOrder == orderId)).ToList();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }

        public static List<ExtraToOrder> GetExtras(int orderId)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    //return db.OrderDishes.Include("Dish").Where(o => o.idOrder == orderId).ToList();
                    return db.ExtraToOrders.Include("EventExtension").Where(o => o.idOrder==orderId).ToList();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }

        public static int AddExtraToOrders(List<ExtraToOrder> model)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    db.ExtraToOrders.AddRange(model);
                    return db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }
    }
}
