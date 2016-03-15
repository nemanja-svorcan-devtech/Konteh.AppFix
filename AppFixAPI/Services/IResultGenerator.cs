using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFixAPI.Services
{
    public interface IResultGenerator
    {
        string GenerateResult(string contestantsGuid);
    }
}
