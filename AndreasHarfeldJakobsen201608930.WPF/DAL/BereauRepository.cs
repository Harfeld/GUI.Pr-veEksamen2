using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreasHarfeldJakobsen201608930.WPF.Data;
using AndreasHarfeldJakobsen201608930.WPF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AndreasHarfeldJakobsen201608930.WPF.DAL
{
    class BereauRepository
    {
        private DbContextOptions<BereauDbContext> _context;

        public BereauRepository()
        {
            _context = new DbContextOptionsBuilder<BereauDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BereauDatabase;Trusted_Connection=true;MultipleActiveResultSets=true")
                .Options;
        }

        public bool CreateDatabase()
        {
            using (var database = new BereauDbContext(_context))
            {
                if (true && (database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                database.Database.EnsureDeleted();
                return database.Database.EnsureCreated();
            }
        }

        #region Creations

        public async Task AddModel(Model model)
        {
            using (var database = new BereauDbContext(_context))
            {
                await database.Models.AddAsync(model);
                await database.SaveChangesAsync();
            }
        }

        public async Task AddAssignment(Assignment assignment)
        {
            using (var database = new BereauDbContext(_context))
            {
                await database.Assignments.AddAsync(assignment);
                await database.SaveChangesAsync();
            }
        }

        public async Task AddModelToAssignment(Model model, Assignment assignment)
        {
            var modelassignment = new ModelAssignment
            {
                AssignmentId = assignment.AssignmentId,
                ModelId = model.ModelId
            };

            using (var database = new BereauDbContext(_context))
            {
                await database.ModelAssignments.AddAsync(modelassignment);

                assignment.ModelsNeeded -= 1;
                if (assignment.ModelsNeeded == 0)
                    assignment.Planned = true;
                database.Assignments.Update(assignment);

                await database.SaveChangesAsync();
            }
        }

        #endregion

        #region Removals

        public async Task RemoveAssignment(Assignment assignment)
        {
            using (var database = new BereauDbContext(_context))
            {
                database.Assignments.Remove(assignment);
                await database.SaveChangesAsync();
            }
        }

        public async Task RemoveModel(Model model)
        {
            using (var database = new BereauDbContext(_context))
            {
                database.Models.Remove(model);
                await database.SaveChangesAsync();
            }
        }

        public async Task RemoveModelAssignment(Model model, Assignment assignment)
        {
            using (var database = new BereauDbContext(_context))
            {
                var toRemove = database.ModelAssignments.Find(new {model.ModelId, assignment.AssignmentId});
                database.ModelAssignments.Remove(toRemove);
                await database.SaveChangesAsync();
            }
        }

        #endregion

        #region Lists

        public async Task<ObservableCollection<Model>> GetAllModels()
        {
            using (var database = new BereauDbContext(_context))
            {
                //var models = await database.Models.ToListAsync();
                return new ObservableCollection<Model>(await database.Models.ToListAsync());
            }
        }

        public async Task<ObservableCollection<Assignment>> GetAllAssignments()
        {
            using (var database = new BereauDbContext(_context))
            {
                var assignments = await database.Assignments.ToListAsync();
                return new ObservableCollection<Assignment>(assignments);
            }
        }

        public async Task<ObservableCollection<Assignment>> GetPlannedAssignments()
        {
            using (var database = new BereauDbContext(_context))
            {
                var assignments = await database.Assignments
                    .Where(a => a.Planned == true)
                    .ToListAsync();
                return new ObservableCollection<Assignment>(assignments);
            }
        }

        public async Task<ObservableCollection<Assignment>> GetUnplannedAssignments()
        {
            using (var database = new BereauDbContext(_context))
            {
                var assignments = await database.Assignments
                    .Where(a => a.Planned == false)
                    .ToListAsync();
                return new ObservableCollection<Assignment>(assignments);
            }
        }
        /*
        public async Task<ObservableCollection<Model>> GetModelsByAssignment(Assignment assignment)
        {
            using (var database = new BereauDbContext(_context))
            {
                var lol = database.ModelAssignments
                    .Where(ma => ma.AssignmentId == assignment.AssignmentId)
                    
                var models = await database.Models.Where(m=>)
                    
                    //ToListAsync();
                return new ObservableCollection<Model>(models);
            }
        }
        */
        #endregion
    }
}
