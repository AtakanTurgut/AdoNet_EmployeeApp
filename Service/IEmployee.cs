using Service.DTO;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Service
{
    public interface IEmployee
    {
        List<EmployeeDTO> employees(string sqlCommand);

        int insert(string sqlCommand);
        void delete(string sqlCommand);
        void update(string sqlCommand);

    }
}
