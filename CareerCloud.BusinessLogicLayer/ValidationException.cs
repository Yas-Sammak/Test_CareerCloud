using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationException : Exception
    {

        /* This class will encapsulate an exception and add an additional code value.
            a. The ‘ValidationException’ class will inherit from the ‘Exception’ type.

            b. The ‘ValidationException’ class will have a constructor that takes two parameters:
                i. A ‘code’ of type int
                ii. A ‘message’ of type string

            c. The constructor created in step b will pass the ‘message’ string parameter to the base class constructor.

            d. The ‘code’ parameter passed to the constructor created in step b 
                will be stored as a public property in the ‘ValidationException’ class.
        */
        public int Code { get; set; }
        

        public ValidationException(int code, string message) : base(message)
        {
            Code = code;
        }

    }
}
