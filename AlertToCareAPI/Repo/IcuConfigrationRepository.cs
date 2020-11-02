using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class IcuConfigrationRepository : IIcuConfigurationRepository
    {
        private readonly DataContext _context;

        public IcuConfigrationRepository(DataContext context)
        {
            _context = context;
        }

        public void AddNewIcu(Icu icu)
        {
            /* if (icu == null)
             {
                 throw new ArgumentNullException(nameof(icu));
             }*/


            if (_context.IcusInfo.Find(icu.Id) != null)
            {

                throw new SQLiteException(SQLiteErrorCode.Constraint_PrimaryKey, "ID already exists");

            }
            if (!CheckLayoutId(icu.LayoutId))
            {
                throw new SQLiteException(SQLiteErrorCode.Constraint, "Layout Id not Registered");
            }
            else
            {
                _context.IcusInfo.Add(icu);
                _context.SaveChanges();
            }



        }
        public bool ConfigureBeds(string icuId, int bedCount)
        {
            string icu = icuId;


            if (CheckIcuIdAndBedCountIsValid(icu, bedCount))
            {
                Bed configurebeds;

                for (int i = 1; i <= bedCount; i++)
                {
                    configurebeds = new Bed();
                    configurebeds.BedNo = "B00" + i;
                    configurebeds.IcuId = icu;
                    //configurebeds.IsOccupied = 0;
                    _context.BedsInfo.Add(configurebeds);
                    _context.SaveChanges();
                    //string bedno = "B00" + i;
                    //int status = 0;
                    // _context.BedsInfo.FromSqlRaw($"INSERT INTO BedsInfo(BedNo,IcuId,IsOccupied) VALUES ({bedno},{IcuId},{status})");
                    //_context.SaveChanges();
                }


                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckIcuIdAndBedCountIsValid(string icuId, int bedCount)
        {
            var IcuList = _context.IcusInfo.ToList();
            try
            {
                IcuList.First(Icu => Icu.Id == icuId && Icu.BedCount == bedCount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        private bool CheckLayoutId(string layoutid)
        {
            if (_context.LayoutInfo.Find(layoutid) != null)
                return true;
            return false;
        }


        public IEnumerable<Icu> GetAllIcus()
        {
            var icUs = _context.IcusInfo.ToList();
            return icUs;
        }

        public void RemoveIcu(Icu icu)
        {
            if (icu == null)
            {
                throw new ArgumentNullException(nameof(icu));
            }
            /*
            //If beds of the Icu are occupied throw an exception
            var occupiedBeds = _context.PatientsInfo.FromSqlRaw($"SELECT * FROM PatientsInfo WHERE IcuId = {icu.Id}").ToList();

            if (occupiedBeds.Count() > 0)
            {
                throw new Exception("ICU cann't be removed still got some occupied beds !!");
            }
            //Remove the beds of the corresponding ICU from the bed table
            _context.BedsInfo.FromSqlRaw($"DELETE FROM BedsInfo WHERE IcuId = {icu.Id}");
            */

            _context.IcusInfo.Remove(icu);
        }

        [ExcludeFromCodeCoverage]
        public void UpdateIcu(Icu icu)
        {
            //Phew ... Nothing to do here
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }

        public Icu GetIcuById(string id)
        {
            return _context.IcusInfo.Find(id);
        }
        public IEnumerable<Layout> GetAllLayouts()
        {
            return _context.LayoutInfo.ToList();
        }
    }
}
