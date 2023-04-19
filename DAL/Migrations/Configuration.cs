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
            CreateBills(context);
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
                #region Danh Sách Khách Hàng
                new Customer {CustomerId = "kh0001", CustomerName = "Bùi Thị Duyên", Balance = 0, TypeCustomer = false, AccountId = "acc0008", TotalTime = 60},
                new Customer {CustomerId = "kh0002", CustomerName = "Ngô Thành Nam", Balance = 0, TypeCustomer = false, AccountId = "acc0009", TotalTime = 60},
                new Customer {CustomerId = "kh0003", CustomerName = "Đỗ Văn Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0010", TotalTime = 60},
                new Customer {CustomerId = "kh0004", CustomerName = "Đặng Bá Cường", Balance = 0, TypeCustomer = false, AccountId = "acc0011", TotalTime = 60},
                new Customer {CustomerId = "kh0005", CustomerName = "Phạm Tuấn Anh", Balance = 0, TypeCustomer = false, AccountId = "acc0012", TotalTime = 60},
                new Customer {CustomerId = "kh0006", CustomerName = "Vũ Anh Ninh", Balance = 0, TypeCustomer = false, AccountId = "acc0013", TotalTime = 60},
                new Customer {CustomerId = "kh0007", CustomerName = "Đào Văn Thanh", Balance = 0, TypeCustomer = false, AccountId = "acc0014", TotalTime = 60},
                new Customer {CustomerId = "kh0008", CustomerName = "Lưu Thùy Vân", Balance = 0, TypeCustomer = false, AccountId = "acc0015", TotalTime = 60},
                new Customer {CustomerId = "kh0009", CustomerName = "Trương Thành Long", Balance = 0, TypeCustomer = false, AccountId = "acc0016", TotalTime = 60},
                new Customer {CustomerId = "kh0010", CustomerName = "Đinh Hoàng Vũ", Balance = 0, TypeCustomer = false, AccountId = "acc0017", TotalTime = 60},
                new Customer {CustomerId = "kh0011", CustomerName = "Trần Thị Mai", Balance = 0, TypeCustomer = false, AccountId = "acc0008", TotalTime = 60},
                new Customer {CustomerId = "kh0012", CustomerName = "Hà Thị Băng", Balance = 0, TypeCustomer = false, AccountId = "acc0009", TotalTime = 60},
                new Customer {CustomerId = "kh0013", CustomerName = "Lưu Bảo Ngọc", Balance = 0, TypeCustomer = false, AccountId = "acc0010", TotalTime = 60},
                new Customer {CustomerId = "kh0014", CustomerName = "Ngô Quang Chuyên", Balance = 0, TypeCustomer = false, AccountId = "acc0011", TotalTime = 60},
                new Customer {CustomerId = "kh0015", CustomerName = "Văn Thị Minh", Balance = 0, TypeCustomer = false, AccountId = "acc0012", TotalTime = 60},
                new Customer {CustomerId = "kh0016", CustomerName = "Hoàng Thị Đoan", Balance = 0, TypeCustomer = false, AccountId = "acc0013", TotalTime = 60},
                new Customer {CustomerId = "kh0017", CustomerName = "Trịnh Ngọc Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0014", TotalTime = 60},
                new Customer {CustomerId = "kh0018", CustomerName = "Trần Văn Giang", Balance = 0, TypeCustomer = false, AccountId = "acc0015", TotalTime = 60},
                new Customer {CustomerId = "kh0019", CustomerName = "Nguyễn Quang Hiếu", Balance = 0, TypeCustomer = false, AccountId = "acc0016", TotalTime = 60},
                new Customer {CustomerId = "kh0020", CustomerName = "Trần Thị Hoa", Balance = 0, TypeCustomer = false, AccountId = "acc0017", TotalTime = 60},
                new Customer {CustomerId = "kh0021", CustomerName = "Đặng Thị Huyền", Balance = 0, TypeCustomer = false, AccountId = "acc0008", TotalTime = 60},
                new Customer {CustomerId = "kh0022", CustomerName = "Nguyễn Văn Kiên", Balance = 0, TypeCustomer = false, AccountId = "acc0009", TotalTime = 60},
                new Customer {CustomerId = "kh0023", CustomerName = "Lưu Thị Lan", Balance = 0, TypeCustomer = false, AccountId = "acc0010", TotalTime = 60},
                new Customer {CustomerId = "kh0024", CustomerName = "Đinh Thị Liên", Balance = 0, TypeCustomer = false, AccountId = "acc0011", TotalTime = 60},
                new Customer {CustomerId = "kh0025", CustomerName = "Nguyễn Xuân Mẫn", Balance = 0, TypeCustomer = false, AccountId = "acc0012", TotalTime = 60},
                new Customer {CustomerId = "kh0026", CustomerName = "Trần Đắc Dũng", Balance = 0, TypeCustomer = false, AccountId = "acc0013", TotalTime = 60},
                new Customer {CustomerId = "kh0027", CustomerName = "Võ Văn Quốc", Balance = 0, TypeCustomer = false, AccountId = "acc0014", TotalTime = 60},
                new Customer {CustomerId = "kh0028", CustomerName = "Nguyễn Đình Ánh", Balance = 0, TypeCustomer = false, AccountId = "acc0015", TotalTime = 60},
                new Customer {CustomerId = "kh0029", CustomerName = "Trương Quốc Hùng", Balance = 0, TypeCustomer = false, AccountId = "acc0016", TotalTime = 60},
                new Customer {CustomerId = "kh0030", CustomerName = "Phan Văn Tài", Balance = 0, TypeCustomer = false, AccountId = "acc0017", TotalTime = 60}
                #endregion
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
                #region Danh Sách Máy Tính
                new Computer {ComputerId = "mt0001", ComputerName = "1", TypeId = "type0001", NameType = "Khách", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0002", ComputerName = "2", TypeId = "type0002", NameType = "Khách Thường Xuyên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0003", ComputerName = "3", TypeId = "type0003", NameType = "Administrator", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0004", ComputerName = "4", TypeId = "type0004", NameType = "Nhân Viên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0005", ComputerName = "5", TypeId = "type0005", NameType = "Học Sinh/Sinh Viên", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0006", ComputerName = "6", TypeId = "type0006", NameType = "Khách Trả Sau", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0007", ComputerName = "7", TypeId = "type0001", NameType = "Khách", Status = "Bảo Trì"},
                new Computer {ComputerId = "mt0008", ComputerName = "8", TypeId = "type0002", NameType = "Khách", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0009", ComputerName = "9", TypeId = "type0003", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0010", ComputerName = "10", TypeId = "type0004", NameType = "Khách", Status = "Còn 5 Phút"},
                new Computer {ComputerId = "mt0011", ComputerName = "11", TypeId = "type0001", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0012", ComputerName = "12", TypeId = "type0002", NameType = "Khách Thường Xuyên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0013", ComputerName = "13", TypeId = "type0003", NameType = "Administrator", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0014", ComputerName = "14", TypeId = "type0004", NameType = "Nhân Viên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0015", ComputerName = "15", TypeId = "type0005", NameType = "Học Sinh/Sinh Viên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0016", ComputerName = "16", TypeId = "type0006", NameType = "Khách Trả Sau", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0017", ComputerName = "17", TypeId = "type0001", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0018", ComputerName = "18", TypeId = "type0002", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0019", ComputerName = "19", TypeId = "type0003", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0020", ComputerName = "20", TypeId = "type0004", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0021", ComputerName = "21", TypeId = "type0001", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0022", ComputerName = "22", TypeId = "type0002", NameType = "Khách Thường Xuyên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0023", ComputerName = "23", TypeId = "type0003", NameType = "Administrator", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0024", ComputerName = "24", TypeId = "type0004", NameType = "Nhân Viên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0025", ComputerName = "25", TypeId = "type0005", NameType = "Học Sinh/Sinh Viên", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0026", ComputerName = "26", TypeId = "type0006", NameType = "Khách Trả Sau", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0027", ComputerName = "27", TypeId = "type0001", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0028", ComputerName = "28", TypeId = "type0002", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0029", ComputerName = "29", TypeId = "type0003", NameType = "Khách", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0030", ComputerName = "30", TypeId = "type0004", NameType = "Khách", Status = "Đã Tắt"}
                #endregion
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
                new Discount {DiscountId = "gg0001", DiscountName = "Giảm Giá Khách VIP", DiscountPercent = 10, TypeCustomer = true},
                new Discount {DiscountId = "gg0002", DiscountName = "Giảm Giá Sự Kiện", DiscountPercent = 10, TypeCustomer = false},
                new Discount {DiscountId = "gg0003", DiscountName = "Giảm Giá Sự Kiện Khách VIP", DiscountPercent = 5, TypeCustomer = true}
            };
            discounts.ForEach(p => context.Discounts.AddOrUpdate(
                discount => discount.DiscountId,
                new Discount
                {
                    DiscountId = p.DiscountId,
                    DiscountName = p.DiscountName,
                    DiscountPercent = p.DiscountPercent,
                    TypeCustomer = p.TypeCustomer
                }));
            context.SaveChanges();
        }
        private void CreateBills(DAL.QLNETDBContext context)
        {
            #region Danh Sách Món Ăn Trong 1 Hóa Đơn
            //80
            var billProduct1 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0001", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0001", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0001", Quantity = 1}
            };
            //75
            var billProduct2 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0002", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0002", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0002", Quantity = 1}
            };
            //55
            var billProduct3 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0003", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0003", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0003", Quantity = 2}
            };
            //75
            var billProduct4 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0004", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0004", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0004", Quantity = 1}
            };
            //70
            var billProduct5 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0005", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0005", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0005", Quantity = 1}
            };
            //55
            var billProduct6 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0006", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0006", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0006", Quantity = 2}
            };
            //90
            var billProduct7 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0007", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0007", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0007", Quantity = 2}
            };
            //90
            var billProduct8 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0008", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0008", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0008", Quantity = 2}
            };
            //75
            var billProduct9 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0009", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0009", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0009", Quantity = 1}
            };
            //65
            var billProduct10 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0010", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0010", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0010", Quantity = 1}
            };
            //60
            var billProduct11 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0011", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0011", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0011", Quantity = 2}
            };
            //110
            var billProduct12 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0012", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0012", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0012", Quantity = 1}
            };
            //60
            var billProduct13 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0013", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0013", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0013", Quantity = 1}
            };
            //65
            var billProduct14 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0014", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0014", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0014", Quantity = 2}
            };
            //55
            var billProduct15 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0015", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0015", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0015", Quantity = 1}
            };
            #endregion
            var bills = new List<Bill>
            {
                new Bill{BillId = "hd0001", EmployeeId = "nv0004", DiscountId = "gg0002", Status = "Chờ Chấp Nhận", Total = 80,ComputerId = "mt0001", CustomerId = "kh0001", Date = DateTime.Now.Date.AddDays(-10), Products = billProduct1 },
                new Bill{BillId = "hd0002", EmployeeId = "nv0005", DiscountId = "gg0002", Status = "Chờ Chấp Nhận", Total = 75,ComputerId = "mt0002", CustomerId = "kh0002", Date = DateTime.Now.Date.AddDays(-11), Products = billProduct2 },
                new Bill{BillId = "hd0003", EmployeeId = "nv0006", DiscountId = "gg0002", Status = "Chờ Chấp Nhận", Total = 55,ComputerId = "mt0003", CustomerId = "kh0003", Date = DateTime.Now.Date.AddDays(-12), Products = billProduct3 },
                new Bill{BillId = "hd0004", EmployeeId = "nv0007", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 75,ComputerId = "mt0004", CustomerId = "kh0004", Date = DateTime.Now.Date.AddDays(-13), Products = billProduct4 },
                new Bill{BillId = "hd0005", EmployeeId = "nv0004", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 70,ComputerId = "mt0005", CustomerId = "kh0005", Date = DateTime.Now.Date.AddDays(-14), Products = billProduct5 },
                new Bill{BillId = "hd0006", EmployeeId = "nv0005", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 55,ComputerId = "mt0006", CustomerId = "kh0006", Date = DateTime.Now.Date.AddDays(-15), Products = billProduct6 },
                new Bill{BillId = "hd0007", EmployeeId = "nv0006", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 90,ComputerId = "mt0007", CustomerId = "kh0007", Date = DateTime.Now.Date.AddDays(-16), Products = billProduct7 },
                new Bill{BillId = "hd0008", EmployeeId = "nv0007", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 90,ComputerId = "mt0008", CustomerId = "kh0008", Date = DateTime.Now.Date.AddDays(-17), Products = billProduct8 },
                new Bill{BillId = "hd0009", EmployeeId = "nv0004", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 75,ComputerId = "mt0009", CustomerId = "kh0009", Date = DateTime.Now.Date.AddDays(-18), Products = billProduct9 },
                new Bill{BillId = "hd0010", EmployeeId = "nv0005", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 65,ComputerId = "mt0010", CustomerId = "kh0010", Date = DateTime.Now.Date.AddDays(-19), Products = billProduct10 },
                new Bill{BillId = "hd0011", EmployeeId = "nv0006", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 60,ComputerId = "mt0011", CustomerId = "kh0011", Date = DateTime.Now.Date.AddDays(-20), Products = billProduct11 },
                new Bill{BillId = "hd0012", EmployeeId = "nv0007", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 110,ComputerId = "mt0012", CustomerId = "kh0012", Date = DateTime.Now.Date.AddDays(-21), Products = billProduct12 },
                new Bill{BillId = "hd0013", EmployeeId = "nv0004", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 60,ComputerId = "mt0013", CustomerId = "kh0013", Date = DateTime.Now.Date.AddDays(-22), Products = billProduct13 },
                new Bill{BillId = "hd0014", EmployeeId = "nv0005", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 65,ComputerId = "mt0014", CustomerId = "kh0014", Date = DateTime.Now.Date.AddDays(-23), Products = billProduct14 },
                new Bill{BillId = "hd0015", EmployeeId = "nv0006", DiscountId = "gg0002", Status = "Chấp Nhận", Total = 55,ComputerId = "mt0015", CustomerId = "kh0015", Date = DateTime.Now.Date.AddDays(-24), Products = billProduct15 }
            };
            bills.ForEach(p => context.Bills.AddOrUpdate(
                bill => bill.BillId,
                new Bill
                {
                    BillId = p.BillId,
                    ComputerId = p.ComputerId,
                    CustomerId = p.CustomerId,
                    Status = p.Status,
                    Date = p.Date,
                    DiscountId = p.DiscountId,
                    IPClient = p.IPClient,
                    Total = p.Total,
                    DiscountPercent = p.DiscountPercent,
                    EmployeeId = p.EmployeeId,
                    Products = p.Products
                }));
            context.SaveChanges();
        }
    }
}
