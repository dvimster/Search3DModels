using System;
using System.Collections.Generic;
using InventorSearchPlugin.Entries;

namespace InventorSearchPlugin.Infrastructure
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Model> GetModels(SearchModel searchModel, SearchModel tempModel, double deviation);
        void AddModel(Model model);
        void UpdateModel(Model model);
        void Save();
    }
}