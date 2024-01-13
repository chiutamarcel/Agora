using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.ViewModel
{
    public class UserSettingsVM
    {
        private string _Username;

        private string _UserPassword;
        private string _ConfirmUserPassword;

        private string _UserEmail;

        private System.DateTime _Birthdate;

        public UserSettingsVM(User user)
        {
            _Username = user.Username;
            _UserPassword = user.UserPassword;
            _ConfirmUserPassword = "";
            _UserEmail = user.UserEmail;
            _Birthdate = user.Birthdate;
        }

        public static explicit operator User(UserSettingsVM userSettingsVM)
        {
            return new User(userSettingsVM._Username, userSettingsVM._UserPassword, userSettingsVM._UserEmail, userSettingsVM._Birthdate);
        }
    }
}
