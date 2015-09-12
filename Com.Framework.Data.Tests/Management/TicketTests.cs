//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Restaurant.Data.Management;
//using Restaurant.Data.Management.Floor;
//using Restaurant.Data.Management.Menus;
//
//namespace Restaurant.DataModels.Tests.Management
//{
//    [TestClass]
//    public class TicketTests
//    {
//        //        private Ticket ticket;
//
//        [TestInitialize]
//        public void Init()
//        {
//            //            ticket = new Ticket
//            //            {
//            //                Items = new List<TicketItem>
//            //                {
//            //                    new TicketItem
//            //                    {
//            //                        Item = new DrinkItem
//            //                        {
//            //                            
//            //                        }
//            //                    },
//            //                    new TicketItem
//            //                    {
//            //                        Item = new FoodItem
//            //                        {
//            //                            
//            //                        }
//            //                    },
//            //                    new TicketItem
//            //                    {
//            //                        Item = new DrinkItem
//            //                        {
//            //                            
//            //                        }
//            //                    },
//            //                    new TicketItem
//            //                    {
//            //                        Item = new DrinkItem
//            //                        {
//            //                            
//            //                        },
//            //                        IsPaid = true
//            //                    },
//            //                    new TicketItem
//            //                    {
//            //                        Item = new FoodItem
//            //                        {
//            //                            
//            //                        },
//            //                        IsPaid = true
//            //                    }
//            //                },
//            //                Table = new Table
//            //                {
//            //                    Number = 1,
//            //                    Seats = 4,
//            //                    Section = new Section
//            //                    {
//            //                        Name = "Bar"
//            //                    }
//            //                }
//            //            };
//        }
//
//        [TestMethod]
//        public void ItemsTest()
//        {
//            Assert.AreEqual(2, ticket.PaidItems.Count);
//            Assert.AreEqual(3, ticket.UnpaidItems.Count);
//
//            //            Assert.AreEqual(2, ticket.GetTicketsItems<FoodItem>().Count);
//            //            Assert.AreEqual(3, ticket.GetTicketsItems<DrinkItem>().Count);
//
//            //            Assert.AreEqual(2, ticket.GetItemsByType<FoodItem>().Count);
//            //            Assert.AreEqual(3, ticket.GetItemsByType<DrinkItem>().Count);
//        }
//
//        [TestMethod]
//        public void TableTest()
//        {
//            Assert.AreEqual(1, ticket.Table.Number);
//            Assert.AreEqual(4, ticket.Table.Seats);
//            Assert.AreEqual("Bar", ticket.Table.Section.Name);
//        }
//    }
//}
