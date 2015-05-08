using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;


namespace KuasCore.Services.Impl
{
    public class TxSchemaService : ITxSchemaService
    {
        public ISchemaDao SchemaDao { get; set; }

        public void ExecuteTxMethod()
        {
            Schema schema1 = new Schema();
            schema1.CourseID = "QQQ";
            schema1.CourseName = "AAA";
            schema1.CourseDescription = 4;
            SchemaDao.AddSchema(schema1);

            Schema schema2 = new Schema();
            schema2.CourseID = "BBB";
            schema2.CourseName = "BBB";
            schema2.CourseDescription = 0;
            SchemaDao.AddSchema(schema2);

            Schema dbSchema = SchemaDao.GetSchemaById("QQQ");
            dbSchema.CourseName = "XXX";
            SchemaDao.UpdateSchema(dbSchema);

            throw new Exception("Get an exception");
        }
    }
}
