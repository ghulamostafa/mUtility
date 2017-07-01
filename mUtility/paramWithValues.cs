using System.Data;

namespace mUtility
{
    /// <summary>
    /// This class creates objects that are passed in the methods for using in stored procedures
    /// </summary>
    public class paramWithValues
    {
        string _Param;
        string _theValue;
        string _DataType;
        DataTable _ValueDT;

        bool _IsOutPut;

        #region Constructors

        /// <summary>
        /// Default Constructor with no parameters.
        /// </summary>
        public paramWithValues()
        {
        }

        /// <summary>
        /// This param with value takes the parameter name and value object
        /// </summary>
        /// <param name="_param">Parameter Name</param>
        /// <param name="_theValue">Object: String and converted to string only</param>
        public paramWithValues(string _param, string _theValue)
        {
            Param = _param;
            theValue = _theValue;
        }

        /// <summary>
        /// This param with value takes the parameter name and value object
        /// </summary>
        /// <param name="_param">Parameter Name</param>
        /// <param name="_theValueDT">Object: Datatable</param>
        /// <param name="_Type">Explicitly write "DataTable"</param>
        public paramWithValues(string _param, DataTable _theValueDT, string _Type)
        {
            Param = _param;
            theValueDT = _theValueDT;
            _DataType = _Type;
        }

        #endregion

        #region Properties

        public string Param
        {
            get { return _Param; }
            set { _Param = value; }
        }

        public string theValue
        {
            get { return _theValue; }
            set { _theValue = value; }
        }

        public string DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        public DataTable theValueDT
        {
            get { return _ValueDT; }
            set { _ValueDT = value; }
        }

        public bool IsOutPut
        {
            get { return _IsOutPut; }
            set { _IsOutPut = value; }
        }

        #endregion
    }
}
