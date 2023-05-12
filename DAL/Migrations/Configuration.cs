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
            CreateReciepts(context);
            CreateBillDays(context);
        }
        private void CreateAccounts(DAL.QLNETDBContext context)
        {
            #region Danh Sách Tài Khoản
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
                new Account {AccountId = "acc0017", UserName = "khachhang010", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0018", UserName = "khachhang011", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0019", UserName = "khachhang012", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0020", UserName = "khachhang013", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0021", UserName = "khachhang014", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0022", UserName = "khachhang015", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0023", UserName = "khachhang016", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0024", UserName = "khachhang017", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0025", UserName = "khachhang018", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0026", UserName = "khachhang019", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0027", UserName = "khachhang020", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0028", UserName = "khachhang021", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0029", UserName = "khachhang022", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0030", UserName = "khachhang023", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0031", UserName = "khachhang024", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0032", UserName = "khachhang025", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0033", UserName = "khachhang026", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0034", UserName = "khachhang027", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0035", UserName = "khachhang028", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0036", UserName = "khachhang029", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0037", UserName = "khachhang030", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0038", UserName = "khachhang031", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0039", UserName = "khachhang032", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0040", UserName = "khachhang033", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0041", UserName = "khachhang034", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0042", UserName = "khachhang035", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0043", UserName = "khachhang036", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0044", UserName = "khachhang037", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0045", UserName = "khachhang038", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0046", UserName = "khachhang039", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0047", UserName = "khachhang040", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0048", UserName = "khachhang041", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0049", UserName = "khachhang042", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0050", UserName = "khachhang043", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0051", UserName = "khachhang044", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0052", UserName = "khachhang045", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0053", UserName = "khachhang046", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0054", UserName = "khachhang047", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0055", UserName = "khachhang048", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0056", UserName = "khachhang049", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0057", UserName = "khachhang050", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0058", UserName = "khachhang051", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0059", UserName = "khachhang052", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0060", UserName = "khachhang053", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0061", UserName = "khachhang054", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0062", UserName = "khachhang055", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0063", UserName = "khachhang056", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0064", UserName = "khachhang057", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0065", UserName = "khachhang058", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0066", UserName = "khachhang059", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0067", UserName = "khachhang060", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0068", UserName = "khachhang061", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0069", UserName = "khachhang062", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0070", UserName = "khachhang063", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0071", UserName = "khachhang064", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0072", UserName = "khachhang065", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0073", UserName = "khachhang066", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0074", UserName = "khachhang067", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0075", UserName = "khachhang068", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0076", UserName = "khachhang069", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0077", UserName = "khachhang070", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0078", UserName = "khachhang071", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0079", UserName = "khachhang072", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0080", UserName = "khachhang073", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0081", UserName = "khachhang074", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0082", UserName = "khachhang075", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0083", UserName = "khachhang076", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0084", UserName = "khachhang077", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0085", UserName = "khachhang078", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0086", UserName = "khachhang079", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0087", UserName = "khachhang080", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0088", UserName = "khachhang081", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0089", UserName = "khachhang082", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0090", UserName = "khachhang083", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0091", UserName = "khachhang084", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0092", UserName = "khachhang085", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0093", UserName = "khachhang086", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0094", UserName = "khachhang087", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0095", UserName = "khachhang088", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0096", UserName = "khachhang089", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0097", UserName = "khachhang090", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0098", UserName = "khachhang091", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0099", UserName = "khachhang092", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0100", UserName = "khachhang093", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0101", UserName = "khachhang094", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0102", UserName = "khachhang095", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0103", UserName = "khachhang096", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0104", UserName = "khachhang097", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0105", UserName = "khachhang098", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0106", UserName = "khachhang099", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0107", UserName = "khachhang100", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0108", UserName = "khachhang101", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0109", UserName = "khachhang102", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0110", UserName = "khachhang103", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0111", UserName = "khachhang104", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0112", UserName = "khachhang105", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0113", UserName = "khachhang106", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0114", UserName = "khachhang107", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0115", UserName = "khachhang108", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0116", UserName = "khachhang109", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0117", UserName = "khachhang110", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0118", UserName = "khachhang111", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0119", UserName = "khachhang112", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0120", UserName = "khachhang113", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0121", UserName = "khachhang114", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0122", UserName = "khachhang115", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0123", UserName = "khachhang116", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0124", UserName = "khachhang117", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0125", UserName = "khachhang118", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0126", UserName = "khachhang119", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
                new Account {AccountId = "acc0127", UserName = "khachhang120", Password = "123", Role = "Khách Hàng", DateCreate = DateTime.Now.Date},
            };
            #endregion
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
            #region Danh Sách Khách Hàng
            var customers = new List<Customer>
            {
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
                new Customer {CustomerId = "kh0011", CustomerName = "Trần Thị Mai", Balance = 0, TypeCustomer = false, AccountId = "acc0018", TotalTime = 60},
                new Customer {CustomerId = "kh0012", CustomerName = "Hà Thị Băng", Balance = 0, TypeCustomer = false, AccountId = "acc0019", TotalTime = 60},
                new Customer {CustomerId = "kh0013", CustomerName = "Lưu Bảo Ngọc", Balance = 0, TypeCustomer = false, AccountId = "acc0020", TotalTime = 60},
                new Customer {CustomerId = "kh0014", CustomerName = "Ngô Quang Chuyên", Balance = 0, TypeCustomer = false, AccountId = "acc0021", TotalTime = 60},
                new Customer {CustomerId = "kh0015", CustomerName = "Văn Thị Minh", Balance = 0, TypeCustomer = false, AccountId = "acc0022", TotalTime = 60},
                new Customer {CustomerId = "kh0016", CustomerName = "Hoàng Thị Đoan", Balance = 0, TypeCustomer = false, AccountId = "acc0023", TotalTime = 60},
                new Customer {CustomerId = "kh0017", CustomerName = "Trịnh Ngọc Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0024", TotalTime = 60},
                new Customer {CustomerId = "kh0018", CustomerName = "Trần Văn Giang", Balance = 0, TypeCustomer = false, AccountId = "acc0025", TotalTime = 60},
                new Customer {CustomerId = "kh0019", CustomerName = "Nguyễn Quang Hiếu", Balance = 0, TypeCustomer = false, AccountId = "acc0026", TotalTime = 60},
                new Customer {CustomerId = "kh0020", CustomerName = "Trần Thị Hoa", Balance = 0, TypeCustomer = false, AccountId = "acc0027", TotalTime = 60},
                new Customer {CustomerId = "kh0021", CustomerName = "Đặng Thị Huyền", Balance = 0, TypeCustomer = false, AccountId = "acc0028", TotalTime = 60},
                new Customer {CustomerId = "kh0022", CustomerName = "Nguyễn Văn Kiên", Balance = 0, TypeCustomer = false, AccountId = "acc0029", TotalTime = 60},
                new Customer {CustomerId = "kh0023", CustomerName = "Lưu Thị Lan", Balance = 0, TypeCustomer = false, AccountId = "acc0030", TotalTime = 60},
                new Customer {CustomerId = "kh0024", CustomerName = "Đinh Thị Liên", Balance = 0, TypeCustomer = false, AccountId = "acc0031", TotalTime = 60},
                new Customer {CustomerId = "kh0025", CustomerName = "Nguyễn Xuân Mẫn", Balance = 0, TypeCustomer = false, AccountId = "acc0032", TotalTime = 60},
                new Customer {CustomerId = "kh0026", CustomerName = "Trần Đắc Dũng", Balance = 0, TypeCustomer = false, AccountId = "acc0033", TotalTime = 60},
                new Customer {CustomerId = "kh0027", CustomerName = "Võ Văn Quốc", Balance = 0, TypeCustomer = false, AccountId = "acc0034", TotalTime = 60},
                new Customer {CustomerId = "kh0028", CustomerName = "Nguyễn Đình Ánh", Balance = 0, TypeCustomer = false, AccountId = "acc0035", TotalTime = 60},
                new Customer {CustomerId = "kh0029", CustomerName = "Trương Quốc Hùng", Balance = 0, TypeCustomer = false, AccountId = "acc0036", TotalTime = 60},
                new Customer {CustomerId = "kh0030", CustomerName = "Phan Văn Tài", Balance = 0, TypeCustomer = false, AccountId = "acc0037", TotalTime = 60},
                new Customer {CustomerId = "kh0031", CustomerName = "Bùi Thị Duyên", Balance = 0, TypeCustomer = false, AccountId = "acc0038", TotalTime = 60},
                new Customer {CustomerId = "kh0032", CustomerName = "Ngô Thành Nam", Balance = 0, TypeCustomer = false, AccountId = "acc0039", TotalTime = 60},
                new Customer {CustomerId = "kh0033", CustomerName = "Đỗ Văn Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0040", TotalTime = 60},
                new Customer {CustomerId = "kh0034", CustomerName = "Đặng Bá Cường", Balance = 0, TypeCustomer = false, AccountId = "acc0041", TotalTime = 60},
                new Customer {CustomerId = "kh0035", CustomerName = "Phạm Tuấn Anh", Balance = 0, TypeCustomer = false, AccountId = "acc0042", TotalTime = 60},
                new Customer {CustomerId = "kh0036", CustomerName = "Vũ Anh Ninh", Balance = 0, TypeCustomer = false, AccountId = "acc0043", TotalTime = 60},
                new Customer {CustomerId = "kh0037", CustomerName = "Đào Văn Thanh", Balance = 0, TypeCustomer = false, AccountId = "acc0044", TotalTime = 60},
                new Customer {CustomerId = "kh0038", CustomerName = "Lưu Thùy Vân", Balance = 0, TypeCustomer = false, AccountId = "acc0045", TotalTime = 60},
                new Customer {CustomerId = "kh0039", CustomerName = "Trương Thành Long", Balance = 0, TypeCustomer = false, AccountId = "acc0046", TotalTime = 60},
                new Customer {CustomerId = "kh0040", CustomerName = "Đinh Hoàng Vũ", Balance = 0, TypeCustomer = false, AccountId = "acc0047", TotalTime = 60},
                new Customer {CustomerId = "kh0041", CustomerName = "Trần Thị Mai", Balance = 0, TypeCustomer = false, AccountId = "acc0048", TotalTime = 60},
                new Customer {CustomerId = "kh0042", CustomerName = "Hà Thị Băng", Balance = 0, TypeCustomer = false, AccountId = "acc0049", TotalTime = 60},
                new Customer {CustomerId = "kh0043", CustomerName = "Lưu Bảo Ngọc", Balance = 0, TypeCustomer = false, AccountId = "acc0050", TotalTime = 60},
                new Customer {CustomerId = "kh0044", CustomerName = "Ngô Quang Chuyên", Balance = 0, TypeCustomer = false, AccountId = "acc0051", TotalTime = 60},
                new Customer {CustomerId = "kh0045", CustomerName = "Văn Thị Minh", Balance = 0, TypeCustomer = false, AccountId = "acc0052", TotalTime = 60},
                new Customer {CustomerId = "kh0046", CustomerName = "Hoàng Thị Đoan", Balance = 0, TypeCustomer = false, AccountId = "acc0053", TotalTime = 60},
                new Customer {CustomerId = "kh0047", CustomerName = "Trịnh Ngọc Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0054", TotalTime = 60},
                new Customer {CustomerId = "kh0048", CustomerName = "Trần Văn Giang", Balance = 0, TypeCustomer = false, AccountId = "acc0055", TotalTime = 60},
                new Customer {CustomerId = "kh0049", CustomerName = "Nguyễn Quang Hiếu", Balance = 0, TypeCustomer = false, AccountId = "acc0056", TotalTime = 60},
                new Customer {CustomerId = "kh0050", CustomerName = "Trần Thị Hoa", Balance = 0, TypeCustomer = false, AccountId = "acc0057", TotalTime = 60},
                new Customer {CustomerId = "kh0051", CustomerName = "Đặng Thị Huyền", Balance = 0, TypeCustomer = false, AccountId = "acc0058", TotalTime = 60},
                new Customer {CustomerId = "kh0052", CustomerName = "Nguyễn Văn Kiên", Balance = 0, TypeCustomer = false, AccountId = "acc0059", TotalTime = 60},
                new Customer {CustomerId = "kh0053", CustomerName = "Lưu Thị Lan", Balance = 0, TypeCustomer = false, AccountId = "acc0060", TotalTime = 60},
                new Customer {CustomerId = "kh0054", CustomerName = "Đinh Thị Liên", Balance = 0, TypeCustomer = false, AccountId = "acc0061", TotalTime = 60},
                new Customer {CustomerId = "kh0055", CustomerName = "Nguyễn Xuân Mẫn", Balance = 0, TypeCustomer = false, AccountId = "acc0062", TotalTime = 60},
                new Customer {CustomerId = "kh0056", CustomerName = "Trần Đắc Dũng", Balance = 0, TypeCustomer = false, AccountId = "acc0063", TotalTime = 60},
                new Customer {CustomerId = "kh0057", CustomerName = "Võ Văn Quốc", Balance = 0, TypeCustomer = false, AccountId = "acc0064", TotalTime = 60},
                new Customer {CustomerId = "kh0058", CustomerName = "Nguyễn Đình Ánh", Balance = 0, TypeCustomer = false, AccountId = "acc0065", TotalTime = 60},
                new Customer {CustomerId = "kh0059", CustomerName = "Trương Quốc Hùng", Balance = 0, TypeCustomer = false, AccountId = "acc0066", TotalTime = 60},
                new Customer {CustomerId = "kh0060", CustomerName = "Phan Văn Tài", Balance = 0, TypeCustomer = false, AccountId = "acc0067", TotalTime = 60},
                new Customer {CustomerId = "kh0061", CustomerName = "Bùi Thị Duyên", Balance = 0, TypeCustomer = false, AccountId = "acc0068", TotalTime = 60},
                new Customer {CustomerId = "kh0062", CustomerName = "Ngô Thành Nam", Balance = 0, TypeCustomer = false, AccountId = "acc0069", TotalTime = 60},
                new Customer {CustomerId = "kh0063", CustomerName = "Đỗ Văn Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0070", TotalTime = 60},
                new Customer {CustomerId = "kh0064", CustomerName = "Đặng Bá Cường", Balance = 0, TypeCustomer = false, AccountId = "acc0071", TotalTime = 60},
                new Customer {CustomerId = "kh0065", CustomerName = "Phạm Tuấn Anh", Balance = 0, TypeCustomer = false, AccountId = "acc0072", TotalTime = 60},
                new Customer {CustomerId = "kh0066", CustomerName = "Vũ Anh Ninh", Balance = 0, TypeCustomer = false, AccountId = "acc0073", TotalTime = 60},
                new Customer {CustomerId = "kh0067", CustomerName = "Đào Văn Thanh", Balance = 0, TypeCustomer = false, AccountId = "acc0074", TotalTime = 60},
                new Customer {CustomerId = "kh0068", CustomerName = "Lưu Thùy Vân", Balance = 0, TypeCustomer = false, AccountId = "acc0075", TotalTime = 60},
                new Customer {CustomerId = "kh0069", CustomerName = "Trương Thành Long", Balance = 0, TypeCustomer = false, AccountId = "acc0076", TotalTime = 60},
                new Customer {CustomerId = "kh0070", CustomerName = "Đinh Hoàng Vũ", Balance = 0, TypeCustomer = false, AccountId = "acc0077", TotalTime = 60},
                new Customer {CustomerId = "kh0071", CustomerName = "Trần Thị Mai", Balance = 0, TypeCustomer = false, AccountId = "acc0078", TotalTime = 60},
                new Customer {CustomerId = "kh0072", CustomerName = "Hà Thị Băng", Balance = 0, TypeCustomer = false, AccountId = "acc0079", TotalTime = 60},
                new Customer {CustomerId = "kh0073", CustomerName = "Lưu Bảo Ngọc", Balance = 0, TypeCustomer = false, AccountId = "acc0080", TotalTime = 60},
                new Customer {CustomerId = "kh0074", CustomerName = "Ngô Quang Chuyên", Balance = 0, TypeCustomer = false, AccountId = "acc0081", TotalTime = 60},
                new Customer {CustomerId = "kh0075", CustomerName = "Văn Thị Minh", Balance = 0, TypeCustomer = false, AccountId = "acc0082", TotalTime = 60},
                new Customer {CustomerId = "kh0076", CustomerName = "Hoàng Thị Đoan", Balance = 0, TypeCustomer = false, AccountId = "acc0083", TotalTime = 60},
                new Customer {CustomerId = "kh0077", CustomerName = "Trịnh Ngọc Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0084", TotalTime = 60},
                new Customer {CustomerId = "kh0078", CustomerName = "Trần Văn Giang", Balance = 0, TypeCustomer = false, AccountId = "acc0085", TotalTime = 60},
                new Customer {CustomerId = "kh0079", CustomerName = "Nguyễn Quang Hiếu", Balance = 0, TypeCustomer = false, AccountId = "acc0086", TotalTime = 60},
                new Customer {CustomerId = "kh0080", CustomerName = "Trần Thị Hoa", Balance = 0, TypeCustomer = false, AccountId = "acc0087", TotalTime = 60},
                new Customer {CustomerId = "kh0081", CustomerName = "Đặng Thị Huyền", Balance = 0, TypeCustomer = false, AccountId = "acc0088", TotalTime = 60},
                new Customer {CustomerId = "kh0082", CustomerName = "Nguyễn Văn Kiên", Balance = 0, TypeCustomer = false, AccountId = "acc0089", TotalTime = 60},
                new Customer {CustomerId = "kh0083", CustomerName = "Lưu Thị Lan", Balance = 0, TypeCustomer = false, AccountId = "acc0090", TotalTime = 60},
                new Customer {CustomerId = "kh0084", CustomerName = "Đinh Thị Liên", Balance = 0, TypeCustomer = false, AccountId = "acc0091", TotalTime = 60},
                new Customer {CustomerId = "kh0085", CustomerName = "Nguyễn Xuân Mẫn", Balance = 0, TypeCustomer = false, AccountId = "acc0092", TotalTime = 60},
                new Customer {CustomerId = "kh0086", CustomerName = "Trần Đắc Dũng", Balance = 0, TypeCustomer = false, AccountId = "acc0093", TotalTime = 60},
                new Customer {CustomerId = "kh0087", CustomerName = "Võ Văn Quốc", Balance = 0, TypeCustomer = false, AccountId = "acc0094", TotalTime = 60},
                new Customer {CustomerId = "kh0088", CustomerName = "Nguyễn Đình Ánh", Balance = 0, TypeCustomer = false, AccountId = "acc0095", TotalTime = 60},
                new Customer {CustomerId = "kh0089", CustomerName = "Trương Quốc Hùng", Balance = 0, TypeCustomer = false, AccountId = "acc0096", TotalTime = 60},
                new Customer {CustomerId = "kh0090", CustomerName = "Phan Văn Tài", Balance = 0, TypeCustomer = false, AccountId = "acc0097", TotalTime = 60},
                new Customer {CustomerId = "kh0091", CustomerName = "Bùi Thị Duyên", Balance = 0, TypeCustomer = false, AccountId = "acc0098", TotalTime = 60},
                new Customer {CustomerId = "kh0092", CustomerName = "Ngô Thành Nam", Balance = 0, TypeCustomer = false, AccountId = "acc0099", TotalTime = 60},
                new Customer {CustomerId = "kh0093", CustomerName = "Đỗ Văn Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0100", TotalTime = 60},
                new Customer {CustomerId = "kh0094", CustomerName = "Đặng Bá Cường", Balance = 0, TypeCustomer = false, AccountId = "acc0101", TotalTime = 60},
                new Customer {CustomerId = "kh0095", CustomerName = "Phạm Tuấn Anh", Balance = 0, TypeCustomer = false, AccountId = "acc0102", TotalTime = 60},
                new Customer {CustomerId = "kh0096", CustomerName = "Vũ Anh Ninh", Balance = 0, TypeCustomer = false, AccountId = "acc0103", TotalTime = 60},
                new Customer {CustomerId = "kh0097", CustomerName = "Đào Văn Thanh", Balance = 0, TypeCustomer = false, AccountId = "acc0104", TotalTime = 60},
                new Customer {CustomerId = "kh0098", CustomerName = "Lưu Thùy Vân", Balance = 0, TypeCustomer = false, AccountId = "acc0105", TotalTime = 60},
                new Customer {CustomerId = "kh0099", CustomerName = "Trương Thành Long", Balance = 0, TypeCustomer = false, AccountId = "acc0106", TotalTime = 60},
                new Customer {CustomerId = "kh0100", CustomerName = "Đinh Hoàng Vũ", Balance = 0, TypeCustomer = false, AccountId = "acc0107", TotalTime = 60},
                new Customer {CustomerId = "kh0101", CustomerName = "Trần Thị Mai", Balance = 0, TypeCustomer = false, AccountId = "acc0108", TotalTime = 60},
                new Customer {CustomerId = "kh0102", CustomerName = "Hà Thị Băng", Balance = 0, TypeCustomer = false, AccountId = "acc0109", TotalTime = 60},
                new Customer {CustomerId = "kh0103", CustomerName = "Lưu Bảo Ngọc", Balance = 0, TypeCustomer = false, AccountId = "acc0110", TotalTime = 60},
                new Customer {CustomerId = "kh0104", CustomerName = "Ngô Quang Chuyên", Balance = 0, TypeCustomer = false, AccountId = "acc0111", TotalTime = 60},
                new Customer {CustomerId = "kh0105", CustomerName = "Văn Thị Minh", Balance = 0, TypeCustomer = false, AccountId = "acc0112", TotalTime = 60},
                new Customer {CustomerId = "kh0106", CustomerName = "Hoàng Thị Đoan", Balance = 0, TypeCustomer = false, AccountId = "acc0113", TotalTime = 60},
                new Customer {CustomerId = "kh0107", CustomerName = "Trịnh Ngọc Đức", Balance = 0, TypeCustomer = false, AccountId = "acc0114", TotalTime = 60},
                new Customer {CustomerId = "kh0108", CustomerName = "Trần Văn Giang", Balance = 0, TypeCustomer = false, AccountId = "acc0115", TotalTime = 60},
                new Customer {CustomerId = "kh0109", CustomerName = "Nguyễn Quang Hiếu", Balance = 0, TypeCustomer = false, AccountId = "acc0116", TotalTime = 60},
                new Customer {CustomerId = "kh0110", CustomerName = "Trần Thị Hoa", Balance = 0, TypeCustomer = false, AccountId = "acc0117", TotalTime = 60},
                new Customer {CustomerId = "kh0111", CustomerName = "Đặng Thị Huyền", Balance = 0, TypeCustomer = false, AccountId = "acc0118", TotalTime = 60},
                new Customer {CustomerId = "kh0112", CustomerName = "Nguyễn Văn Kiên", Balance = 0, TypeCustomer = false, AccountId = "acc0119", TotalTime = 60},
                new Customer {CustomerId = "kh0113", CustomerName = "Lưu Thị Lan", Balance = 0, TypeCustomer = false, AccountId = "acc0120", TotalTime = 60},
                new Customer {CustomerId = "kh0114", CustomerName = "Đinh Thị Liên", Balance = 0, TypeCustomer = false, AccountId = "acc0121", TotalTime = 60},
                new Customer {CustomerId = "kh0115", CustomerName = "Nguyễn Xuân Mẫn", Balance = 0, TypeCustomer = false, AccountId = "acc0122", TotalTime = 60},
                new Customer {CustomerId = "kh0116", CustomerName = "Trần Đắc Dũng", Balance = 0, TypeCustomer = false, AccountId = "acc0123", TotalTime = 60},
                new Customer {CustomerId = "kh0117", CustomerName = "Võ Văn Quốc", Balance = 0, TypeCustomer = false, AccountId = "acc0124", TotalTime = 60},
                new Customer {CustomerId = "kh0118", CustomerName = "Nguyễn Đình Ánh", Balance = 0, TypeCustomer = false, AccountId = "acc0125", TotalTime = 60},
                new Customer {CustomerId = "kh0119", CustomerName = "Trương Quốc Hùng", Balance = 0, TypeCustomer = false, AccountId = "acc0126", TotalTime = 60},
                new Customer {CustomerId = "kh0120", CustomerName = "Phan Văn Tài", Balance = 0, TypeCustomer = false, AccountId = "acc0127", TotalTime = 60}
            };
            #endregion
            customers.ForEach(p => context.Customers.AddOrUpdate(
                customer => customer.CustomerId,
                new Customer
                {
                    CustomerId = p.CustomerId,
                    CustomerName = p.CustomerName,
                    Balance = p.Balance,
                    AccountId = p.AccountId,
                    TotalTime = p.TotalTime,
                    TypeCustomer = p.TypeCustomer,
                }));
            context.SaveChanges();
        }
        private void CreateEmployees(DAL.QLNETDBContext context)
        {
            #region Danh Sách Nhân Viên
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
            #endregion
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
            #region Danh Sách Các Loại Máy Tính
            var typecomputers = new List<TypeComputer>
            {
                new TypeComputer {TypeId = "type0001", NameType = "Máy Thường", Price = 8, ColorId = "#FF6666"},
                new TypeComputer {TypeId = "type0002", NameType = "Máy Game Moba", Price = 9, ColorId = "#FFFF00"},
                new TypeComputer {TypeId = "type0003", NameType = "Máy Game FPS", Price = 9, ColorId = "#00CC00"},
                new TypeComputer {TypeId = "type0004", NameType = "Máy Thi Đấu", Price = 10, ColorId = "#663300"},
                new TypeComputer {TypeId = "type0005", NameType = "Máy Stream", Price = 15, ColorId = "#404040"},
                new TypeComputer {TypeId = "type0006", NameType = "Máy Luyện Tập", Price = 8, ColorId = "#99004C"}
            };
            #endregion
            typecomputers.ForEach(p => context.TypeComputers.AddOrUpdate(
                typecomputer => typecomputer.TypeId,
                new TypeComputer
                {
                    TypeId = p.TypeId,
                    NameType = p.NameType,
                    Price = p.Price,
                    ColorId = p.ColorId,
                }));
            context.SaveChanges();
        }
        private void CreateComputers(DAL.QLNETDBContext context)
        {
            var computers = new List<Computer>
            {
                #region Danh Sách Máy Tính
                new Computer {ComputerId = "mt0001", ComputerName = "1", TypeId = "type0001", Status = "Đang Hoạt Động", IPComputer = "192.168.1.6"},
                new Computer {ComputerId = "mt0002", ComputerName = "2", TypeId = "type0002", Status = "Đang Hoạt Động", IPComputer = "192.168.1.42"},
                new Computer {ComputerId = "mt0003", ComputerName = "3", TypeId = "type0003", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0004", ComputerName = "4", TypeId = "type0004", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0005", ComputerName = "5", TypeId = "type0005", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0006", ComputerName = "6", TypeId = "type0006", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0007", ComputerName = "7", TypeId = "type0001", Status = "Bảo Trì"},
                new Computer {ComputerId = "mt0008", ComputerName = "8", TypeId = "type0002", Status = "Đang Hoạt Động"},
                new Computer {ComputerId = "mt0009", ComputerName = "9", TypeId = "type0003", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0010", ComputerName = "10", TypeId = "type0004", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0011", ComputerName = "11", TypeId = "type0001", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0012", ComputerName = "12", TypeId = "type0002", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0013", ComputerName = "13", TypeId = "type0003", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0014", ComputerName = "14", TypeId = "type0004", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0015", ComputerName = "15", TypeId = "type0005", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0016", ComputerName = "16", TypeId = "type0006", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0017", ComputerName = "17", TypeId = "type0001", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0018", ComputerName = "18", TypeId = "type0002", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0019", ComputerName = "19", TypeId = "type0003", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0020", ComputerName = "20", TypeId = "type0004", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0021", ComputerName = "21", TypeId = "type0001", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0022", ComputerName = "22", TypeId = "type0002", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0023", ComputerName = "23", TypeId = "type0003", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0024", ComputerName = "24", TypeId = "type0004", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0025", ComputerName = "25", TypeId = "type0005", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0026", ComputerName = "26", TypeId = "type0006", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0027", ComputerName = "27", TypeId = "type0001", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0028", ComputerName = "28", TypeId = "type0002", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0029", ComputerName = "29", TypeId = "type0003", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0030", ComputerName = "30", TypeId = "type0004", Status = "Đã Tắt"},
                new Computer {ComputerId = "mt0031", ComputerName = "0", TypeId = "type0001", Status = "Đã Tắt"}
                #endregion
            };
            computers.ForEach(p => context.Computers.AddOrUpdate(
                computer => computer.ComputerId,
                new Computer
                {
                    ComputerId = p.ComputerId,
                    ComputerName = p.ComputerName,
                    TypeId = p.TypeId,
                    Status = p.Status,
                    IPComputer = p.IPComputer
                }));
            context.SaveChanges();
        }
        private void CreateProducts(DAL.QLNETDBContext context)
        {
            #region Danh Sách Sản Phẩm
            var products = new List<Product>
            {
                new Product {ProductId = "sp0001", ProductName = "Mỳ Tôm", SellingPrice = 10, Type = "Đồ Ăn", Stock = 15, Discription = " ", CostPrice = 8, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("mytom.jpg"))},
                new Product {ProductId = "sp0002", ProductName = "Miến Gà", SellingPrice = 15, Type = "Đồ Ăn", Stock = 15, Discription = " ", CostPrice = 10, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("mien.jpg"))},
                new Product {ProductId = "sp0003", ProductName = "Cơm Chiên", SellingPrice = 20, Type = "Đồ Ăn", Stock = 5, Discription = " ", CostPrice = 15, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("comchien.jpg"))},
                new Product {ProductId = "sp0004", ProductName = "Gà Rán", SellingPrice = 25, Type = "Đồ Ăn", Stock = 10, Discription = " ", CostPrice = 20, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("garan.jpg"))},
                new Product {ProductId = "sp0005", ProductName = "Coca Cola", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", CostPrice = 8, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("cocacola.jpg"))},
                new Product {ProductId = "sp0006", ProductName = "Soda", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", CostPrice = 8, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("soda.jpg"))},
                new Product {ProductId = "sp0007", ProductName = "Sting", SellingPrice = 10, Type = "Nước Uống", Stock = 15, Discription = " ", CostPrice = 8, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("sting.jpg"))},
                new Product {ProductId = "sp0008", ProductName = "Thuốc Lá", SellingPrice = 20, Type = "Đồ Ăn", Stock = 15, Discription = " ", CostPrice = 15, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("thuocla.jpg"))},
                new Product {ProductId = "sp0009", ProductName = "Trà Đào", SellingPrice = 20, Type = "Nước Uống", Stock = 15, Discription = " ", CostPrice = 15, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("tradao.jpg"))},
                new Product {ProductId = "sp0010", ProductName = "Trà Sữa", SellingPrice = 25, Type = "Nước Uống", Stock = 15, Discription = " ", CostPrice = 20, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("trasua.jpg"))},
                new Product {ProductId = "sp0011", ProductName = "Phở Bò", SellingPrice = 15, Type = "Đồ Ăn", Stock = 10, Discription = " ", CostPrice = 10, Status = true, ProductImage = GetImageByFilePath(ConvertToFilePath("pho.jpg"))},
                new Product {ProductId = "sp0012", ProductName = "Nạp Tiền", Type = "Thẻ", Stock = 1, Status = true}
            };
            #endregion
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
                    CostPrice = p.CostPrice,
                    Status = p.Status,
                    ProductImage = p.ProductImage,
                }));
            context.SaveChanges();
        }
        private string ConvertToFilePath(string nameImg)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\DAL\bin\Debug", ""), "img", nameImg);
        }
        private byte[] GetImageByFilePath(string filePath)
        {
            Image img = Image.FromFile(filePath);
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                imageBytes = ms.ToArray();
            }
            return imageBytes;
        }
        private void CreateDiscounts(DAL.QLNETDBContext context)
        {
            #region Danh Sách Giảm Giá
            var discounts = new List<Discount>
            {
                new Discount {DiscountId = "gg0001", DiscountName = "Khách Thường Không Giảm Giá", DiscountPercent = 0, TypeCustomer = false},
                new Discount {DiscountId = "gg0002", DiscountName = "Giảm Giá Khách VIP", DiscountPercent = 10, TypeCustomer = true},
                new Discount {DiscountId = "gg0003", DiscountName = "Giảm Giá Sự Kiện", DiscountPercent = 10, TypeCustomer = false},
                new Discount {DiscountId = "gg0004", DiscountName = "Giảm Giá Sự Kiện Khách VIP", DiscountPercent = 15, TypeCustomer = true}
            };
            #endregion
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
            #region Danh Sách Giảm Giá Trong Một Hóa Đơn
            List<List<BillDiscount>> ListAllBillDiscount = new List<List<BillDiscount>>();
            var billDiscount1 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0001"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0001"}
            };
            ListAllBillDiscount.Add(billDiscount1);
            var billDiscount2 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0002"}
            };
            ListAllBillDiscount.Add(billDiscount2);
            var billDiscount3 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0003"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0003"}
            };
            ListAllBillDiscount.Add(billDiscount3);
            var billDiscount4 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0004"}
            };
            ListAllBillDiscount.Add(billDiscount4);
            var billDiscount5 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0005"}
            };
            ListAllBillDiscount.Add(billDiscount5);
            var billDiscount6 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0006"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0006"}
            };
            ListAllBillDiscount.Add(billDiscount6);
            var billDiscount7 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0007"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0007"}
            };
            ListAllBillDiscount.Add(billDiscount7);
            var billDiscount8 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0008"}
            };
            ListAllBillDiscount.Add(billDiscount8);
            var billDiscount9 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0009"}
            };
            ListAllBillDiscount.Add(billDiscount9);
            var billDiscount10 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0010"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0010"}
            };
            ListAllBillDiscount.Add(billDiscount10);
            var billDiscount11 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0011"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0011"}
            };
            ListAllBillDiscount.Add(billDiscount11);
            var billDiscount12 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0012"}
            };
            ListAllBillDiscount.Add(billDiscount12);
            var billDiscount13 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0013"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0013"}
            };
            ListAllBillDiscount.Add(billDiscount13);
            var billDiscount14 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0014"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0014"}
            };
            ListAllBillDiscount.Add(billDiscount14);
            var billDiscount15 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0015"}
            };
            ListAllBillDiscount.Add(billDiscount15);
            var billDiscount16 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0016"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0016"}
            };
            ListAllBillDiscount.Add(billDiscount16);
            var billDiscount17 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0017"}
            };
            ListAllBillDiscount.Add(billDiscount17);
            var billDiscount18 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0018"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0018"}
            };
            ListAllBillDiscount.Add(billDiscount18);
            var billDiscount19 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0019"}
            };
            ListAllBillDiscount.Add(billDiscount19);
            var billDiscount20 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0020"}
            };
            ListAllBillDiscount.Add(billDiscount20);
            var billDiscount21 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0021"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0021"}
            };
            ListAllBillDiscount.Add(billDiscount21);
            var billDiscount22 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0022"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0022"}
            };
            ListAllBillDiscount.Add(billDiscount22);
            var billDiscount23 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0023"}
            };
            ListAllBillDiscount.Add(billDiscount23);
            var billDiscount24 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0024"}
            };
            ListAllBillDiscount.Add(billDiscount24);
            var billDiscount25 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0025"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0025"}
            };
            ListAllBillDiscount.Add(billDiscount25);
            var billDiscount26 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0026"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0026"}
            };
            ListAllBillDiscount.Add(billDiscount26);
            var billDiscount27 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0027"}
            };
            ListAllBillDiscount.Add(billDiscount27);
            var billDiscount28 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0028"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0028"}
            };
            ListAllBillDiscount.Add(billDiscount28);
            var billDiscount29 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0029"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0029"}
            };
            ListAllBillDiscount.Add(billDiscount29);
            var billDiscount30 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0030"}
            };
            ListAllBillDiscount.Add(billDiscount30);
            var billDiscount31 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0031"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0031"}
            };
            ListAllBillDiscount.Add(billDiscount31);
            var billDiscount32 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0032"}
            };
            ListAllBillDiscount.Add(billDiscount32);
            var billDiscount33 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0033"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0033"}
            };
            ListAllBillDiscount.Add(billDiscount33);
            var billDiscount34 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0034"}
            };
            ListAllBillDiscount.Add(billDiscount34);
            var billDiscount35 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0035"}
            };
            ListAllBillDiscount.Add(billDiscount35);
            var billDiscount36 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0036"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0036"}
            };
            ListAllBillDiscount.Add(billDiscount36);
            var billDiscount37 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0037"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0037"}
            };
            ListAllBillDiscount.Add(billDiscount37);
            var billDiscount38 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0038"}
            };
            ListAllBillDiscount.Add(billDiscount38);
            var billDiscount39 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0039"}
            };
            ListAllBillDiscount.Add(billDiscount39);
            var billDiscount40 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0040"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0040"}
            };
            ListAllBillDiscount.Add(billDiscount40);
            var billDiscount41 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0041"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0041"}
            };
            ListAllBillDiscount.Add(billDiscount41);
            var billDiscount42 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0042"}
            };
            ListAllBillDiscount.Add(billDiscount42);
            var billDiscount43 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0043"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0043"}
            };
            ListAllBillDiscount.Add(billDiscount43);
            var billDiscount44 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0044"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0044"}
            };
            ListAllBillDiscount.Add(billDiscount44);
            var billDiscount45 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0045"}
            };
            ListAllBillDiscount.Add(billDiscount45);
            var billDiscount46 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0046"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0046"}
            };
            ListAllBillDiscount.Add(billDiscount46);
            var billDiscount47 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0047"}
            };
            ListAllBillDiscount.Add(billDiscount47);
            var billDiscount48 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0048"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0048"}
            };
            ListAllBillDiscount.Add(billDiscount48);
            var billDiscount49 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0049"}
            };
            ListAllBillDiscount.Add(billDiscount49);
            var billDiscount50 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0050"}
            };
            ListAllBillDiscount.Add(billDiscount50);
            var billDiscount51 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0051"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0051"}
            };
            ListAllBillDiscount.Add(billDiscount51);
            var billDiscount52 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0052"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0052"}
            };
            ListAllBillDiscount.Add(billDiscount52);
            var billDiscount53 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0053"}
            };
            ListAllBillDiscount.Add(billDiscount53);
            var billDiscount54 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0054"}
            };
            ListAllBillDiscount.Add(billDiscount54);
            var billDiscount55 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0055"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0055"}
            };
            ListAllBillDiscount.Add(billDiscount55);
            var billDiscount56 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0056"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0056"}
            };
            ListAllBillDiscount.Add(billDiscount56);
            var billDiscount57 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0057"}
            };
            ListAllBillDiscount.Add(billDiscount57);
            var billDiscount58 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0058"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0058"}
            };
            ListAllBillDiscount.Add(billDiscount58);
            var billDiscount59 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0059"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0059"}
            };
            ListAllBillDiscount.Add(billDiscount59);
            var billDiscount60 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0060"}
            };
            ListAllBillDiscount.Add(billDiscount60);
            var billDiscount61 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0061"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0061"}
            };
            ListAllBillDiscount.Add(billDiscount61);
            var billDiscount62 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0062"}
            };
            ListAllBillDiscount.Add(billDiscount62);
            var billDiscount63 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0063"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0063"}
            };
            ListAllBillDiscount.Add(billDiscount63);
            var billDiscount64 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0064"}
            };
            ListAllBillDiscount.Add(billDiscount64);
            var billDiscount65 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0065"}
            };
            ListAllBillDiscount.Add(billDiscount65);
            var billDiscount66 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0066"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0066"}
            };
            ListAllBillDiscount.Add(billDiscount66);
            var billDiscount67 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0067"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0067"}
            };
            ListAllBillDiscount.Add(billDiscount67);
            var billDiscount68 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0068"}
            };
            ListAllBillDiscount.Add(billDiscount68);
            var billDiscount69 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0069"}
            };
            ListAllBillDiscount.Add(billDiscount69);
            var billDiscount70 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0070"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0070"}
            };
            ListAllBillDiscount.Add(billDiscount70);
            var billDiscount71 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0071"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0071"}
            };
            ListAllBillDiscount.Add(billDiscount71);
            var billDiscount72 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0072"}
            };
            ListAllBillDiscount.Add(billDiscount72);
            var billDiscount73 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0073"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0073"}
            };
            ListAllBillDiscount.Add(billDiscount73);
            var billDiscount74 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0074"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0074"}
            };
            ListAllBillDiscount.Add(billDiscount74);
            var billDiscount75 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0075"}
            };
            ListAllBillDiscount.Add(billDiscount75);
            var billDiscount76 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0076"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0076"}
            };
            ListAllBillDiscount.Add(billDiscount76);
            var billDiscount77 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0077"}
            };
            ListAllBillDiscount.Add(billDiscount77);
            var billDiscount78 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0078"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0078"}
            };
            ListAllBillDiscount.Add(billDiscount78);
            var billDiscount79 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0079"}
            };
            ListAllBillDiscount.Add(billDiscount79);
            var billDiscount80 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0080"}
            };
            ListAllBillDiscount.Add(billDiscount80);
            var billDiscount81 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0081"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0081"}
            };
            ListAllBillDiscount.Add(billDiscount81);
            var billDiscount82 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0082"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0082"}
            };
            ListAllBillDiscount.Add(billDiscount82);
            var billDiscount83 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0083"}
            };
            ListAllBillDiscount.Add(billDiscount83);
            var billDiscount84 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0084"}
            };
            ListAllBillDiscount.Add(billDiscount84);
            var billDiscount85 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0085"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0085"}
            };
            ListAllBillDiscount.Add(billDiscount85);
            var billDiscount86 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0086"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0086"}
            };
            ListAllBillDiscount.Add(billDiscount86);
            var billDiscount87 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0087"}
            };
            ListAllBillDiscount.Add(billDiscount87);
            var billDiscount88 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0088"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0088"}
            };
            ListAllBillDiscount.Add(billDiscount88);
            var billDiscount89 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0089"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0089"}
            };
            ListAllBillDiscount.Add(billDiscount89);
            var billDiscount90 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0090"}
            };
            ListAllBillDiscount.Add(billDiscount90);
            var billDiscount91 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0091"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0091"}
            };
            ListAllBillDiscount.Add(billDiscount91);
            var billDiscount92 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0092"}
            };
            ListAllBillDiscount.Add(billDiscount92);
            var billDiscount93 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0093"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0093"}
            };
            ListAllBillDiscount.Add(billDiscount93);
            var billDiscount94 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0094"}
            };
            ListAllBillDiscount.Add(billDiscount94);
            var billDiscount95 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0095"}
            };
            ListAllBillDiscount.Add(billDiscount95);
            var billDiscount96 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0096"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0096"}
            };
            ListAllBillDiscount.Add(billDiscount96);
            var billDiscount97 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0097"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0097"}
            };
            ListAllBillDiscount.Add(billDiscount97);
            var billDiscount98 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0098"}
            };
            ListAllBillDiscount.Add(billDiscount98);
            var billDiscount99 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0099"}
            };
            ListAllBillDiscount.Add(billDiscount99);
            var billDiscount100 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0100"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0100"}
            };
            ListAllBillDiscount.Add(billDiscount100);
            var billDiscount101 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0101"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0101"}
            };
            ListAllBillDiscount.Add(billDiscount101);
            var billDiscount102 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0102"}
            };
            ListAllBillDiscount.Add(billDiscount102);
            var billDiscount103 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0103"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0103"}
            };
            ListAllBillDiscount.Add(billDiscount103);
            var billDiscount104 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0104"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0104"}
            };
            ListAllBillDiscount.Add(billDiscount104);
            var billDiscount105 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0105"}
            };
            ListAllBillDiscount.Add(billDiscount105);
            var billDiscount106 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0106"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0106"}
            };
            ListAllBillDiscount.Add(billDiscount106);
            var billDiscount107 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0107"}
            };
            ListAllBillDiscount.Add(billDiscount107);
            var billDiscount108 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0108"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0108"}
            };
            ListAllBillDiscount.Add(billDiscount108);
            var billDiscount109 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0109"}
            };
            ListAllBillDiscount.Add(billDiscount109);
            var billDiscount110 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0110"}
            };
            ListAllBillDiscount.Add(billDiscount110);
            var billDiscount111 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0111"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0111"}
            };
            ListAllBillDiscount.Add(billDiscount111);
            var billDiscount112 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0112"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0112"}
            };
            ListAllBillDiscount.Add(billDiscount112);
            var billDiscount113 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0113"}
            };
            ListAllBillDiscount.Add(billDiscount113);
            var billDiscount114 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0114"}
            };
            ListAllBillDiscount.Add(billDiscount114);
            var billDiscount115 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0115"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0115"}
            };
            ListAllBillDiscount.Add(billDiscount115);
            var billDiscount116 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0116"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0116"}
            };
            ListAllBillDiscount.Add(billDiscount116);
            var billDiscount117 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0117"}
            };
            ListAllBillDiscount.Add(billDiscount117);
            var billDiscount118 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0118"},
                new BillDiscount {DiscountId = "gg0004", BillId = "hd0118"}
            };
            ListAllBillDiscount.Add(billDiscount118);
            var billDiscount119 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0001", BillId = "hd0119"},
                new BillDiscount {DiscountId = "gg0003", BillId = "hd0119"}
            };
            ListAllBillDiscount.Add(billDiscount119);
            var billDiscount120 = new List<BillDiscount>
            {
                new BillDiscount {DiscountId = "gg0002", BillId = "hd0120"}
            };
            ListAllBillDiscount.Add(billDiscount120);
            #endregion
            #region Danh Sách Món Ăn Trong 1 Hóa Đơn
            List<List<BillProduct>> ListAllBillProduct = new List<List<BillProduct>>();
            //80
            var billProduct1 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0001", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0001", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0001", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct1);
            //75
            var billProduct2 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0002", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0002", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0002", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct2);
            //55
            var billProduct3 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0003", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0003", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0003", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct3);
            //75
            var billProduct4 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0004", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0004", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0004", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct4);
            //70
            var billProduct5 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0005", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0005", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0005", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct5);
            //55
            var billProduct6 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0006", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0006", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0006", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct6);
            //90
            var billProduct7 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0007", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0007", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0007", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct7);
            //90
            var billProduct8 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0008", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0008", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0008", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct8);
            //75
            var billProduct9 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0009", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0009", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0009", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct9);
            //65
            var billProduct10 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0010", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0010", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0010", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct10);
            //60
            var billProduct11 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0011", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0011", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0011", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct11);
            //110
            var billProduct12 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0012", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0012", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0012", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct12);
            //60
            var billProduct13 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0013", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0013", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0013", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct13);
            //65
            var billProduct14 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0014", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0014", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0014", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct14);
            //55
            var billProduct15 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0015", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0015", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0015", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct15);
            //80
            var billProduct16 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0016", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0016", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0016", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct16);
            //75
            var billProduct17 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0017", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0017", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0017", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct17);
            //55
            var billProduct18 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0018", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0018", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0018", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct18);
            //75
            var billProduct19 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0019", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0019", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0019", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct19);
            //70
            var billProduct20 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0020", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0020", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0020", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct20);
            //55
            var billProduct21 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0021", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0021", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0021", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct21);
            //90
            var billProduct22 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0022", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0022", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0022", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct22);
            //90
            var billProduct23 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0023", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0023", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0023", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct23);
            //75
            var billProduct24 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0024", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0024", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0024", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct24);
            //65
            var billProduct25 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0025", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0025", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0025", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct25);
            //60
            var billProduct26 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0026", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0026", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0026", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct26);
            //110
            var billProduct27 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0027", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0027", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0027", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct27);
            //60
            var billProduct28 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0028", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0028", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0028", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct28);
            //65
            var billProduct29 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0029", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0029", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0029", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct29);
            //55
            var billProduct30 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0030", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0030", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0030", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct30);
            //80
            var billProduct31 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0031", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0031", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0031", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct31);
            //75
            var billProduct32 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0032", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0032", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0032", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct32);
            //55
            var billProduct33 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0033", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0033", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0033", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct33);
            //75
            var billProduct34 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0034", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0034", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0034", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct34);
            //70
            var billProduct35 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0035", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0035", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0035", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct35);
            //55
            var billProduct36 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0036", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0036", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0036", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct36);
            //90
            var billProduct37 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0037", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0037", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0037", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct37);
            //90
            var billProduct38 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0038", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0038", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0038", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct38);
            //75
            var billProduct39 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0039", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0039", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0039", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct39);
            //65
            var billProduct40 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0040", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0040", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0040", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct40);
            //60
            var billProduct41 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0041", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0041", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0041", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct41);
            //110
            var billProduct42 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0042", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0042", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0042", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct42);
            //60
            var billProduct43 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0043", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0043", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0043", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct43);
            //65
            var billProduct44 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0044", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0044", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0044", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct44);
            //55
            var billProduct45 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0045", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0045", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0045", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct45);
            //80
            var billProduct46 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0046", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0046", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0046", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct46);
            //75
            var billProduct47 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0047", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0047", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0047", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct47);
            //55
            var billProduct48 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0048", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0048", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0048", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct48);
            //75
            var billProduct49 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0049", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0049", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0049", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct49);
            //70
            var billProduct50 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0050", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0050", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0050", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct50);
            //55
            var billProduct51 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0051", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0051", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0051", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct51);
            //90
            var billProduct52 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0052", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0052", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0052", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct52);
            //90
            var billProduct53 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0053", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0053", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0053", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct53);
            //75
            var billProduct54 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0054", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0054", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0054", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct54);
            //65
            var billProduct55 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0055", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0055", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0055", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct55);
            //60
            var billProduct56 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0056", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0056", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0056", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct56);
            //110
            var billProduct57 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0057", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0057", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0057", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct57);
            //60
            var billProduct58 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0058", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0058", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0058", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct58);
            //65
            var billProduct59 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0059", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0059", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0059", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct59);
            //55
            var billProduct60 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0060", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0060", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0060", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct60);
            var billProduct61 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0061", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0061", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0061", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct61);
            //75
            var billProduct62 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0062", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0062", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0062", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct62);
            //55
            var billProduct63 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0063", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0063", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0063", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct63);
            //75
            var billProduct64 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0064", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0064", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0064", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct64);
            //70
            var billProduct65 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0065", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0065", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0065", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct65);
            //55
            var billProduct66 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0066", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0066", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0066", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct66);
            //90
            var billProduct67 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0067", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0067", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0067", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct67);
            //90
            var billProduct68 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0068", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0068", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0068", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct68);
            //75
            var billProduct69 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0069", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0069", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0069", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct69);
            //65
            var billProduct70 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0070", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0070", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0070", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct70);
            //60
            var billProduct71 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0071", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0071", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0071", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct71);
            //110
            var billProduct72 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0072", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0072", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0072", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct72);
            //60
            var billProduct73 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0073", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0073", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0073", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct73);
            //65
            var billProduct74 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0074", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0074", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0074", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct74);
            //55
            var billProduct75 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0075", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0075", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0075", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct75);
            //80
            var billProduct76 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0076", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0076", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0076", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct76);
            //75
            var billProduct77 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0077", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0077", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0077", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct77);
            //55
            var billProduct78 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0078", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0078", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0078", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct78);
            //75
            var billProduct79 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0079", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0079", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0079", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct79);
            //70
            var billProduct80 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0080", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0080", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0080", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct80);
            //55
            var billProduct81 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0081", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0081", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0081", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct81);
            //90
            var billProduct82 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0082", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0082", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0082", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct82);
            //90
            var billProduct83 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0083", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0083", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0083", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct83);
            //75
            var billProduct84 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0084", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0084", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0084", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct84);
            //65
            var billProduct85 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0085", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0085", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0085", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct85);
            //60
            var billProduct86 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0086", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0086", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0086", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct86);
            //110
            var billProduct87 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0087", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0087", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0087", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct87);
            //60
            var billProduct88 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0088", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0088", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0088", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct88);
            //65
            var billProduct89 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0089", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0089", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0089", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct89);
            //55
            var billProduct90 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0090", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0090", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0090", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct90);
            //80
            var billProduct91 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0091", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0091", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0091", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct91);
            //75
            var billProduct92 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0092", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0092", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0092", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct92);
            //55
            var billProduct93 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0093", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0093", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0093", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct93);
            //75
            var billProduct94 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0094", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0094", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0094", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct94);
            //70
            var billProduct95 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0095", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0095", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0095", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct95);
            //55
            var billProduct96 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0096", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0096", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0096", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct96);
            //90
            var billProduct97 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0097", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0097", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0097", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct97);
            //90
            var billProduct98 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0098", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0098", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0098", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct98);
            //75
            var billProduct99 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0099", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0099", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0099", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct99);
            //65
            var billProduct100 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0100", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0100", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0100", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct100);
            //60
            var billProduct101 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0101", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0101", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0101", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct101);
            //110
            var billProduct102 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0102", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0102", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0102", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct102);
            //60
            var billProduct103 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0103", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0103", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0103", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct103);
            //65
            var billProduct104 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0104", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0104", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0104", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct104);
            //55
            var billProduct105 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0105", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0105", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0105", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct105);
            //80
            var billProduct106 = new List<BillProduct>
            {
                new BillProduct { ProductId = "sp0001", BillId = "hd0106", Quantity = 2},
                new BillProduct { ProductId = "sp0008", BillId = "hd0106", Quantity = 2},
                new BillProduct { ProductId = "sp0009", BillId = "hd0106", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct106);
            //75
            var billProduct107 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0107", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0107", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0107", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct107);
            //55
            var billProduct108 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0108", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0108", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0108", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct108);
            //75
            var billProduct109 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0109", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0109", Quantity = 1},
                new BillProduct {ProductId = "sp0005", BillId = "hd0109", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct109);
            //70
            var billProduct110 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0110", Quantity = 1},
                new BillProduct {ProductId = "sp0004", BillId = "hd0110", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0110", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct110);
            //55
            var billProduct111 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0111", Quantity = 1},
                new BillProduct {ProductId = "sp0007", BillId = "hd0111", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0111", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct111);
            //90
            var billProduct112 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0112", Quantity = 2},
                new BillProduct {ProductId = "sp0004", BillId = "hd0112", Quantity = 2},
                new BillProduct {ProductId = "sp0001", BillId = "hd0112", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct112);
            //90
            var billProduct113 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0113", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0113", Quantity = 1},
                new BillProduct {ProductId = "sp0009", BillId = "hd0113", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct113);
            //75
            var billProduct114 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0007", BillId = "hd0114", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0114", Quantity = 2},
                new BillProduct {ProductId = "sp0011", BillId = "hd0114", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct114);
            //65
            var billProduct115 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0006", BillId = "hd0115", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0115", Quantity = 1},
                new BillProduct {ProductId = "sp0010", BillId = "hd0115", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct115);
            //60
            var billProduct116 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0003", BillId = "hd0116", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0116", Quantity = 2},
                new BillProduct {ProductId = "sp0007", BillId = "hd0116", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct116);
            //110
            var billProduct117 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0004", BillId = "hd0117", Quantity = 2},
                new BillProduct {ProductId = "sp0009", BillId = "hd0117", Quantity = 2},
                new BillProduct {ProductId = "sp0008", BillId = "hd0117", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct117);
            //60
            var billProduct118 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0118", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0118", Quantity = 2},
                new BillProduct {ProductId = "sp0005", BillId = "hd0118", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct118);
            //65
            var billProduct119 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0002", BillId = "hd0119", Quantity = 1},
                new BillProduct {ProductId = "sp0006", BillId = "hd0119", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0119", Quantity = 2}
            };
            ListAllBillProduct.Add(billProduct119);
            //55
            var billProduct120 = new List<BillProduct>
            {
                new BillProduct {ProductId = "sp0001", BillId = "hd0120", Quantity = 2},
                new BillProduct {ProductId = "sp0002", BillId = "hd0120", Quantity = 1},
                new BillProduct {ProductId = "sp0003", BillId = "hd0120", Quantity = 1}
            };
            ListAllBillProduct.Add(billProduct120);
            #endregion
            CreateBillDiscounts(context, ListAllBillDiscount);
            CreateBillProducts(context, ListAllBillProduct);
            #region Danh Sách Hóa Đơn
            var bills = new List<Bill>
            {
                new Bill{BillId = "hd0001", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0001", CustomerId = "kh0001", Date = DateTime.Now.Date.AddDays(-10), Products = billProduct1, Discounts = billDiscount1},
                new Bill{BillId = "hd0002", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0002", CustomerId = "kh0002", Date = DateTime.Now.Date.AddDays(-11), Products = billProduct2, Discounts = billDiscount2},
                new Bill{BillId = "hd0003", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 25, Total = 42,ComputerId = "mt0003", CustomerId = "kh0003", Date = DateTime.Now.Date.AddDays(-12), Products = billProduct3, Discounts = billDiscount3},
                new Bill{BillId = "hd0004", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0004", CustomerId = "kh0004", Date = DateTime.Now.Date.AddDays(-13), Products = billProduct4, Discounts = billDiscount4},
                new Bill{BillId = "hd0005", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 63,ComputerId = "mt0005", CustomerId = "kh0005", Date = DateTime.Now.Date.AddDays(-14), Products = billProduct5, Discounts = billDiscount5},
                new Bill{BillId = "hd0006", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0006", CustomerId = "kh0006", Date = DateTime.Now.Date.AddDays(-15), Products = billProduct6, Discounts = billDiscount6},
                new Bill{BillId = "hd0007", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 77,ComputerId = "mt0007", CustomerId = "kh0007", Date = DateTime.Now.Date.AddDays(-16), Products = billProduct7, Discounts = billDiscount7},
                new Bill{BillId = "hd0008", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0008", CustomerId = "kh0008", Date = DateTime.Now.Date.AddDays(-17), Products = billProduct8, Discounts = billDiscount8},
                new Bill{BillId = "hd0009", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0009", CustomerId = "kh0009", Date = DateTime.Now.Date.AddDays(-18), Products = billProduct9, Discounts = billDiscount9},
                new Bill{BillId = "hd0010", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0010", CustomerId = "kh0010", Date = DateTime.Now.Date.AddDays(-19), Products = billProduct10, Discounts = billDiscount10},
                new Bill{BillId = "hd0011", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0011", CustomerId = "kh0011", Date = DateTime.Now.Date.AddDays(-20), Products = billProduct11, Discounts = billDiscount11},
                new Bill{BillId = "hd0012", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0012", CustomerId = "kh0012", Date = DateTime.Now.Date.AddDays(-21), Products = billProduct12, Discounts = billDiscount12},
                new Bill{BillId = "hd0013", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0013", CustomerId = "kh0013", Date = DateTime.Now.Date.AddDays(-22), Products = billProduct13, Discounts = billDiscount13},
                new Bill{BillId = "hd0014", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0014", CustomerId = "kh0014", Date = DateTime.Now.Date.AddDays(-23), Products = billProduct14, Discounts = billDiscount14},
                new Bill{BillId = "hd0015", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0015", CustomerId = "kh0015", Date = DateTime.Now.Date.AddDays(-24), Products = billProduct15, Discounts = billDiscount15},
                new Bill{BillId = "hd0016", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0001", CustomerId = "kh0016", Date = DateTime.Now.Date.AddDays(-25), Products = billProduct16, Discounts = billDiscount16},
                new Bill{BillId = "hd0017", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0002", CustomerId = "kh0017", Date = DateTime.Now.Date.AddDays(-26), Products = billProduct17, Discounts = billDiscount17},
                new Bill{BillId = "hd0018", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 15, Total = 47,ComputerId = "mt0003", CustomerId = "kh0018", Date = DateTime.Now.Date.AddDays(-27), Products = billProduct18, Discounts = billDiscount18},
                new Bill{BillId = "hd0019", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0004", CustomerId = "kh0019", Date = DateTime.Now.Date.AddDays(-28), Products = billProduct19, Discounts = billDiscount19},
                new Bill{BillId = "hd0020", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 60,ComputerId = "mt0005", CustomerId = "kh0020", Date = DateTime.Now.Date.AddDays(-29), Products = billProduct20, Discounts = billDiscount20},
                new Bill{BillId = "hd0021", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0006", CustomerId = "kh0021", Date = DateTime.Now.Date.AddDays(-30), Products = billProduct21, Discounts = billDiscount21},
                new Bill{BillId = "hd0022", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 81,ComputerId = "mt0007", CustomerId = "kh0022", Date = DateTime.Now.Date.AddDays(-31), Products = billProduct22, Discounts = billDiscount22},
                new Bill{BillId = "hd0023", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0008", CustomerId = "kh0023", Date = DateTime.Now.Date.AddDays(-32), Products = billProduct23, Discounts = billDiscount23},
                new Bill{BillId = "hd0024", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 64,ComputerId = "mt0009", CustomerId = "kh0024", Date = DateTime.Now.Date.AddDays(-33), Products = billProduct24, Discounts = billDiscount24},
                new Bill{BillId = "hd0025", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0010", CustomerId = "kh0025", Date = DateTime.Now.Date.AddDays(-34), Products = billProduct25, Discounts = billDiscount25},
                new Bill{BillId = "hd0026", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 54,ComputerId = "mt0011", CustomerId = "kh0026", Date = DateTime.Now.Date.AddDays(-35), Products = billProduct26, Discounts = billDiscount26},
                new Bill{BillId = "hd0027", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0012", CustomerId = "kh0027", Date = DateTime.Now.Date.AddDays(-36), Products = billProduct27, Discounts = billDiscount27},
                new Bill{BillId = "hd0028", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 25, Total = 45,ComputerId = "mt0013", CustomerId = "kh0028", Date = DateTime.Now.Date.AddDays(-37), Products = billProduct28, Discounts = billDiscount28},
                new Bill{BillId = "hd0029", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0014", CustomerId = "kh0029", Date = DateTime.Now.Date.AddDays(-38), Products = billProduct29, Discounts = billDiscount29},
                new Bill{BillId = "hd0030", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0015", CustomerId = "kh0030", Date = DateTime.Now.Date.AddDays(-39), Products = billProduct30, Discounts = billDiscount30},
                new Bill{BillId = "hd0031", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0030", CustomerId = "kh0031", Date = DateTime.Now.Date.AddDays(-40), Products = billProduct31, Discounts = billDiscount31},
                new Bill{BillId = "hd0032", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0029", CustomerId = "kh0032", Date = DateTime.Now.Date.AddDays(-41), Products = billProduct32, Discounts = billDiscount32},
                new Bill{BillId = "hd0033", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 25, Total = 42,ComputerId = "mt0028", CustomerId = "kh0033", Date = DateTime.Now.Date.AddDays(-42), Products = billProduct33, Discounts = billDiscount33},
                new Bill{BillId = "hd0034", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0027", CustomerId = "kh0034", Date = DateTime.Now.Date.AddDays(-43), Products = billProduct34, Discounts = billDiscount34},
                new Bill{BillId = "hd0035", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 63,ComputerId = "mt0026", CustomerId = "kh0035", Date = DateTime.Now.Date.AddDays(-44), Products = billProduct35, Discounts = billDiscount35},
                new Bill{BillId = "hd0036", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0025", CustomerId = "kh0036", Date = DateTime.Now.Date.AddDays(-45), Products = billProduct36, Discounts = billDiscount36},
                new Bill{BillId = "hd0037", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 77,ComputerId = "mt0024", CustomerId = "kh0037", Date = DateTime.Now.Date.AddDays(-46), Products = billProduct37, Discounts = billDiscount37},
                new Bill{BillId = "hd0038", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0023", CustomerId = "kh0038", Date = DateTime.Now.Date.AddDays(-47), Products = billProduct38, Discounts = billDiscount38},
                new Bill{BillId = "hd0039", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0022", CustomerId = "kh0039", Date = DateTime.Now.Date.AddDays(-48), Products = billProduct39, Discounts = billDiscount39},
                new Bill{BillId = "hd0040", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0021", CustomerId = "kh0040", Date = DateTime.Now.Date.AddDays(-49), Products = billProduct40, Discounts = billDiscount40},
                new Bill{BillId = "hd0041", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0020", CustomerId = "kh0041", Date = DateTime.Now.Date.AddDays(-50), Products = billProduct41, Discounts = billDiscount41},
                new Bill{BillId = "hd0042", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0019", CustomerId = "kh0042", Date = DateTime.Now.Date.AddDays(-51), Products = billProduct42, Discounts = billDiscount42},
                new Bill{BillId = "hd0043", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0018", CustomerId = "kh0043", Date = DateTime.Now.Date.AddDays(-52), Products = billProduct43, Discounts = billDiscount43},
                new Bill{BillId = "hd0044", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0017", CustomerId = "kh0044", Date = DateTime.Now.Date.AddDays(-53), Products = billProduct44, Discounts = billDiscount44},
                new Bill{BillId = "hd0045", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0016", CustomerId = "kh0045", Date = DateTime.Now.Date.AddDays(-54), Products = billProduct45, Discounts = billDiscount45},
                new Bill{BillId = "hd0046", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0016", CustomerId = "kh0046", Date = DateTime.Now.Date.AddDays(-55), Products = billProduct46, Discounts = billDiscount46},
                new Bill{BillId = "hd0047", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0017", CustomerId = "kh0047", Date = DateTime.Now.Date.AddDays(-56), Products = billProduct47, Discounts = billDiscount47},
                new Bill{BillId = "hd0048", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 15, Total = 47,ComputerId = "mt0018", CustomerId = "kh0048", Date = DateTime.Now.Date.AddDays(-57), Products = billProduct48, Discounts = billDiscount48},
                new Bill{BillId = "hd0049", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0019", CustomerId = "kh0049", Date = DateTime.Now.Date.AddDays(-58), Products = billProduct49, Discounts = billDiscount49},
                new Bill{BillId = "hd0050", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 60,ComputerId = "mt0020", CustomerId = "kh0050", Date = DateTime.Now.Date.AddDays(-59), Products = billProduct50, Discounts = billDiscount50},
                new Bill{BillId = "hd0051", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0021", CustomerId = "kh0051", Date = DateTime.Now.Date.AddDays(-60), Products = billProduct51, Discounts = billDiscount51},
                new Bill{BillId = "hd0052", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 81,ComputerId = "mt0022", CustomerId = "kh0052", Date = DateTime.Now.Date.AddDays(-61), Products = billProduct52, Discounts = billDiscount52},
                new Bill{BillId = "hd0053", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0023", CustomerId = "kh0053", Date = DateTime.Now.Date.AddDays(-62), Products = billProduct53, Discounts = billDiscount53},
                new Bill{BillId = "hd0054", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 64,ComputerId = "mt0024", CustomerId = "kh0054", Date = DateTime.Now.Date.AddDays(-63), Products = billProduct54, Discounts = billDiscount54},
                new Bill{BillId = "hd0055", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0025", CustomerId = "kh0055", Date = DateTime.Now.Date.AddDays(-64), Products = billProduct55, Discounts = billDiscount55},
                new Bill{BillId = "hd0056", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 54,ComputerId = "mt0026", CustomerId = "kh0056", Date = DateTime.Now.Date.AddDays(-65), Products = billProduct56, Discounts = billDiscount56},
                new Bill{BillId = "hd0057", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0027", CustomerId = "kh0057", Date = DateTime.Now.Date.AddDays(-66), Products = billProduct57, Discounts = billDiscount57},
                new Bill{BillId = "hd0058", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 25, Total = 45,ComputerId = "mt0028", CustomerId = "kh0058", Date = DateTime.Now.Date.AddDays(-67), Products = billProduct58, Discounts = billDiscount58},
                new Bill{BillId = "hd0059", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0029", CustomerId = "kh0059", Date = DateTime.Now.Date.AddDays(-68), Products = billProduct59, Discounts = billDiscount59},
                new Bill{BillId = "hd0060", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0030", CustomerId = "kh0060", Date = DateTime.Now.Date.AddDays(-69), Products = billProduct60, Discounts = billDiscount60},
                new Bill{BillId = "hd0061", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0001", CustomerId = "kh0061", Date = DateTime.Now.Date.AddDays(-10), Products = billProduct61, Discounts = billDiscount61},
                new Bill{BillId = "hd0062", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0002", CustomerId = "kh0062", Date = DateTime.Now.Date.AddDays(-11), Products = billProduct62, Discounts = billDiscount62},
                new Bill{BillId = "hd0063", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 25, Total = 42,ComputerId = "mt0003", CustomerId = "kh0063", Date = DateTime.Now.Date.AddDays(-12), Products = billProduct63, Discounts = billDiscount63},
                new Bill{BillId = "hd0064", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0004", CustomerId = "kh0064", Date = DateTime.Now.Date.AddDays(-13), Products = billProduct64, Discounts = billDiscount64},
                new Bill{BillId = "hd0065", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 63,ComputerId = "mt0005", CustomerId = "kh0065", Date = DateTime.Now.Date.AddDays(-14), Products = billProduct65, Discounts = billDiscount65},
                new Bill{BillId = "hd0066", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0006", CustomerId = "kh0066", Date = DateTime.Now.Date.AddDays(-15), Products = billProduct66, Discounts = billDiscount66},
                new Bill{BillId = "hd0067", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 77,ComputerId = "mt0007", CustomerId = "kh0067", Date = DateTime.Now.Date.AddDays(-16), Products = billProduct67, Discounts = billDiscount67},
                new Bill{BillId = "hd0068", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0008", CustomerId = "kh0068", Date = DateTime.Now.Date.AddDays(-17), Products = billProduct68, Discounts = billDiscount68},
                new Bill{BillId = "hd0069", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0009", CustomerId = "kh0069", Date = DateTime.Now.Date.AddDays(-18), Products = billProduct69, Discounts = billDiscount69},
                new Bill{BillId = "hd0070", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0010", CustomerId = "kh0070", Date = DateTime.Now.Date.AddDays(-19), Products = billProduct70, Discounts = billDiscount70},
                new Bill{BillId = "hd0071", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0011", CustomerId = "kh0071", Date = DateTime.Now.Date.AddDays(-20), Products = billProduct71, Discounts = billDiscount71},
                new Bill{BillId = "hd0072", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0012", CustomerId = "kh0072", Date = DateTime.Now.Date.AddDays(-21), Products = billProduct72, Discounts = billDiscount72},
                new Bill{BillId = "hd0073", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0013", CustomerId = "kh0073", Date = DateTime.Now.Date.AddDays(-22), Products = billProduct73, Discounts = billDiscount73},
                new Bill{BillId = "hd0074", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0014", CustomerId = "kh0074", Date = DateTime.Now.Date.AddDays(-23), Products = billProduct74, Discounts = billDiscount74},
                new Bill{BillId = "hd0075", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0015", CustomerId = "kh0075", Date = DateTime.Now.Date.AddDays(-24), Products = billProduct75, Discounts = billDiscount75},
                new Bill{BillId = "hd0076", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0030", CustomerId = "kh0076", Date = DateTime.Now.Date.AddDays(-25), Products = billProduct76, Discounts = billDiscount76},
                new Bill{BillId = "hd0077", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0029", CustomerId = "kh0077", Date = DateTime.Now.Date.AddDays(-26), Products = billProduct77, Discounts = billDiscount77},
                new Bill{BillId = "hd0078", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 15, Total = 47,ComputerId = "mt0028", CustomerId = "kh0078", Date = DateTime.Now.Date.AddDays(-27), Products = billProduct78, Discounts = billDiscount78},
                new Bill{BillId = "hd0079", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0027", CustomerId = "kh0079", Date = DateTime.Now.Date.AddDays(-28), Products = billProduct79, Discounts = billDiscount79},
                new Bill{BillId = "hd0080", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 60,ComputerId = "mt0026", CustomerId = "kh0080", Date = DateTime.Now.Date.AddDays(-29), Products = billProduct80, Discounts = billDiscount80},
                new Bill{BillId = "hd0081", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0025", CustomerId = "kh0081", Date = DateTime.Now.Date.AddDays(-30), Products = billProduct81, Discounts = billDiscount81},
                new Bill{BillId = "hd0082", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 81,ComputerId = "mt0024", CustomerId = "kh0082", Date = DateTime.Now.Date.AddDays(-31), Products = billProduct82, Discounts = billDiscount82},
                new Bill{BillId = "hd0083", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0023", CustomerId = "kh0083", Date = DateTime.Now.Date.AddDays(-32), Products = billProduct83, Discounts = billDiscount83},
                new Bill{BillId = "hd0084", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 64,ComputerId = "mt0022", CustomerId = "kh0084", Date = DateTime.Now.Date.AddDays(-33), Products = billProduct84, Discounts = billDiscount84},
                new Bill{BillId = "hd0085", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0021", CustomerId = "kh0085", Date = DateTime.Now.Date.AddDays(-34), Products = billProduct85, Discounts = billDiscount85},
                new Bill{BillId = "hd0086", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 54,ComputerId = "mt0020", CustomerId = "kh0086", Date = DateTime.Now.Date.AddDays(-35), Products = billProduct86, Discounts = billDiscount86},
                new Bill{BillId = "hd0087", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0019", CustomerId = "kh0087", Date = DateTime.Now.Date.AddDays(-36), Products = billProduct87, Discounts = billDiscount87},
                new Bill{BillId = "hd0088", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 25, Total = 45,ComputerId = "mt0018", CustomerId = "kh0088", Date = DateTime.Now.Date.AddDays(-37), Products = billProduct88, Discounts = billDiscount88},
                new Bill{BillId = "hd0089", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0017", CustomerId = "kh0089", Date = DateTime.Now.Date.AddDays(-38), Products = billProduct89, Discounts = billDiscount89},
                new Bill{BillId = "hd0090", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0016", CustomerId = "kh0090", Date = DateTime.Now.Date.AddDays(-39), Products = billProduct90, Discounts = billDiscount90},
                new Bill{BillId = "hd0091", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0016", CustomerId = "kh0091", Date = DateTime.Now.Date.AddDays(-40), Products = billProduct91, Discounts = billDiscount91},
                new Bill{BillId = "hd0092", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0017", CustomerId = "kh0092", Date = DateTime.Now.Date.AddDays(-41), Products = billProduct92, Discounts = billDiscount92},
                new Bill{BillId = "hd0093", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 15, Total = 47,ComputerId = "mt0018", CustomerId = "kh0093", Date = DateTime.Now.Date.AddDays(-42), Products = billProduct93, Discounts = billDiscount93},
                new Bill{BillId = "hd0094", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0019", CustomerId = "kh0094", Date = DateTime.Now.Date.AddDays(-43), Products = billProduct94, Discounts = billDiscount94},
                new Bill{BillId = "hd0095", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 60,ComputerId = "mt0020", CustomerId = "kh0095", Date = DateTime.Now.Date.AddDays(-44), Products = billProduct95, Discounts = billDiscount95},
                new Bill{BillId = "hd0096", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0021", CustomerId = "kh0096", Date = DateTime.Now.Date.AddDays(-45), Products = billProduct96, Discounts = billDiscount96},
                new Bill{BillId = "hd0097", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 81,ComputerId = "mt0022", CustomerId = "kh0097", Date = DateTime.Now.Date.AddDays(-46), Products = billProduct97, Discounts = billDiscount97},
                new Bill{BillId = "hd0098", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0023", CustomerId = "kh0098", Date = DateTime.Now.Date.AddDays(-47), Products = billProduct98, Discounts = billDiscount98},
                new Bill{BillId = "hd0099", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 64,ComputerId = "mt0024", CustomerId = "kh0099", Date = DateTime.Now.Date.AddDays(-48), Products = billProduct99, Discounts = billDiscount99},
                new Bill{BillId = "hd0100", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0025", CustomerId = "kh0100", Date = DateTime.Now.Date.AddDays(-49), Products = billProduct100, Discounts = billDiscount100},
                new Bill{BillId = "hd0101", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 54,ComputerId = "mt0026", CustomerId = "kh0101", Date = DateTime.Now.Date.AddDays(-50), Products = billProduct101, Discounts = billDiscount101},
                new Bill{BillId = "hd0102", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0027", CustomerId = "kh0102", Date = DateTime.Now.Date.AddDays(-51), Products = billProduct102, Discounts = billDiscount102},
                new Bill{BillId = "hd0103", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 25, Total = 45,ComputerId = "mt0028", CustomerId = "kh0103", Date = DateTime.Now.Date.AddDays(-52), Products = billProduct103, Discounts = billDiscount103},
                new Bill{BillId = "hd0104", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0029", CustomerId = "kh0104", Date = DateTime.Now.Date.AddDays(-53), Products = billProduct104, Discounts = billDiscount104},
                new Bill{BillId = "hd0105", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0030", CustomerId = "kh0105", Date = DateTime.Now.Date.AddDays(-54), Products = billProduct105, Discounts = billDiscount105},
                new Bill{BillId = "hd0106", EmployeeId = "nv0004", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 72,ComputerId = "mt0030", CustomerId = "kh0106", Date = DateTime.Now.Date.AddDays(-55), Products = billProduct106, Discounts = billDiscount106},
                new Bill{BillId = "hd0107", EmployeeId = "nv0005", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0029", CustomerId = "kh0107", Date = DateTime.Now.Date.AddDays(-56), Products = billProduct107, Discounts = billDiscount107},
                new Bill{BillId = "hd0108", EmployeeId = "nv0006", Status = "Chờ Chấp Nhận", TotalDiscountPercent = 25, Total = 42,ComputerId = "mt0028", CustomerId = "kh0108", Date = DateTime.Now.Date.AddDays(-57), Products = billProduct108, Discounts = billDiscount108},
                new Bill{BillId = "hd0109", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 75,ComputerId = "mt0027", CustomerId = "kh0109", Date = DateTime.Now.Date.AddDays(-58), Products = billProduct109, Discounts = billDiscount109},
                new Bill{BillId = "hd0110", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 63,ComputerId = "mt0026", CustomerId = "kh0110", Date = DateTime.Now.Date.AddDays(-59), Products = billProduct110, Discounts = billDiscount110},
                new Bill{BillId = "hd0111", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0025", CustomerId = "kh0111", Date = DateTime.Now.Date.AddDays(-60), Products = billProduct111, Discounts = billDiscount111},
                new Bill{BillId = "hd0112", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 77,ComputerId = "mt0024", CustomerId = "kh0112", Date = DateTime.Now.Date.AddDays(-61), Products = billProduct112, Discounts = billDiscount112},
                new Bill{BillId = "hd0113", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 90,ComputerId = "mt0023", CustomerId = "kh0113", Date = DateTime.Now.Date.AddDays(-62), Products = billProduct113, Discounts = billDiscount113},
                new Bill{BillId = "hd0114", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 68,ComputerId = "mt0022", CustomerId = "kh0114", Date = DateTime.Now.Date.AddDays(-63), Products = billProduct114, Discounts = billDiscount114},
                new Bill{BillId = "hd0115", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0021", CustomerId = "kh0115", Date = DateTime.Now.Date.AddDays(-64), Products = billProduct115, Discounts = billDiscount115},
                new Bill{BillId = "hd0116", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0020", CustomerId = "kh0116", Date = DateTime.Now.Date.AddDays(-65), Products = billProduct116, Discounts = billDiscount116},
                new Bill{BillId = "hd0117", EmployeeId = "nv0007", Status = "Chấp Nhận", TotalDiscountPercent = 0, Total = 110,ComputerId = "mt0019", CustomerId = "kh0117", Date = DateTime.Now.Date.AddDays(-66), Products = billProduct117, Discounts = billDiscount117},
                new Bill{BillId = "hd0118", EmployeeId = "nv0004", Status = "Chấp Nhận", TotalDiscountPercent = 15, Total = 51,ComputerId = "mt0018", CustomerId = "kh0118", Date = DateTime.Now.Date.AddDays(-67), Products = billProduct118, Discounts = billDiscount118},
                new Bill{BillId = "hd0119", EmployeeId = "nv0005", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 59,ComputerId = "mt0017", CustomerId = "kh0119", Date = DateTime.Now.Date.AddDays(-68), Products = billProduct119, Discounts = billDiscount119},
                new Bill{BillId = "hd0120", EmployeeId = "nv0006", Status = "Chấp Nhận", TotalDiscountPercent = 10, Total = 50,ComputerId = "mt0016", CustomerId = "kh0120", Date = DateTime.Now.Date.AddDays(-69), Products = billProduct120, Discounts = billDiscount120}
            };
            #endregion
            bills.ForEach(p => context.Bills.AddOrUpdate(
                bill => bill.BillId,
                new Bill
                {
                    BillId = p.BillId,
                    ComputerId = p.ComputerId,
                    CustomerId = p.CustomerId,
                    Status = p.Status,
                    Date = p.Date,
                    IPClient = p.IPClient,
                    Total = p.Total,
                    TotalDiscountPercent = p.TotalDiscountPercent,
                    EmployeeId = p.EmployeeId,
                    Discounts = p.Discounts,
                    Products = p.Products,
                }));
            context.SaveChanges();
        }
        private void CreateBillDiscounts(DAL.QLNETDBContext context, List<List<BillDiscount>> ListAllBillDiscount)
        {
            foreach (List<BillDiscount> listBillDiscount in ListAllBillDiscount)
            {
                foreach (BillDiscount discount in listBillDiscount)
                {
                    context.BillDiscounts.AddOrUpdate(discount);
                }
            }
        }
        private void CreateBillProducts(DAL.QLNETDBContext context, List<List<BillProduct>> ListAllBillProduct)
        {
            foreach (List<BillProduct> listBillProduct in ListAllBillProduct)
            {
                foreach (BillProduct product in listBillProduct)
                {
                    context.BillProducts.AddOrUpdate(product);
                }
            }
        }
        private void CreateBillDays(DAL.QLNETDBContext context)
        {
            var billDays = new List<BillDay>
            {
                new BillDay{BillDayId = "hdd0001", Date = DateTime.Now.Date.AddDays(-13), TotalBill = 150, Type = true},
                new BillDay{BillDayId = "hdd0002", Date = DateTime.Now.Date.AddDays(-14), TotalBill = 126, Type = true},
                new BillDay{BillDayId = "hdd0003", Date = DateTime.Now.Date.AddDays(-15), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0004", Date = DateTime.Now.Date.AddDays(-16), TotalBill = 154, Type = true},
                new BillDay{BillDayId = "hdd0005", Date = DateTime.Now.Date.AddDays(-17), TotalBill = 180, Type = true},
                new BillDay{BillDayId = "hdd0006", Date = DateTime.Now.Date.AddDays(-18), TotalBill = 136, Type = true},
                new BillDay{BillDayId = "hdd0007", Date = DateTime.Now.Date.AddDays(-19), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0008", Date = DateTime.Now.Date.AddDays(-20), TotalBill = 102, Type = true},
                new BillDay{BillDayId = "hdd0009", Date = DateTime.Now.Date.AddDays(-21), TotalBill = 220, Type = true},
                new BillDay{BillDayId = "hdd0010", Date = DateTime.Now.Date.AddDays(-22), TotalBill = 102, Type = true},
                new BillDay{BillDayId = "hdd0011", Date = DateTime.Now.Date.AddDays(-23), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0012", Date = DateTime.Now.Date.AddDays(-24), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0013", Date = DateTime.Now.Date.AddDays(-28), TotalBill = 150, Type = true},
                new BillDay{BillDayId = "hdd0014", Date = DateTime.Now.Date.AddDays(-29), TotalBill = 120, Type = true},
                new BillDay{BillDayId = "hdd0015", Date = DateTime.Now.Date.AddDays(-30), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0016", Date = DateTime.Now.Date.AddDays(-31), TotalBill = 162, Type = true},
                new BillDay{BillDayId = "hdd0017", Date = DateTime.Now.Date.AddDays(-32), TotalBill = 180, Type = true},
                new BillDay{BillDayId = "hdd0018", Date = DateTime.Now.Date.AddDays(-33), TotalBill = 128, Type = true},
                new BillDay{BillDayId = "hdd0019", Date = DateTime.Now.Date.AddDays(-34), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0020", Date = DateTime.Now.Date.AddDays(-35), TotalBill = 108, Type = true},
                new BillDay{BillDayId = "hdd0021", Date = DateTime.Now.Date.AddDays(-36), TotalBill = 220, Type = true},
                new BillDay{BillDayId = "hdd0022", Date = DateTime.Now.Date.AddDays(-37), TotalBill = 90, Type = true},
                new BillDay{BillDayId = "hdd0023", Date = DateTime.Now.Date.AddDays(-38), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0024", Date = DateTime.Now.Date.AddDays(-39), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0025", Date = DateTime.Now.Date.AddDays(-43), TotalBill = 150, Type = true},
                new BillDay{BillDayId = "hdd0026", Date = DateTime.Now.Date.AddDays(-44), TotalBill = 123, Type = true},
                new BillDay{BillDayId = "hdd0027", Date = DateTime.Now.Date.AddDays(-45), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0028", Date = DateTime.Now.Date.AddDays(-46), TotalBill = 158, Type = true},
                new BillDay{BillDayId = "hdd0029", Date = DateTime.Now.Date.AddDays(-47), TotalBill = 180, Type = true},
                new BillDay{BillDayId = "hdd0030", Date = DateTime.Now.Date.AddDays(-48), TotalBill = 132, Type = true},
                new BillDay{BillDayId = "hdd0031", Date = DateTime.Now.Date.AddDays(-49), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0032", Date = DateTime.Now.Date.AddDays(-50), TotalBill = 105, Type = true},
                new BillDay{BillDayId = "hdd0033", Date = DateTime.Now.Date.AddDays(-51), TotalBill = 220, Type = true},
                new BillDay{BillDayId = "hdd0034", Date = DateTime.Now.Date.AddDays(-52), TotalBill = 96, Type = true},
                new BillDay{BillDayId = "hdd0035", Date = DateTime.Now.Date.AddDays(-54), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0036", Date = DateTime.Now.Date.AddDays(-58), TotalBill = 150, Type = true},
                new BillDay{BillDayId = "hdd0037", Date = DateTime.Now.Date.AddDays(-59), TotalBill = 123, Type = true},
                new BillDay{BillDayId = "hdd0038", Date = DateTime.Now.Date.AddDays(-60), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0039", Date = DateTime.Now.Date.AddDays(-61), TotalBill = 158, Type = true},
                new BillDay{BillDayId = "hdd0040", Date = DateTime.Now.Date.AddDays(-62), TotalBill = 180, Type = true},
                new BillDay{BillDayId = "hdd0041", Date = DateTime.Now.Date.AddDays(-63), TotalBill = 132, Type = true},
                new BillDay{BillDayId = "hdd0042", Date = DateTime.Now.Date.AddDays(-64), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0043", Date = DateTime.Now.Date.AddDays(-65), TotalBill = 105, Type = true},
                new BillDay{BillDayId = "hdd0044", Date = DateTime.Now.Date.AddDays(-66), TotalBill = 220, Type = true},
                new BillDay{BillDayId = "hdd0045", Date = DateTime.Now.Date.AddDays(-67), TotalBill = 96, Type = true},
                new BillDay{BillDayId = "hdd0046", Date = DateTime.Now.Date.AddDays(-68), TotalBill = 118, Type = true},
                new BillDay{BillDayId = "hdd0047", Date = DateTime.Now.Date.AddDays(-69), TotalBill = 100, Type = true},
                new BillDay{BillDayId = "hdd0048", Date = DateTime.Now.Date.AddDays(-15), TotalBill = 990, Type = false},
                new BillDay{BillDayId = "hdd0049", Date = DateTime.Now.Date.AddDays(-25), TotalBill = 1135, Type = false},
                new BillDay{BillDayId = "hdd0050", Date = DateTime.Now.Date.AddDays(-35), TotalBill = 941, Type = false},
                new BillDay{BillDayId = "hdd0051", Date = DateTime.Now.Date.AddDays(-45), TotalBill = 995, Type = false},
                new BillDay{BillDayId = "hdd0052", Date = DateTime.Now.Date.AddDays(-55), TotalBill = 1100, Type = false},
            };
            billDays.ForEach(p => context.BillDays.AddOrUpdate(
                billDay => billDay.BillDayId,
                new BillDay
                {
                    BillDayId = p.BillDayId,
                    TotalBill = p.TotalBill,
                    Date = p.Date,
                    Type = p.Type,
                }));
            context.SaveChanges();
        }
        private void CreateReciepts(DAL.QLNETDBContext context)
        {
            #region Danh Sách Hóa Đơn Nhập
            List<List<RecieptProduct>> ListAllRecieptProduct = new List<List<RecieptProduct>>();
            //990
            var recieptProduct1 = new List<RecieptProduct>
            {
                new RecieptProduct{ProductId = "sp0001", RecieptId = "hdn0001", Quantity = 15},
                new RecieptProduct{ProductId = "sp0005", RecieptId = "hdn0001", Quantity = 20},
                new RecieptProduct{ProductId = "sp0008", RecieptId = "hdn0001", Quantity = 30},
                new RecieptProduct{ProductId = "sp0007", RecieptId = "hdn0001", Quantity = 20},
                new RecieptProduct{ProductId = "sp0011", RecieptId = "hdn0001", Quantity = 10}
            };
            ListAllRecieptProduct.Add(recieptProduct1);
            //1135
            var recieptProduct2 = new List<RecieptProduct>
            {
                new RecieptProduct{ProductId = "sp0009", RecieptId = "hdn0002", Quantity = 15},
                new RecieptProduct{ProductId = "sp0006", RecieptId = "hdn0002", Quantity = 20},
                new RecieptProduct{ProductId = "sp0004", RecieptId = "hdn0002", Quantity = 15},
                new RecieptProduct{ProductId = "sp0002", RecieptId = "hdn0002", Quantity = 15},
                new RecieptProduct{ProductId = "sp0010", RecieptId = "hdn0002", Quantity = 15}
            };
            ListAllRecieptProduct.Add(recieptProduct2);
            //990
            var recieptProduct3 = new List<RecieptProduct>
            {
                new RecieptProduct{ProductId = "sp0001", RecieptId = "hdn0003", Quantity = 15},
                new RecieptProduct{ProductId = "sp0005", RecieptId = "hdn0003", Quantity = 20},
                new RecieptProduct{ProductId = "sp0008", RecieptId = "hdn0003", Quantity = 30},
                new RecieptProduct{ProductId = "sp0007", RecieptId = "hdn0003", Quantity = 20},
                new RecieptProduct{ProductId = "sp0011", RecieptId = "hdn0003", Quantity = 10}
            };
            ListAllRecieptProduct.Add(recieptProduct3);
            //995
            var recieptProduct4 = new List<RecieptProduct>
            {
                new RecieptProduct{ProductId = "sp0003", RecieptId = "hdn0004", Quantity = 15},
                new RecieptProduct{ProductId = "sp0002", RecieptId = "hdn0004", Quantity = 10},
                new RecieptProduct{ProductId = "sp0004", RecieptId = "hdn0004", Quantity = 30},
                new RecieptProduct{ProductId = "sp0007", RecieptId = "hdn0004", Quantity = 15},
                new RecieptProduct{ProductId = "sp0011", RecieptId = "hdn0004", Quantity = 10}
            };
            ListAllRecieptProduct.Add(recieptProduct4);
            //1110
            var recieptProduct5 = new List<RecieptProduct>
            {
                new RecieptProduct{ProductId = "sp0002", RecieptId = "hdn0005", Quantity = 15},
                new RecieptProduct{ProductId = "sp0005", RecieptId = "hdn0005", Quantity = 20},
                new RecieptProduct{ProductId = "sp0006", RecieptId = "hdn0005", Quantity = 25},
                new RecieptProduct{ProductId = "sp0009", RecieptId = "hdn0005", Quantity = 20},
                new RecieptProduct{ProductId = "sp0010", RecieptId = "hdn0005", Quantity = 15}
            };
            ListAllRecieptProduct.Add(recieptProduct5);
            var reciepts = new List<Reciept>
            {
                new Reciept{RecieptId = "hdn0001", EmployeeId = "nv0004", Date = DateTime.Now.Date.AddDays(-15), Manufacturer = "Công Ty QuyXuan", Discount = 0, TotalBill = 990, Products = recieptProduct1},
                new Reciept{RecieptId = "hdn0002", EmployeeId = "nv0005", Date = DateTime.Now.Date.AddDays(-25), Manufacturer = "Công Ty IdolMXT", Discount = 0, TotalBill = 1135, Products = recieptProduct2},
                new Reciept{RecieptId = "hdn0003", EmployeeId = "nv0006", Date = DateTime.Now.Date.AddDays(-35), Manufacturer = "Công Ty Sown", Discount = 5, TotalBill = 941, Products = recieptProduct3},
                new Reciept{RecieptId = "hdn0004", EmployeeId = "nv0007", Date = DateTime.Now.Date.AddDays(-45), Manufacturer = "Công Ty QuyXuan", Discount = 0, TotalBill = 995, Products = recieptProduct4},
                new Reciept{RecieptId = "hdn0005", EmployeeId = "nv0004", Date = DateTime.Now.Date.AddDays(-55), Manufacturer = "Công Ty IdolMXT", Discount = 0, TotalBill = 1110, Products = recieptProduct5},
            };
            #endregion
            CreateRecieptProducts(context, ListAllRecieptProduct);
            reciepts.ForEach(p => context.Reciepts.AddOrUpdate(
                reciept => reciept.RecieptId,
                new Reciept
                {
                    RecieptId = p.RecieptId,
                    EmployeeId = p.EmployeeId,
                    Date = p.Date,
                    Manufacturer = p.Manufacturer,
                    Discount = p.Discount,
                    TotalBill = p.TotalBill,
                    Products = p.Products
                }));
            context.SaveChanges();
        }
        private void CreateRecieptProducts(DAL.QLNETDBContext context, List<List<RecieptProduct>> ListAllRecieptProduct)
        {
            foreach (List<RecieptProduct> listRecieptProduct in ListAllRecieptProduct)
            {
                foreach (RecieptProduct product in listRecieptProduct)
                {
                    context.RecieptProducts.AddOrUpdate(product);
                }
            }
        }
    }
}