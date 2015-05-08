using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class SchemaDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        public ISchemaDao SchemaDao { get; set; }


        [TestMethod]
        public void TestEmployeeDao_AddEmployee()
        {
            Schema schema = new Schema();
            schema.CourseID = "UnitTests";
            schema.CourseName = "單元測試";
            schema.CourseDescription = "a";
            SchemaDao.AddSchema(schema);

            Schema dbSchema = SchemaDao.GetSchemaById(schema.CourseID);
            Assert.IsNotNull(dbSchema);
            Assert.AreEqual(schema.CourseID, dbSchema.CourseID);

            Console.WriteLine("員工編號為 = " + dbSchema.CourseID);
            Console.WriteLine("員工姓名為 = " + dbSchema.CourseName);
            Console.WriteLine("員工年齡為 = " + dbSchema.CourseDescription);

            dbSchema = SchemaDao.GetSchemaById(schema.CourseID);
            Assert.IsNull(dbSchema);
        }

        [TestMethod]
        public void TestSchemaDao_GetSchemaById()
        {
            Schema schema = SchemaDao.GetSchemaById("aaa");
            Assert.IsNotNull(schema);
            Console.WriteLine("編號為 = " + schema.CourseID);
            Console.WriteLine("課程名稱為 = " + schema.CourseName);
            Console.WriteLine("課程描述為 = " + schema.CourseDescription);
        }
    }
}
