using KontehAppFix;

namespace AppFixAPI.Services
{
    public class ResultGenerator : IResultGenerator
    {
        private IKonteh _konteh;

        public ResultGenerator(IKonteh konteh)
        {
            _konteh = konteh;
        }

        public string GenerateResult(string contestantsGuid)
        {
            if (contestantsGuid == "Insert your GUID here")
                return "You should assign your guid to myGuid variable in file AppFixAPI.Services.GuidProvider (line 12 initially).\r\ne.g. string myGuid = \"XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX\";";

            var result = _konteh.DoSomeMagicOnGuid(contestantsGuid);
            return result;
        }
    }
}