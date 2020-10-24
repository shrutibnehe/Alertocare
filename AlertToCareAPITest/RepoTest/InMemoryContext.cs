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
            var Bed1 = new Bed
            {
               // Id = "B002",
                IcuId = "ICU004",
                IsOccupied = true
            };
            context.Add(Bed1);

            var Icu1 = new Icu
            {
                Id = "ICU002",
                BedCount = 4,
                LayoutId = "L002"
            };
            context.Add(Icu1);

            var _Patient = new Patient
            {
                Id = "P02",
                PatientName = "Raj",
                Age = 24,
                IcuId = "ICU002",
                BedId = "B002",
                ContantNumber = "1234"
            };
            context.Add(_Patient);

            var _Patient2 = new Patient
            {
                Id = "P04",
                PatientName = "Sam",
                Age = 24,
                IcuId = "ICU003",
                BedId = "B002",
                ContantNumber = "1234"
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
            context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

