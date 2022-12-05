using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Assignment_6.BAL
{
    public class DesignationBAL
    {
        DAL.DesignationDAL objdesignationDAL = new DAL.DesignationDAL();
        private int _designationid;
        private string _designationname;
        private int _deptid;
        public int DesignationId
        {
            get
            {
                return _designationid;
            }
            set
            {
                _designationid = value;
            }

        }
        public string DesignationName
        {
            get
            {
                return _designationname;
            }
            set
            {
                _designationname = value;
            }

        }
        public int DepartmentId
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
        public int insertDesignation()
        {
            return objdesignationDAL.designationInsert(this);
        }

        public DataTable viewDesignation()
        {
            return objdesignationDAL.designationView();
        }
        public int updateDesignation()
        {
            return objdesignationDAL.designationUpdate(this);
        }

        public int deleteDesignation()
        {
            return objdesignationDAL.designationDelete(this);
        }
    }
}