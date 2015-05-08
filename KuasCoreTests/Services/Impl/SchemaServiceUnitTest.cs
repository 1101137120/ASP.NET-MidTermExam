using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class SchemaServiceUnitTest :  AbstractDependencyInjectionSpringContextTests
    {
        public ISchemaService SchemaService { get; set; }

        [TestMethod]
        public void TestSchemaService_AddSchema()
        {
            Schema schema = new Schema();
            schema.CourseID = "UnitTests";
            schema.CourseName = "單元測試";
            schema.CourseDescription = 15;
            SchemaService.AddSchema(schema);

            Schema dbSchema = SchemaService.GetSchemaById(schema.CourseID);
            Assert.IsNotNull(dbSchema);
            Assert.AreEqual(schema.CourseID, dbSchema.CourseID);

            Console.WriteLine("編號為 = " + dbSchema.CourseID);
            Console.WriteLine("課程名稱 = " + dbSchema.CourseName);
            Console.WriteLine("課程描述 = " + dbSchema.CourseDescription);

        }

        [TestMethod]
        public void TestSchemaService_GetSchemaById()
        {
            Schema schema = SchemaService.GetSchemaById("aaa");
            Assert.IsNotNull(schema);

            Console.WriteLine("員工編號為 = " + schema.CourseID);
            Console.WriteLine("員工姓名為 = " + schema.CourseName);
            Console.WriteLine("員工年齡為 = " + schema.CourseDescription);
        }
    }
}
