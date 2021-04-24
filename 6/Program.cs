using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace CsharpHomework6
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService a = new OrderService();
            bool judge_ = true;
            while (judge_)
            {
                Console.WriteLine("输入1添加订单，输入2删除订单，输入3修改订单，输入4查找订单，输入5显示所有订单，输入6序列化订单，输入7反序列化订单，输入8退出");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        a.addOrder();
                        break;
                    case "2":
                        a.removeOrder();
                        break;
                    case "3":
                        a.changeOrder();
                        break;
                    case "4":
                        a.searchOrder();
                        break;
                    case "5":
                        a.ShowOrder();
                        break;
                    case "6":
                        a.Export();
                        break;
                    case "7":
                        a.Import();
                        break;
                    case "8":
                        judge_ = false;
                        break;
                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }
        }
    }
    public class Order : IComparable
    {
        public int OrderNum { set; get; }
        public string ProductName { set; get; }
        public string Customer { set; get; }
        public double OrderPrice { set; get; }

        public List<OrderDetails> orderDetails = new List<OrderDetails>();

        public Order()
        {
            this.OrderNum = 0;
            this.ProductName = string.Empty;
            this.Customer = string.Empty;
            this.OrderPrice = 0;
        }
        public Order(int orderNum, string productName, string customer, double orderPrice)
        {
            this.OrderNum = orderNum;
            this.ProductName = productName;
            this.Customer = customer;
            this.OrderPrice = orderPrice;
        }
        public int CompareTo(object obj)
        {
            Order a = obj as Order;
            return this.OrderNum.CompareTo(a.OrderNum);
        }
        public override bool Equals(object obj)
        {
            Order a = obj as Order;
            return this.OrderNum == a.OrderNum;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(OrderNum);
        }
        public void RemoveOrderDetails() //删除订单项
        {
            try
            {
                Console.WriteLine("请输入订单明细序号删除相应订单明细：");
                int a = Convert.ToInt32(Console.ReadLine());
                this.orderDetails.RemoveAt(a);
                Console.WriteLine("删除成功");
                Console.WriteLine("-------------------------");
            }
            catch
            {
                Console.WriteLine("输入序号错误");
            }
        }

        public void ShowOrderDetails()  //展示订单项
        {
            Console.WriteLine("订单号 商品名称 客户 订单金额");
            foreach (OrderDetails a in this.orderDetails)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("{0} {1} {2} {3}", a.OrderNum, a.ProductName, a.Customer, a.OrderPrice);
            }
        }
    }
    public class OrderDetails
    {
        private int orderNum;
        public int OrderNum
        {
            set
            {
                if (value >= 0) orderNum = value;
                else Console.WriteLine("订单号不应小于0");
            }
            get
            {
                return orderNum;
            }
        }
        private string productName;
        public string ProductName { set; get; }
        private string customer;
        public string Customer { set; get; }
        private double orderPrice;
        public double OrderPrice
        {
            set
            {
                if (value >= 0) orderPrice = value;
                else Console.WriteLine("订单金额不应小于0");
            }
            get
            {
                return orderPrice;
            }
        }
        public OrderDetails()
        {
            this.OrderNum = 0;
            this.ProductName = string.Empty;
            this.Customer = string.Empty;
            this.OrderPrice = 0;
        }
        public OrderDetails(int orderNum, string productName, string customer, double orderPrice)
        {
            this.orderNum = orderNum;
            this.productName = productName;
            this.customer = customer;
            this.orderPrice = orderPrice;
        }
        public double getPrice()
        {
            return this.orderPrice;
        }
    }
    public interface IOrderService
    {
        void addOrder();
        void removeOrder();
        void changeOrder();
        void searchOrder();
    }
    public class OrderService : IOrderService
    {
        public List<Order> order = new List<Order>();
        public OrderService() { }

        public void Export()
        {
            XmlSerializer a = new XmlSerializer(typeof(List<Order>));
            using (FileStream b = new FileStream("order.xml", FileMode.Create))
            {
                a.Serialize(b, this.order);
            }
            Console.WriteLine("序列化完成");
        }

        public void Import()
        {
            try
            {
                XmlSerializer a = new XmlSerializer(typeof(List<Order>));
                using (FileStream b = new FileStream("order.xml", FileMode.Open))
                {
                    List<Order> c = (List<Order>)a.Deserialize(b);
                    Console.WriteLine("反序列化结果：");
                    foreach (Order d in c)
                    {
                        Console.WriteLine("订单号 商品名称 客户 订单金额");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("{0} {1} {2} {3}", d.OrderNum, d.ProductName, d.Customer, d.OrderPrice);
                        d.ShowOrderDetails();
                    }
                }
            }
            catch
            {
                Console.WriteLine("序列化系列操作错误");
            }
        }

        public void ShowOrder()
        {
            foreach (Order a in this.order)
            {
                Console.WriteLine("订单号 商品名称 客户 订单金额");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("{0} {1} {2} {3}", a.OrderNum, a.ProductName, a.Customer, a.OrderPrice);
                a.ShowOrderDetails();
            }
        }
        public void addOrder()
        {
            try
            {
                Console.WriteLine("请输入订单编号：");
                int orderNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入商品名称：");
                string productName = Convert.ToString(Console.ReadLine());
                Console.WriteLine("请输入客户昵称：");
                string customer = Convert.ToString(Console.ReadLine());
                Console.WriteLine("请输入订单金额：");
                double orderPrice = Convert.ToDouble(Console.ReadLine());
                Order a = new Order(orderNum, productName, customer, orderPrice);
                bool same = false;
                foreach (Order m in this.order)
                {
                    if (m.Equals(a)) same = true;
                }
                if (same) Console.WriteLine("订单编号重复！");
                order.Add(a);
                Console.WriteLine("添加订单成功！");
                Console.WriteLine("-----------------------------");
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
        }
        public void removeOrder()
        {
            try
            {
                Console.WriteLine("输入订单号删除订单或相应明细：");
                int orderNum = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (Order a in this.order)
                {
                    if (a.OrderNum == orderNum) index = this.order.IndexOf(a);
                }
                Console.WriteLine("输入1删除订单，输入2继续删除订单明细");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        this.order.RemoveAt(index);
                        Console.WriteLine("删除成功");
                        Console.WriteLine("-----------------");
                        break;
                    case 2:
                        this.order[index].ShowOrderDetails();
                        this.order[index].RemoveOrderDetails();
                        break;
                    default:
                        Console.WriteLine("输入错误");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("输入错误");
            }
        }
        public void changeOrder()
        {
            try
            {
                Console.WriteLine("请输入要修改的订单订单号：");
                int removeNum = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (Order a in this.order)
                {
                    if (a.OrderNum == removeNum) index = this.order.IndexOf(a);
                }
                this.order.RemoveAt(index);

                Console.WriteLine("请输入订单编号：");
                int orderNum1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入商品名称：");
                string productName1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("请输入客户昵称：");
                string customer1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("请输入订单金额：");
                double orderPrice1 = Convert.ToDouble(Console.ReadLine());
                Order a1 = new Order(orderNum1, productName1, customer1, orderPrice1);
                bool same = false;
                foreach (Order m in this.order)
                {
                    if (m.Equals(a1)) same = true;
                }
                if (same) Console.WriteLine("订单编号重复！");
                order.Add(a1);
                Console.WriteLine("修改订单成功！");
                Console.WriteLine("-----------------------------");
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
        }
        public void searchOrder()
        {
            try
            {
                Console.WriteLine("请输入要查询的订单订单号：");
                int searchNum = Convert.ToInt32(Console.ReadLine());
                var query = from s in order
                            where s.OrderNum == searchNum
                            select s;
                List<Order> a = query.ToList();
                foreach (Order b in a)
                {
                    Console.WriteLine("订单号 商品名称 客户 订单金额");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("{0} {1} {2} {3}", b.OrderNum, b.ProductName, b.Customer, b.OrderPrice);
                    b.ShowOrderDetails();
                }
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
        }
    }
}
