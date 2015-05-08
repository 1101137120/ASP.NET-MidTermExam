
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;
namespace KuasCore.Dao.Impl
{
    public class SchemaDao : GenericDao<Schema>, ISchemaDao
    {
        override protected IRowMapper<Schema> GetRowMapper()
        {
            return new SchemaRowMapper();
        }

        public void AddSchema(Schema schema)
        {
            string command = @"INSERT INTO Schema (CourseID, CourseName, CourseDescription) VALUES (@CourseID, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = schema.CourseID;
            parameters.Add("CourseName", DbType.String).Value = schema.CourseName;
            parameters.Add("CourseDescription", DbType.Int32).Value = schema.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateSchema(Schema schema)
        {
            string command = @"UPDATE Schema SET CourseName = @CourseName, CourseDescription = @CourseDescription WHERE CourseID = @CourseID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = schema.CourseID;
            parameters.Add("CourseName", DbType.String).Value = schema.CourseName;
            parameters.Add("CourseDescription", DbType.Int32).Value = schema.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Schema> GetAllSchemas()
        {
            string command = @"SELECT * FROM Schema ORDER BY CourseID ASC";
            IList<Schema> schemas = ExecuteQueryWithRowMapper(command);
            return schemas;
        }

        public Schema GetSchemaById(string CourseID)
        {
            string command = @"SELECT * FROM Schema WHERE CourseID = @CourseID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = CourseID;

            IList<Schema> schemas = ExecuteQueryWithRowMapper(command, parameters);
            if (schemas.Count > 0)
            {
                return schemas[0];
            }

            return null;
        }
    }
}
