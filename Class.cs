using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{   
    //init
         private void materialButton2_Click(object sender, EventArgs e)
        {
            PasswordValidation PassVal = new PasswordValidation();
            if (PassVal.Validation(textPassword1.Text, textPassword2.Text) == true)
            {
                MessageBox.Show("Пароль подошел", "Успех");
            }
        }
    //class validation
    class PasswordValidation
    {
        public bool Validation(string password, string password2)
        {
            var input = password;
            var input2 = password2;

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(input2))
            {
                MessageBox.Show("Поле с паролем пустое", "Ошибка");
                return false;
            }
            if (input != input2)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка");
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну строчную букву", "Ошибка");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву", "Ошибка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Пароль должен быть длиннее 6 символов", "Ошибка");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одно числовое значение", "Ошибка");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                MessageBox.Show("Пароль должен содержать хотя бы один спец. символ", "Ошибка");
                return false;
            }
            else
            {
                // MessageBox.Show("Пароль подошел","Успех");
                return true;
            }
        }
    }
}
