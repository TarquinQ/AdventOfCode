using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    public class InputtedPolicyLine
    {
        public PasswordPolicy1 Policy { get; set; }
        public string Password { get; set; }

        public InputtedPolicyLine(PasswordPolicy1 policy, string password)
        {
            this.Policy = policy;
            this.Password = password;
        }

        public bool IsValid1()
        {
            return this.Policy.ValidateInput(this.Password);
        }

        public bool IsValid2()
        {
            return (new PasswordPolicy2(this.Policy)).ValidateInput(this.Password);
        }
    }
}
