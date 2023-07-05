using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeStores_CSHARPProject
{
    public static class Validator
    {
        //Error Message
        private static string title = "Entry Error";

        //getter and setter
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        //check if there is text in textbox
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //check if entered value in textbox is INT32
        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }
        //check if entered value in textbox is email or not.
        public static bool IsValidEmail(TextBox textBox)
        {
            if (textBox.Text.IndexOf("@") == -1 ||
                 textBox.Text.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox.Tag + " must be a valid email address.",
                    Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
