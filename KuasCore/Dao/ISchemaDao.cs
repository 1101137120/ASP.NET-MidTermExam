using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface ISchemaDao
    {
        void AddSchema(Schema schema);
        void UpdateSchema(Schema schema);

        IList<Schema> GetAllSchemas();

        Schema GetSchemaById(string CourseID);
    }
}
