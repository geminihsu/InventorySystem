using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySample.Models
{
    public class ContainerMapping
    {
        private static Dictionary<Guid, Container> FileUploadCache { get; } = new Dictionary<Guid, Container>();

        private static void AddOrUpdateCache(Container model)
        {
            if (FileUploadCache.ContainsKey(model.ID))
            {
                FileUploadCache[model.ID] = model;
                return;
            }

            FileUploadCache.Add(model.ID, model);
        }


        private static Container CheckAndGetCacheModel(Guid fileId)
        {
            return FileUploadCache.ContainsKey(fileId)
                ? FileUploadCache[fileId].ID.Equals(fileId) ? FileUploadCache[fileId] : null : null;
        }
    }
}