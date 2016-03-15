using System;
using System.Collections.Generic;
using System.Web;

namespace AppFixAPI.Services
{
    public class GuidProvider : IGuidProvider
    {
        public string GetGuid()
        {
            // TODO: assign your GUID to myGuid string
            string myGuid = "Insert your GUID here";

            return myGuid;
        }
    }
}