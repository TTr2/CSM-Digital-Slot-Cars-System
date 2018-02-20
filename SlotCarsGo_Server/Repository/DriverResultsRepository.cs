﻿using SlotCarsGo_Server.Models;
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
        public async Task<DriverResult> Delete(int id)
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

        public bool Exists(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.DriverResults.Count(e => e.Id == id) > 0;
            }
        }

        public IQueryable<DriverResult> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.DriverResults;
            }
        }

        public async Task<DriverResult> GetById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return await db.DriverResults.FindAsync(id);
            }
        }

        public async Task<DriverResult> Insert(DriverResult driverResult)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                driverResult = db.DriverResults.Add(driverResult);
                await db.SaveChangesAsync();
            }

            return driverResult;
        }

        public async Task<EntityState> Update(int id, DriverResult driverResult)
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