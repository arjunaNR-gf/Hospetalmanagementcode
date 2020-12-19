using System;
using System.Collections.Generic;
using System.Text;

namespace Hospetal
{
    class ExceptionHospetal
    {
    }

    class UserPasswordNotMatcching:Exception
    {
        public UserPasswordNotMatcching(String msg):base(msg)
        {

        }
    }

    class Successfull : Exception
    {
        public Successfull(String msg) : base(msg)
        {

        }
    }
}
