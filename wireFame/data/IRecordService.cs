using System.Collections.Generic;
using System.Threading.Tasks;

namespace WireFrame.Data
{
    public interface IRecordService
    {
        Task<bool> RecordInsert(StudentRecord record);
        Task<IEnumerable<StudentRecord>> RecordList();
    }
}