using System.Data;

namespace mUtility
{
    /// <summary>
    /// This class is used for sending back a response from a web service to the consumer. This is a template for how the object would be sent back.
    /// </summary>
    public class ResponseClass
    {
        int result = 0;
        string message = "No Message";
        string strVal = "No Value";
        DataSet ds = new DataSet();

        #region Constructors

        /// <summary>
        /// Default constructor with no parameter
        /// </summary>
        public ResponseClass()
        {

        }

        /// <summary>
        /// This will create an object with the result, message and dataset sent from the database. If this is the case then the StrVal always contains my twitter profile.
        /// </summary>
        /// <param name="_result">Integer value</param>
        /// <param name="_message">String value</param>
        /// <param name="_ds">Dataset</param>
        public ResponseClass(int _result, string _message, DataSet _ds)
        {
            Result = _result;
            Message = _message;
            Ds = _ds;
            StrVal = @"follow @ghulamostafa";
        }

        /// <summary>
        /// This will create an object with the result, message and additional string value sent from the database
        /// </summary>
        /// <param name="_result">Integer value</param>
        /// <param name="_message">String value</param>
        /// <param name="_strVal">Additional string value</param>
        public ResponseClass(int _result, string _message, string _strVal)
        {
            Result = _result;
            Message = _message;
            StrVal = _strVal;
            Ds = new DataSet();
        }

        #endregion

        #region Properties

        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        public string StrVal
        {
            get { return strVal; }
            set { strVal = value; }
        }

        #endregion
    }
}
