using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.FlowerModel;
using OrderAPI.Provider;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrderController));
        
        public OrderController(IProvider _ip)
        {
            ip = _ip;
            // _log4net = log4net.LogManager.GetLogger(typeof(FlowController));
        }

        IProvider ip;
        // public FlowController(dbFlowerStoreContext db)
        //{
        //    this.db = db;
        //}
        //------------------Adding a item to OrderDetails table after successful payment-------------------
        [HttpPost]
        [Route("AddingToOrderDetails")]
        public ActionResult<OrderDetail> AddingToOrderDetails(OrderDetail ord)
        {
            //_log4net.Info("Add to order details is invoked");
            //OrderDetail temp = new OrderDetail();
            //temp.FlowerId = tempFlowerId;
            //temp.CustomerId = tempCustomerid;
            //temp.Totalprice = tempTotalPrice;
            //temp.Remark = tempRemark;
            //temp.PaymentStatus = tempPaymentStatus;
            //db.OrderDetails.Add(temp);
            //await db.SaveChangesAsync();
            //return Ok();
            _log4net.Info("Add to order details is invoked");
            try
            {
                ip = new ProviderClass();
                ip.AddingToOrderDetails(ord);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        //------------------------Get all the OrderDetails for a Customer by their Id---------------------
        [HttpGet]
        [Route("OrderdetailsbyCustomerId")]
        public ActionResult<Flower> OrderdetailsbyCustomerId(int id)
        {
            //_log4net.Info("Order detail by " + id + " is invoked");
            //List<OrderDetail> OrderDetaillist = new List<OrderDetail>();
            //foreach (var temp in await db.OrderDetails.ToListAsync())
            //{
            //    if (temp.CustomerId == id)
            //    {
            //        OrderDetaillist.Add(temp);
            //    }
            //}
            //return Ok(OrderDetaillist);
            _log4net.Info("Order detail by " + id + " is invoked");
            try
            {
                ip = new ProviderClass();
                
                return Ok(ip.OrderdetailsbyCustomerId(id));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("UpdateStatusForOrders")]
        public IActionResult UpdateStatus(OrderDetail temp)
        {
            //_log4net.Info("UPdate flower is invoked");
            //db.Entry(temp).State = EntityState.Modified;
            //await db.SaveChangesAsync();
            //return Ok();
            _log4net.Info("UPdate flower is invoked");
            try
            {
                ip = new ProviderClass();
                ip.UpdateStatus(temp);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllOccasion")]
        public ActionResult<Occasion> GetAllOccasion()
        {
            //return Ok(await db.Occasions.ToListAsync());
            _log4net.Info("Get all occasion is invoked");
            try
            {
                ip = new ProviderClass();
                return Ok(ip.GetAllOccasion());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("AllOrders")]
        public ActionResult<Occasion> AllOrders()
        {
            //return Ok(await db.Occasions.ToListAsync());
            _log4net.Info("Get all Orders is invoked");
            try
            {
                ip = new ProviderClass();
                return Ok(ip.AllOrders());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("OrderByOrderID")]
        public ActionResult<OrderDetail> OrderByOrderID(int id)
        {
            _log4net.Info("order id " + id + " was searched");
            try
            {
                ip = new ProviderClass();
                OrderDetail temp = ip.OrderByOrderID(id);
                return Ok(temp);
            }
            catch
            {
                return BadRequest();
            }
        }


    }

}
