using Rg_Business.Interfaces;
using Rg_Data.Base;
using Rg_Data.Interfaces;
using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderRepository order;
        private readonly IOrderValidation orderValidation;

        public OrderBusiness(IUnitOfWork _unitOfWork, IOrderValidation _orderValidation)
        {
            unitOfWork = _unitOfWork;
            order = unitOfWork.Order;
            orderValidation = _orderValidation;
        }

        public Order Insert(Order entity)
        {
            order.Insert(entity);
            unitOfWork.Complete();
            return entity;
        }

        public Order CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var myOrder = new Order()
                {
                    Customer = createOrderDto.Customer
                };

                if (orderValidation.IsSingleValidOrder(createOrderDto.Products))
                {
                    var productsInformation = GetProductsInformation(createOrderDto.Products);
                    myOrder.Discount = orderValidation.ReturnDiscount(productsInformation);
                    UpdateOrderPrices(myOrder, productsInformation);
                    Insert(myOrder);
                    unitOfWork.OrderProduct.InsertRange(CreateOrderProductList(createOrderDto, myOrder.OrderId));
                    unitOfWork.Complete();
                    return myOrder;
                }
                else
                {
                    throw new NotImplementedException("Each order cannot contain more than one sandwich, fries, or soda");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int orderId)
        {
            var myOrder = GetByID(orderId);
            unitOfWork.OrderProduct.DeleteRange(unitOfWork.OrderProduct.GetByOrder(orderId));
            order.Delete(myOrder);
            unitOfWork.Complete();
        }

        public Order GetByID(int id)
        {
            return order.GetByID(id);
        }

        public IEnumerable<Order> Get()
        {
            return order.Get();
        }

        public void Update(Order entity)
        {
            order.Update(entity);
            unitOfWork.Complete();
        }

        private Order UpdateOrderPrices(Order order, List<Product> orderProducts)
        {
            order.TotalPrice = orderProducts.Sum(p => p.Price);
            order.FinalPrice = order.TotalPrice - ((order.TotalPrice * order.Discount) / 100);
            return order;
        }

        private List<Product> GetProductsInformation(List<OrderProductDto> orderProductDtos)
        {
            return unitOfWork.Product.GetByIDs(orderProductDtos.Select(x => x.IdProduct)).ToList();
        }

        private IEnumerable<OrderProduct> CreateOrderProductList(CreateOrderDto createOrderDto, int orderId)
        {
            List<OrderProduct> orderProductList = new List<OrderProduct>();
            foreach (var _product in createOrderDto.Products)
            {
                var orderProduct = new OrderProduct()
                {
                    ProductId = _product.IdProduct,
                    OrderId = orderId
                };
                orderProductList.Add(orderProduct);
            }

            return orderProductList;
        }

        public IEnumerable<GetOrderDto> GetAllOrders()
        {
            var orders = order.GetAllOrders().ToList();

            var ordersGroup = orders.GroupBy(x => x.OrderId)
              .Where(g => g.Count() > 1)
               .Select(group => new { Order = group.Key, Products = group.ToList() })
              .ToList();

            var orderProducts = new List<GetOrderDto>();
            foreach (var item in ordersGroup)
            {
                var orderProduct = new GetOrderDto();
                orderProduct.Order = item.Products.Where(x => x.OrderId == item.Order).FirstOrDefault().Order;
                orderProduct.Products = item.Products.Where(x => x.OrderId == item.Order).Select(x => x.Product).ToList();
                orderProducts.Add(orderProduct);
            }

            return orderProducts;
        }
    }
}