﻿using AutoMapper.QueryableExtensions;
using SlotCarsGo_Server.Models;
using SlotCarsGo_Server.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SlotCarsGo_Server.Repository
{
    public class DriverResultsRepository<T> : IRepositoryAsync<DriverResult> where T : DriverResult 
    {
        public async Task<DriverResult> Delete(string id)
        {
            DriverResult driverResult;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                driverResult = await db.DriverResults.FindAsync(id);
                if (driverResult != null)
                {
                    db.DriverResults.Remove(driverResult);
                    await db.SaveChangesAsync();
                }
            }

            return driverResult;
        }

        public bool Exists(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.DriverResults.Count(e => e.Id == id) > 0;
            }
        }

        public IEnumerable<DriverResult> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.DriverResults;
            }
        }

/* FILLER */

        public async Task<DriverResult> GetById(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return await db.DriverResults.Where(dr => dr.Id == id).FirstOrDefaultAsync();
//                    .Include(dr => dr.ApplicationUser)
//                    .Include(dr => dr.ApplicationUser.BestLapTimes)
//                    .Include(dr => dr.Car)
//                    .Include(dr => dr.Car.Track)
//                    .Include(dr => dr.Car.Track.BestLapTime)
//                    .Include(dr => dr.Car.Track.BestLapTime.LapTime)
//                    .Include(dr => dr.Car.BestLapTime)
//                    .Include(dr => dr.Car.BestLapTime.LapTime)
//                    .Include(dr => dr.Car.BestLapTimes)
//                    .FirstOrDefaultAsync();
            }
        }

        public IEnumerable<DriverResult> GetForId(string sessionId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.DriverResults.Where(dr => dr.RaceSessionId == sessionId);
            }
        }

        public async Task<DriverResult> Insert(DriverResult driverResult)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                driverResult.Id = string.IsNullOrEmpty(driverResult.Id) ? Guid.NewGuid().ToString() : driverResult.Id;
                driverResult = db.DriverResults.Add(driverResult);
                await db.SaveChangesAsync();
            }

            return driverResult;
        }

        public async Task<EntityState> Update(string id, DriverResult driverResult)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(driverResult).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.DriverResults.Count(e => e.Id == id) == 0)
                    {
                        return EntityState.Unchanged;
                    }
                    else
                    {
                        throw;
                    }
                }

                return db.Entry(driverResult).State;
            }
        }
    }
}