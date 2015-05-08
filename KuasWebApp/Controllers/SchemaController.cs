using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class SchemaController : ApiController
    {
        public ISchemaService SchemaService { get; set; }

        [HttpPost]
        public Schema AddSchema(Schema schema)
        {
            CheckSchemaIsNullThrowException(schema);

            try
            {
                SchemaService.AddSchema(schema);
                return SchemaService.GetSchemaById(schema.CourseID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Schema> GetAllSchemas()
        {
            return SchemaService.GetAllSchemas();
        }

        [HttpGet]
        [ActionName("byId")]
        public Schema GetSchemaById(string CourseID)
        {
            var schema = SchemaService.GetSchemaById(CourseID);

            if (schema == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return schema;
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckSchemaIsNullThrowException(Schema schema)
        {
            Schema dbSchema = SchemaService.GetSchemaById(schema.CourseID);

            if (dbSchema == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="schema">
        ///     員工資料.
        /// </param>
        private void CheckSchemaIsNotNullThrowException(Schema schema)
        {
            Schema dbSchema = SchemaService.GetSchemaById(schema.CourseID);

            if (dbSchema != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}
