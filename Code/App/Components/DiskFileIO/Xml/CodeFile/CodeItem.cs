using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CygX1.DiskFileIO.Xml.XmlCode
{
    public class CodeItem
    {
        public Dictionary<string, SubstitutionExpression> Variables { get; private set; }

        public class SubstitutionExpression
        {
            public string VariableName { get; set; }
            public string Placeholder { get; set; }
            public string Value { get; set; }
        }

        public CodeItem(string id, string code)
        {
            ID = id;
            CodeTemplate = code;
            FindVariables();
        }
        public string ID { get; private set; }
        public string CodeTemplate { get; private set; }
        public string Code 
        {
            get { return GetFinalQuery(); }
        }

        private void FindVariables()
        {
            Variables = new Dictionary<string, SubstitutionExpression>();

            try
            {
                MatchCollection matchCollection = Regex.Matches(CodeTemplate, "{@@(.*?)}");
                foreach (Match match in matchCollection)
                {
                    string variableName = GetVariableNameWithoutBrackets(match.Value);

                    if (!string.IsNullOrEmpty(variableName) && !Variables.ContainsKey(variableName))
                        Variables.Add(variableName, new SubstitutionExpression 
                        { 
                            VariableName = variableName, 
                            Placeholder = match.Value, 
                            Value = string.Empty 
                        });
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Bad variable format detected. Variable collection failed.", exception);
            }
        }

        private string GetVariableNameWithoutBrackets(string bracketedExpression)
        {
            if (bracketedExpression.Length > 2)
                return bracketedExpression.Substring(1, bracketedExpression.Length - 2);
            else
                return string.Empty;
        }

        private string GetFinalQuery()
        {
            string code = CodeTemplate;
            foreach (SubstitutionExpression substitution in Variables.Values)
                code = code.Replace(substitution.Placeholder, substitution.Value);

            return code;
        }
    }
}
