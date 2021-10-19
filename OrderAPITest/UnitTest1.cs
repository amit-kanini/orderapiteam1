using System.Collections.Generic;

using NUnit.Framework;
using OrderAPI.FlowerModel;
using OrderAPI.Repository;

namespace OrderAPITest
{
    public class Tests
    {



        List<OrderDetail> f1 = new List<OrderDetail>() {
            
        
        
        };

        [SetUp]
        public void Setup()
        {
            f1 = new List<OrderDetail>
            {
                new OrderDetail()
                {
                 OrderId=1,
                 FlowerId=1,
                 CustomerId=101,
                 CartId=201,
                 Totalprice=1500,
                 Remark ="Nice flower",
                 PaymentStatus="Done",
                }
            };

        }

        [Test]

        public void TestFlowerByIdValid()
        {
            //int a = 1;
            RepoClass r = new RepoClass();
            var b = r.OrderdetailsbyCustomerId(101);
            Assert.AreEqual(f1[0].OrderId, b[0].OrderId);
            // Assert.AreEqual(d.Drug_Name, b.Drug_Name);
        }

        [Test]

        public void TestFlowerByIdInValid()
        {
            //int a = 1;
            RepoClass r = new RepoClass();
            var b = r.OrderdetailsbyCustomerId(5);
           
            Assert.AreNotEqual(f1, b);
            // Assert.AreEqual(d.Drug_Name, b.Drug_Name);
        }
        
       
    }
}