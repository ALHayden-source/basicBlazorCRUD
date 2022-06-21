using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireFrame.Data
{
    public class RecordService : IRecordService
    {
        //Database connection
        private readonly SqlConnectionConfiguration _configuration;

        public RecordService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        //SQL insert for new student record
        public async Task<bool> RecordInsert(StudentRecord record)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("LastName", record.LastName, System.Data.DbType.String);
                parameters.Add("FirstName", record.FirstName, System.Data.DbType.String);
                parameters.Add("MiddleName", record.MiddleName, System.Data.DbType.String);
                parameters.Add("CalendarYear", record.CalendarYear, System.Data.DbType.Int32);
                parameters.Add("SemesterNumber", record.SemesterNumber, System.Data.DbType.Int32);
                parameters.Add("StartDate", record.StartDate, System.Data.DbType.Date);
                parameters.Add("EndDate", record.EndDate, System.Data.DbType.Date);

                //Stored procedure insert
                await conn.ExecuteAsync("spRecord_Insert", parameters, commandType: System.Data.CommandType.StoredProcedure);

                /* hard coded insert
                const string query = @"INSERT INTO StudentRecord (LastName, FirstName, MiddleName, CalendarYear, SemesterNumber, StartDate, EndDate) 
                    VALUES (@LastName, @FirstName, @MiddleName, @CalendarYear, @SemesterNumber, @StartDate, @EndDate)";
                
                await conn.ExecuteAsync(query, new
                {
                    record.LastName,
                    record.FirstName,
                    record.MiddleName,
                    record.CalendarYear,
                    record.SemesterNumber,
                    record.StartDate,
                    record.EndDate
                }, commandType: System.Data.CommandType.Text);
                */
            
            }
            return true;
        }

        public async Task<IEnumerable<StudentRecord>> RecordList()
        {
            IEnumerable<StudentRecord> records;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                records = await conn.QueryAsync<StudentRecord>("spRecord_Confirm", commandType: System.Data.CommandType.StoredProcedure);
            
            }
            return records;
        }
    }
}
