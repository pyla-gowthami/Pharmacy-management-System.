using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;

namespace PharmacyTesting
{
    public class SupplierTesting
    {
        SupplierDAL suplr;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<PharmacyContextDb> bldr = new DbContextOptionsBuilder<PharmacyContextDb>();
            bldr.UseSqlServer(connectionString: @"Server=KARTHI\SQLEXPRESS;Database=PharmacyDb;Integrated Security=True;trusted_connection=true");
            PharmacyContextDb context = new PharmacyContextDb(bldr.Options);
            suplr = new SupplierDAL(context);
        }

        [Test]
        public void GetSupplierTest()
        {
            Supplier output = null;
            output = suplr.GetSupplier(1);
            Assert.AreEqual((output!=null),true);
        }

        [Test]
        public void AddSupplierTest()
        {
            string reqmsg = "Supplier Added Successfully";
            Supplier supplier = new Supplier();
            supplier.SupplierId = 0;
            supplier.SupplierName = "zinal";
            supplier.EmailId = "zinal@gmail.com";
            supplier.PhoneNumber = "9912312321";
            supplier.DrugAvailable = "cofin";
            string output = suplr.AddSupplier(supplier);
            Assert.AreEqual(output, reqmsg);
        }

        [Test]
        public void ShowAllSuppliersTest()
        {
            var output = suplr.ShowAllSuppliers();
            Assert.Greater(output.Count,0);
        }

        [Test]
        public void DeleteSupplierTest()
        {
            var output = suplr.DeleteSupplier(16);
            Assert.AreEqual(output != null, true);
        }
    }
}