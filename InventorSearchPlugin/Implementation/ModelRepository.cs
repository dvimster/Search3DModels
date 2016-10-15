using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Infrastructure;

namespace InventorSearchPlugin.Implementation
{
    public class ModelRepository : IRepository, IDisposable
    {
        private ModelContext modelContext;
        private bool disposed = false;

        public ModelRepository(ModelContext context)
        {
            modelContext = context;
        }

        public IEnumerable<Model> GetModels(SearchModel searchModel, SearchModel tempModel, double deviation)
        {
            if (deviation > 0)
            {
                return
                modelContext.Models.Where(
                    m => m.Length > (searchModel.Length - tempModel.Length)
                         && m.Length < (searchModel.Length + tempModel.Length)
                         && m.Height > (searchModel.Height - tempModel.Height)
                         && m.Height < (searchModel.Height + tempModel.Height)
                         && m.Width > (searchModel.Width - tempModel.Width)
                         && m.Width < (searchModel.Width + tempModel.Width))
                    .ToList();
            }
            return
                modelContext.Models.Where(
                    m => m.Length == searchModel.Length
                         && m.Height == searchModel.Height
                         && m.Width == searchModel.Width).ToList();
        }

        public void AddModel(Model model)
        {
            modelContext.Models.Add(model);
        }

        public void UpdateModel(Model model)
        {
            modelContext.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            modelContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    modelContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}