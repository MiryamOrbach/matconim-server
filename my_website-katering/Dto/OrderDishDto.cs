using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class OrderDishDto
    {
        public int idOrderDish { get; set; }
        public Nullable<int> idOrder { get; set; }
        public Nullable<int> idDose { get; set; }
        public virtual DishDto Dish { get; set; }
        public Dictionary<StatusDose, DishDto> statusDishes { get;set; }

        public OrderDishDto()
        {

        }
        public OrderDishDto(OrderDish o)
        {
            idOrderDish = o.idOrderDish;
            idOrder = o.idOrder;
            idDose = o.idDose;
            Dish = new DishDto(o.Dish);
        }
        public static OrderDish ToDal(OrderDishDto o)
        {
            return new OrderDish()
            {
                idOrderDish = o.idOrderDish,
                idDose = o.idDose,
                idOrder = o.idOrder
            };
        }
    }
}
