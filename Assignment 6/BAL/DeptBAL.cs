using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Assignment_6.BAL
{
    public class DeptBAL
    {
        DAL.DeptDAL objdeptDAL = new DAL.DeptDAL();

        private string _deptname;
        private int _deptid;

        public string DeptName
        {
            get
            {
                return _deptname;
            }
            set
            {
                _deptname = value;
            }

        }
        public int DeptId
        {
            get
            {
                return _deptid;
            }
            set
            {
                _deptid = value;
            }

        }
        public int insertdepartment()
        {
            return objdeptDAL.departmentInsert(this);
        }
        public DataTable viewDept()
        {
            return objdeptDAL.viewDepartment();
        }
    }
}