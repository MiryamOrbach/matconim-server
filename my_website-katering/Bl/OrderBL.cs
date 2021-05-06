using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
    public class OrderBL
    {
        public static OrderDto AddOrder(OrderDto o)
        {
            Order order = OrderDto.Todal(o);
            o.idOrder = OrderDal.AddOrders(order);
            return o;

        }
        public static int AddOrderDish(List<int> dishes, int idOrder)
        {
            List<OrderDish> orderDishes = new List<OrderDish>();
            dishes.ForEach((d) =>
            {
                OrderDish order = new OrderDish() { idOrder = idOrder, idDose = d };
                orderDishes.Add(order);
            });
            return OrderDal.AddOrderDish(orderDishes);


        }
        public static List<DishDto> GetOrderDishes(int orderId)
        {
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    //Dictionary<StatusDose, DishDto> statusDishes = new Dictionary<StatusDose, DishDto>();
                    //List<OrderDishDto> o;
                    //o = db.OrderDishes.Where(or => or.idOrder == orderId).ToList().Select(x => new OrderDishDto(x)
                    //{
                    //    Dishes = db.
                    //}).ToList();
                    //statusDishes = o..GroupBy(x => x.Dish.statusDose).Select();
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

            //return OrderDal.GetOrderDish(orderId).Select(o => new OrderDishDto(o)).ToList();
            return OrderDal.GetOrderDish(orderId).Select(p => new DishDto(p)).ToList();
        }
        public static int AddExtraToOrder(List<int> extras, int idOrder)
        {
            List<ExtraToOrder> extraToOrders = new List<ExtraToOrder>();
            extras.ForEach((e) =>
            {
                ExtraToOrder extra = new ExtraToOrder() { idOrder = idOrder, idExtra = e };
                extraToOrders.Add(extra);
            });
            return OrderDal.AddExtraToOrders(extraToOrders);


        }
        public static List<ExtraToOrderDto>GetExtras(int orderId)
        {
            List<ExtraToOrderDto> extras = OrderDal.GetExtras(orderId).Select(o => new ExtraToOrderDto(o)).ToList();
            return extras;
        }
        public static OrderDto GetOrderFull(int customerId)
        {
            OrderDto o;
            using (myProjectEntities db = new myProjectEntities())
            {
                try
                {
                    o = new OrderDto(db.Orders.Include("Customer").Where(order => order.idCustomer == customerId).OrderByDescending(x => x.dateInsert).First());
                    //(x => new StatusDoseDto(x)
                    //{
                    //    Dishes = db.Dishes.Where(d => d.typeDose == x.idStatusDose && d.statusMeal == statusMeal).ToList().Select(xx => new DishDto(xx)).ToList()
                    //}
                    //).ToList();

                }
                catch (Exception e)
                {

                    return null;
                }

                return o;
            }
        }
    }
}
