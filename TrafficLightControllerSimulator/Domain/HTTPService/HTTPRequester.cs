using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.HTTPService
{
    public class HTTPRequester
    {
        static HTTPRequester HTTPRequesterIntance;

        public static HTTPRequester GetInstance
        {
            get { return HTTPRequesterIntance ?? (HTTPRequesterIntance = new HTTPRequester()); }
        }
        private HTTPRequester()
        {
        }


    }
}
