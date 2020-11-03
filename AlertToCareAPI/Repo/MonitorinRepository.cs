using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class MonitorinRepository : IMonitoringRepo
    {
        private readonly DataContext _context;
        public MonitorinRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Alert> GetAllActiveAlerts(string icuID)
        {
            var alertList = _context.AlertsInfo.ToList();
            try
            {
                var result = alertList.FindAll(item => item.IsActive == 1 && item.IcuId == icuID);
                return result;
            }
            catch (Exception)
            {
                var result = new List<Alert> { };
                return result;
            }

            
        }

        public IEnumerable<Bed> GetAllUnOccupiedBeds(string icuID)
        {
            var beds = _context.BedsInfo.ToList();
            try
            {
                var result = beds.FindAll(item => item.IsOccupied && item.IcuId == icuID);
                return result;
            }
            catch (Exception)
            {
                var result = new List<Bed> { };
                return result;
            }
        }


        public bool AlertChangeStatus(string id)
        {

            var alertList = _context.AlertsInfo.ToList();
            var alert = alertList.First(item => item.Id == id);
            if (alert.IsActive == 0)
            {
                alert.IsActive = 1;
            }
            else
            {
                alert.IsActive = 0;
            }

            _context.Update(alert);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveAlertsOfPatient(string id)
        {
            var alertList = _context.AlertsInfo.ToList();
            var alertsToDelete = alertList.FindAll(item => item.PatientId == id);
            foreach (var alert in alertsToDelete)
            {
                _context.AlertsInfo.Remove(alert);
                _context.SaveChanges();
            }
            return true;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }
    }
}