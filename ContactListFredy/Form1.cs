using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactListFredy
{
    public partial class Form1 : Form
    {
        private Contact[] phonebook = new Contact[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void Write(Contact contact) {
            StreamWriter sw = new StreamWriter("contacts.txt");
            sw.WriteLine(phonebook.Length + 1);
            sw.WriteLine(contact.firstName);
            sw.WriteLine(contact.lastName);
            sw.WriteLine(contact.Phone);

            for (int i = 0; i < phonebook.Length; i++) {
                sw.WriteLine(phonebook[i].firstName);
                sw.WriteLine(phonebook[i].lastName);
                sw.WriteLine(phonebook[i].Phone);
            }

            sw.Close();
        }


        private void Read() {
            StreamReader sr = new StreamReader("contacts.txt");
            phonebook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for (int i=0; i < phonebook.Length; i++) {
                phonebook[i] = new Contact();
                phonebook[i].firstName = sr.ReadLine();
                phonebook[i].lastName = sr.ReadLine();
                phonebook[i].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display() {
            lstContact.Items.Clear();
            for (int i = 0; i < phonebook.Length; i++) {
                lstContact.Items.Add(phonebook[i].ToString());
            }
        }

        private void clearForm() {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.firstName = txtFirstName.Text;
            contact.lastName = txtLastName.Text;
            contact.Phone = txtPhone.Text;

            Write(contact);
            Read();
            bubbleSort();
            Display();
            clearForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            bubbleSort();
            Display();
        }

        private void bubbleSort() {
            Contact temp;
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < phonebook.Length - 1; i++) {
                    if (phonebook[i].lastName.CompareTo(phonebook[i+1].lastName) > 0) {
                        temp = phonebook[i];
                        phonebook[i] = phonebook[i + 1];
                        phonebook[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap == true);
        }
    }
}
