using SportskiCentarRS2.Domain.Exceptions;
using System.Text.RegularExpressions;
using ValueOf;

namespace SportskiCentarRS2.Domain.ValueObjects
{
    public class JMBG : ValueOf<string,JMBG>
    {
        private string RegexExpression = @"^[0-9]{13}$";
        protected override void Validate()
        {
            if (!string.IsNullOrWhiteSpace(Value) && !Regex.IsMatch(Value, RegexExpression))
                throw new NetacanJMBGEception();
        }
    }
}
