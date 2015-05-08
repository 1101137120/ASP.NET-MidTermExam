using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{
    public interface ISchemaService
    {

        void AddSchema(Schema schema);
        IList<Schema> GetAllSchemas();
        Schema GetSchemaById(string CourseID);
    }
}
