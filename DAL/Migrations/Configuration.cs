namespace DAL.Migrations
{
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Drawing;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.QLNETDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //khởi tạo sẵn dữ liệu
        protected override void Seed(DAL.QLNETDBContext context)
        {
            //tạo sẵn dữ liệu
            CreateAccounts(context);
            CreateDiscounts(context);
            CreateCustomers(context);
            CreateEmployees(context);
            CreateProducts(context);
            CreateTypeComputers(context);
            CreateComputers(context);
        }
        private void CreateAccounts(DAL.QLNETDBContext context)
        {
            var accounts = new List<Account>
            {
                new Account {AccountId = "acc0001", UserName = "mtxq2003", Password = "123", Role = "Quản Lý", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0002", UserName = "mxt2003", Password = "123", Role = "Quản Lý", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0003", UserName = "tvs2003", Password = "123", Role = "Quản Lý", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0004", UserName = "nhanvien001", Password = "123", Role = "Nhân Viên", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0005", UserName = "nhanvien002", Password = "123", Role = "Nhân Viên", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0006", UserName = "nhanvien003", Password = "123", Role = "Nhân Viên", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0007", UserName = "nhanvien004", Password = "123", Role = "Nhân Viên", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0008", UserName = "khachhang001", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0009", UserName = "khachhang002", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0010", UserName = "khachhang003", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0011", UserName = "khachhang004", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0012", UserName = "khachhang005", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0013", UserName = "khachhang006", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0014", UserName = "khachhang007", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0015", UserName = "khachhang008", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0016", UserName = "khachhang009", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0017", UserName = "khachhang010", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date}
            };
            accounts.ForEach(p => context.Accounts.AddOrUpdate(
                account => account.AccountId,
                new Account
                {
                    AccountId = p.AccountId,
                    UserName = p.UserName,
                    Password = p.Password,
                    Role = p.Role,
                    DateCreate = p.DateCreate
                }));
            context.SaveChanges();
        }
        private void CreateCustomers(DAL.QLNETDBContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {CustomerId = "kh0001", CustomerName = "Bùi Thị Duyên", Balance = 0, TypeCustomer = false, AccountId = "acc0008", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0002", CustomerName = "Ngô Thành Nam", Balance = 0, TypeCustomer = false, AccountId = "acc0009", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0003", CustomerName = "Đỗ Văn Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0010", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0004", CustomerName = "Đặng Bá Cường", Balance = 0, TypeCustomer = false, AccountId = "acc0011", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0005", CustomerName = "Phạm Tuấn Anh", Balance = 0, TypeCustomer = false, AccountId = "acc0012", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0006", CustomerName = "Vũ Anh Ninh", Balance = 0, TypeCustomer = false, AccountId = "acc0013", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0007", CustomerName = "Đào Văn Thanh", Balance = 0, TypeCustomer = false, AccountId = "acc0014", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0008", CustomerName = "Lưu Thùy Vân", Balance = 0, TypeCustomer = false, AccountId = "acc0015", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0009", CustomerName = "Trương Thành Long", Balance = 0, TypeCustomer = false, AccountId = "acc0016", TotalTime = 60, DiscountId = "gg0002"},
                new Customer {CustomerId = "kh0010", CustomerName = "Đinh Hoàng Vũ", Balance = 0, TypeCustomer = false, AccountId = "acc0017", TotalTime = 60, DiscountId = "gg0002"}
            };
            customers.ForEach(p => context.Customers.AddOrUpdate(
                customer => customer.CustomerId,
                new Customer
                {
                    CustomerId = p.CustomerId,
                    CustomerName = p.CustomerName,
                    Balance = p.Balance,
                    AccountId = p.AccountId,
                    TotalTime = p.TotalTime,
                    DiscountId = p.DiscountId
                }));
            context.SaveChanges();
        }
        private void CreateEmployees(DAL.QLNETDBContext context)
        {
            var employees = new List<Employee>
            {
                new Employee {EmployeeId = "nv0001", EmployeeName = "Mai Trịnh Xuân Quý", Salary = 10000, AccountId = "acc0001", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0002", EmployeeName = "Mai Xuân Trường", Salary = 10000, AccountId = "acc0002", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0003", EmployeeName = "Trần Văn Sơn", Salary = 10000, AccountId = "acc0003", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0004", EmployeeName = "Phạm Tuấn Anh", Salary = 2000, AccountId = "acc0004", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0005", EmployeeName = "Hạ Huyền Chi", Salary = 2000, AccountId = "acc0005", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0006", EmployeeName = "Hoàng Trâm Anh", Salary = 2000, AccountId = "acc0006", OtherInfomation = " "},
                new Employee {EmployeeId = "nv0007", EmployeeName = "Huỳnh Anh Dũng", Salary = 2000, AccountId = "acc0007", OtherInfomation = " "}
            };
            employees.ForEach(p => context.Employees.AddOrUpdate(
                employee => employee.EmployeeId,
                new Employee
                {
                    EmployeeId = p.EmployeeId,
                    EmployeeName = p.EmployeeName,
                    Salary = p.Salary,
                    AccountId = p.AccountId
                }));
            context.SaveChanges();
        }
        private void CreateTypeComputers(DAL.QLNETDBContext context)
        {
            var typecomputers = new List<TypeComputer>
            {
                new TypeComputer {TypeId = "type0001", NameType = "Máy Thường", Price = 8},
                new TypeComputer {TypeId = "type0002", NameType = "Máy Game Moba", Price = 9},
                new TypeComputer {TypeId = "type0003", NameType = "Máy Game FPS", Price = 9},
                new TypeComputer {TypeId = "type0004", NameType = "Máy Thi Đấu", Price = 10},
                new TypeComputer {TypeId = "type0005", NameType = "Máy Stream", Price = 15},
                new TypeComputer {TypeId = "type0006", NameType = "Máy Luyện Tập", Price = 8}
            };
            typecomputers.ForEach(p => context.TypeComputers.AddOrUpdate(
                typecomputer => typecomputer.TypeId,
                new TypeComputer
                {
                    TypeId = p.TypeId,
                    NameType = p.NameType,
                    Price = p.Price
                }));
            context.SaveChanges();
        }
        private void CreateComputers(DAL.QLNETDBContext context)
        {
            var computers = new List<Computer>
            {
                new Computer {ComputerId = "mt0001", ComputerName = "1", TypeId = "type0001", NameType = "Khách", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0002", ComputerName = "2", TypeId = "type0002", NameType = "Khách Thường Xuyên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0003", ComputerName = "3", TypeId = "type0003", NameType = "Administrator", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0004", ComputerName = "4", TypeId = "type0004", NameType = "Nhân Viên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0005", ComputerName = "5", TypeId = "type0005", NameType = "Học Sinh/Sinh Viên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0006", ComputerName = "6", TypeId = "type0006", NameType = "Khách Trả Sau", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0007", ComputerName = "7", TypeId = "type0001", NameType = "Khách", Status = "Bảo Trì"},
                new Computer {ComputerId = "mt0008", ComputerName = "8", TypeId = "type0002", NameType = "Khách", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0009", ComputerName = "9", TypeId = "type0003", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0010", ComputerName = "10", TypeId = "type0004", NameType = "Khách", Status = "Còn 5 Phút"}
            };
            computers.ForEach(p => context.Computers.AddOrUpdate(
                computer => computer.ComputerId,
                new Computer
                {
                    ComputerId = p.ComputerId,
                    ComputerName = p.ComputerName,
                    TypeId = p.TypeId,
                    NameType = p.NameType,
                    Status = p.Status
                }));
            context.SaveChanges();
        }
        private void CreateProducts(DAL.QLNETDBContext context)
        {
            var products = new List<Product>
            {
                new Product {ProductId = "sp0001", ProductName = "Mỳ Tôm", SellingPrice = 10, Type = "Đồ Ăn", Stock = 15, Discription = " ", ImageFilePath = "mytom.jpg", CostPrice = 8},
                new Product {ProductId = "sp0002", ProductName = "Miến Gà", SellingPrice = 15, Type = "Đồ Ăn", Stock = 15, Discription = " ", ImageFilePath = "mien.jpg", CostPrice = 10},
                new Product {ProductId = "sp0003", ProductName = "Cơm Chiên", SellingPrice = 20, Type = "Đồ Ăn", Stock = 5, Discription = " ", ImageFilePath = "comchien.jpg", CostPrice = 15},
                new Product {ProductId = "sp0004", ProductName = "Gà Rán", SellingPrice = 25, Type = "Đồ Ăn", Stock = 10, Discription = " ", ImageFilePath = "garan.jpg", CostPrice = 20},
                new Product {ProductId = "sp0005", ProductName = "Coca Cola", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", ImageFilePath = "cocacola.jpg", CostPrice = 8},
                new Product {ProductId = "sp0006", ProductName = "Soda", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", ImageFilePath = "soda.jpg", CostPrice = 8},
                new Product {ProductId = "sp0007", ProductName = "Sting", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", ImageFilePath = "sting.jpg", CostPrice = 8},
                new Product {ProductId = "sp0008", ProductName = "Thuốc Lá", SellingPrice = 20, Type = "Đồ Ăn", Stock = 15, Discription = " ", ImageFilePath = "thuocla.jpg", CostPrice = 15},
                new Product {ProductId = "sp0009", ProductName = "Trà Đào", SellingPrice = 20, Type = "Nước Uống", Stock = 15, Discription = " ", ImageFilePath = "tradao.jpg", CostPrice = 15},
                new Product {ProductId = "sp0010", ProductName = "Trà Sữa", SellingPrice = 25, Type = "Nước Uống", Stock = 15, Discription = " ", ImageFilePath = "trasua.jpg", CostPrice = 20},
                new Product {ProductId = "sp0011", ProductName = "Phở Bò", SellingPrice = 15, Type = "Đồ Ăn", Stock = 10, Discription = " ", ImageFilePath = "pho.jpg", CostPrice = 10}
            };
            products.ForEach(p => context.Products.AddOrUpdate(
                product => product.ProductId,
                new Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SellingPrice = p.SellingPrice,
                    Type = p.Type,
                    Stock = p.Stock,
                    Discription = p.Discription,
                    ImageFilePath = p.ImageFilePath,
                }));
            context.SaveChanges();
        }
        //private string ConvertToFilePath(string nameImg)
        //{
        //    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\DAL\bin\Debug", ""), "img", nameImg);
        //}
        //private byte[] GetImageByFilePath(string filePath)
        //{
        //    Image img = Image.FromFile(filePath);
        //    byte[] imageBytes;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, img.RawFormat);
        //        imageBytes = ms.ToArray();
        //    }
        //    return imageBytes;
        //}
        private void CreateDiscounts(DAL.QLNETDBContext context)
        {
            var discounts = new List<Discount>
            {
                new Discount {DiscountId = "gg0001", DiscountName = "VIP", DiscountPercent = 10},
                new Discount {DiscountId = "gg0002", DiscountName = "Thường", DiscountPercent = 0}
            };
            discounts.ForEach(p => context.Discounts.AddOrUpdate(
                discount => discount.DiscountId,
                new Discount
                {
                    DiscountId = p.DiscountId,
                    DiscountName = p.DiscountName,
                    DiscountPercent = p.DiscountPercent
                }));
            context.SaveChanges();
        }
    }
}
