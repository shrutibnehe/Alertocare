using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
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

            return _context.AlertsInfo.FromSqlRaw($"SELECT * FROM AlertsInfo WHERE IsActive = 1 AND IcuId=\"{icuID}\";").ToList();
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

        public void RemoveAlertsOfPatient(string id)
        {
            var alertList = _context.AlertsInfo.ToList();
            var alertsToDelete = alertList.FindAll(item => item.PatientId == id);
            foreach (var alert in alertsToDelete)
            {
                _context.AlertsInfo.Remove(alert);
            }

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }
    }
}