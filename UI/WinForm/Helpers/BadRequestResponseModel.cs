using System.Collections.Generic;

namespace SportskiCentarRS2.WinForm.Helpers
{
    public class BadRequestResponseModel
    {
        public Dictionary<string,List<string>> Errors { get; set; }
    }
}
