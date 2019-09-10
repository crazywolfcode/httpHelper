using System;
using System.Collections.Generic;
using System.Text;

namespace HttpHelper
{
    
   public class Genericity
    {

        public T testT<T>() {
            return (T)NetBaseHelper.Null();
        }

    }
}
