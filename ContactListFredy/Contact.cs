using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListFredy
{
    class Contact
    {
        private string firstname;
        private string lastname;
        private string phone;

        public string firstName {
            get { return firstname; }
            set { firstname = value; }
        }

        public string lastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Phone
        {
            get { return phone; }
            set {
                if (value.Length == 10)
                {
                    phone = value;
                }
                else {
                    phone = "0000000000";
                }
            }
        }

        //constructor
        public Contact(){
            firstname = "john";
            lastname = "setiawan";
            Phone = "0000000000";
        }

        public Contact(string firstname, string lastname, string phone) {
            firstName = firstname;
            lastName = lastname;
            Phone = phone;
        }

        public override string ToString()
        {
            string output = String.Empty;
            output += String.Format("{0} {1}", lastName, firstName);
            output += String.Format("({0}),{1}-{2}",Phone.Substring(0,3),Phone.Substring(3,3),Phone.Substring(6,4));
            return output;
        }

    }//end class
}//end namespace
