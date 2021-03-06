﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using SlotCarsGo_Server.Models;
using SlotCarsGo_Server.Models.DTO;
using SlotCarsGo_Server.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SlotCarsGo_Server.Repository
{
    public class DriversRepository<T, DTO> : IRepositoryAsync<Driver>, IRepositoryDTOAsync<DriverDTO>
    {
        public async Task<Driver> Delete(string id)
        {
            Driver driver;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                driver = await db.Drivers.FindAsync(id);
                if (driver != null)
                {
                    db.Drivers.Remove(driver);
                    await db.SaveChangesAsync();
                }
            }

            return driver;
        }

        public bool Exists(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Drivers.Count(e => e.Id == id) > 0;
            }
        }

        public IEnumerable<Driver> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Drivers;
            }
        }

        public IEnumerable<DriverDTO> GetAllAsDTO(string trackId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<DriverDTO> driverDTOs = new List<DriverDTO>();
                IQueryable<Driver> drivers = db.Drivers
                    .Where(d => d.TrackId == trackId)
                    .Include(d => d.ApplicationUser)
                    .Include(d => d.Car)
                    .OrderBy(d => d.ControllerId);

                foreach (Driver driver in drivers)
                {
                    driverDTOs.Add(Mapper.Map<DriverDTO>(driver));
                }

                return driverDTOs;
            }
        }

        public async Task<Driver> GetById(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return await db.Drivers.FindAsync(id);
            }
        }

        public IEnumerable<Driver> GetForTrack(string trackId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Drivers.Where(d => d.Track.Id == trackId).ToList();
            }
        }

        public Driver GetForUser(string userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Drivers.Where(d => d.ApplicationUserId == userId).FirstOrDefault();
            }
        }

        public async Task<Driver> Insert(Driver driver)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                driver.Id = string.IsNullOrEmpty(driver.Id) ? Guid.NewGuid().ToString() : driver.Id;
                driver = db.Drivers.Add(driver);
                await db.SaveChangesAsync();
            }

            return driver;
        }

        public async Task<EntityState> Update(string id, Driver driver)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(driver).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.Drivers.Count(e => e.Id == id) == 0)
                    {
                        return EntityState.Unchanged;
                    }
                    else
                    {
                        throw;
                    }
                }

                return db.Entry(driver).State;
            }
        }
    }
}