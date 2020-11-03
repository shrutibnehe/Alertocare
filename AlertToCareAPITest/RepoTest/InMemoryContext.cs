using System;
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using DataContext = AlertToCareAPI.Database.DataContext;

namespace AlertToCareAPITest.RepoTest
{
    public class InMemoryContext : IDisposable
    {
        protected readonly DataContext Context;

        protected InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            Context = new DataContext(option);
            Context.Database.EnsureCreated();
            InitializeDatabase(Context);
        }
        private void InitializeDatabase(DataContext context)
        {
            var Layout1 = new Layout
            {
                LayoutId="L001",
                LayoutName="Rectangular"
            };
            context.Add(Layout1);
            var Icu1 = new Icu
            {
                Id = "ICU001",
                BedCount = 12,
                LayoutId = "L001"
            };
            context.Add(Icu1);
            var Icu2 = new Icu
            {
                Id = "ICU002",
                BedCount = 10,
                LayoutId = "L002"
            };
            context.Add(Icu2);
            var Bed1 = new Bed
            {
                Id = 1,
                BedNo="B001",
                IcuId = "ICU001",
                IsOccupied = true
            };
            context.Add(Bed1);
            var Bed2 = new Bed
            {
                Id = 2,
                BedNo = "B002",
                IcuId = "ICU001",
                IsOccupied = true
            };
            context.Add(Bed2);
            var Bed3 = new Bed
            {
                Id = 3,
                BedNo = "B003",
                IcuId = "ICU001",
                IsOccupied = false
            };
            context.Add(Bed3);
            var _Patient = new Patient
            {
                Id = "P01",
                PatientName = "Raj",
                Age = 24,
                IcuId = "ICU001",
                BedId = "B001",
                ContantNumber = "9876543210"
            };
            context.Add(_Patient);

            var _Patient2 = new Patient
            {
                Id = "P02",
                PatientName = "Sam",
                Age = 24,
                IcuId = "ICU001",
                BedId = "B002",
                ContantNumber = "9876510937"
            };
            context.Add(_Patient2);

            var _Vitals = new Vital
            {
                Id = "P03",
                Bpm = 70,
                Spo2 = 98,
                RespRate = 111
            };
            context.Add(_Vitals);

            var _alerts = new Alert
            {
                Id = "AL002",
                PatientId = "P02",
                Message = "BPM is high",
                BedId = "B002",
                IcuId = "ICU001",
                IsActive = 1
            };
            context.Add(_alerts);
            context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

