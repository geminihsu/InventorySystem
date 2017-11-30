using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySample.Models
{
    public class ContainerMapping
    {
        private static Dictionary<Guid, Container> FileUploadCache { get; } = new Dictionary<Guid, Container>();


        public static void AddOrUpdateCache(Container model)
        {
            if (FileUploadCache.ContainsKey(model.Id))
            {
                FileUploadCache[model.Id] = model;
                return;
            }

            FileUploadCache.Add(model.Id, model);
        }


        public static Container CheckAndGetCacheModel(Guid fileId)
        {
            return FileUploadCache.ContainsKey(fileId)
                ? FileUploadCache[fileId].Id.Equals(fileId) ? FileUploadCache[fileId] : null : null;
        }
    }
}