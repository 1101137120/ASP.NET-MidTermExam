using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;


namespace KuasCore.Services.Impl
{
   public class SchemaService :ISchemaService
    {
       public ISchemaDao SchemaDao { get; set; }

       public void AddSchema(Schema schema)
        {
            SchemaDao.AddSchema(schema);
        }

       public void UpdateSchema(Schema schema)
       {
           SchemaDao.UpdateSchema(schema);
       }

       public IList<Schema> GetAllSchemas()
        {
            return SchemaDao.GetAllSchemas();
        }

       public Schema GetSchemaById(string CourseID)
        {
            return SchemaDao.GetSchemaById(CourseID);
        }

    }
}
