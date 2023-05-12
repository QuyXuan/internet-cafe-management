using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class Configuration : DbMigrationsConfiguration<QLNETDBContext>
    {
        public Configuration()
        {
            //set để khi nào có sự thay đổi thì nó sẽ tự rend code cho mình
            //thay vì phải code từng cái
            AutomaticMigrationsEnabled = true;
        }
        //sử dụng lệnh sẽ đi kèm với
        //-ConfigurationTypeName DAL.Migrations.Configuration ở phía sau
        protected override void Seed(QLNETDBContext context)
        {
        }
    }
    //chiến lược khởi tạo thứ 4, tự custom chiến lược khởi tạo, nếu đã có database thì sẽ thực hiện chỉnh
    //sửa thay vì xóa đi rồi tạo lại
    public class MyDbInitializer : MigrateDatabaseToLatestVersion<QLNETDBContext, Configuration>
    {
        public override void InitializeDatabase(QLNETDBContext context)
        {
            //base.InitializeDatabase(context);
        }
    }
    public class QLNETDBContext : DbContext
    {
        public QLNETDBContext() : base("ConnectionString")
        {
            //tắt lazyloading để dữ liệu luôn được tạo sẵn khi chạy chương trình chứ
            //không phải khi nào gọi tới thì mới chạy
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MyDbInitializer());
        }
        //tạo dbset các đối tượng
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reciept> Reciepts { get; set; }
        public DbSet<BillDay> BillDays { get; set; }
        public DbSet<TypeComputer> TypeComputers { get; set; }
        public DbSet<BillProduct> BillProducts { get; set; }
        public DbSet<RecieptProduct> RecieptProducts { get; set; }
        public DbSet<BillDiscount> BillDiscounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BillDiscount>().HasKey(p => new
            {
                p.DiscountId,
                p.BillId
            });
            modelBuilder.Entity<BillDiscount>()
                .HasRequired(p => p.Discount)
                .WithMany(p => p.Bills)
                .HasForeignKey(p => p.DiscountId);
            modelBuilder.Entity<BillDiscount>()
                .HasRequired(p => p.Bill)
                .WithMany(p => p.Discounts)
                .HasForeignKey(p => p.BillId);

            modelBuilder.Entity<BillProduct>().HasKey(p => new
            {
                p.ProductId,
                p.BillId
            });
            modelBuilder.Entity<BillProduct>()
                .HasRequired(p => p.Product)
                .WithMany(p => p.Bills)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<BillProduct>()
                .HasRequired(p => p.Bill)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BillId);

            modelBuilder.Entity<RecieptProduct>().HasKey(p => new
            {
                p.ProductId,
                p.RecieptId
            });
            modelBuilder.Entity<RecieptProduct>()
                .HasRequired(p => p.Product)
                .WithMany(p => p.Reciepts)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<RecieptProduct>()
                .HasRequired(p => p.Reciept)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.RecieptId);
        }
    }
}
