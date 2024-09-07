using System.ComponentModel.DataAnnotations;

namespace OturumAc.Models
{
    public class LoginModel
    {
        private string? _returnurl;

        [Required(ErrorMessage = "Ad gerekli.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnurl is null)
                    return "/";
                else
                    return _returnurl;
            }
            set
            {
                _returnurl = value;
            }
        }
    }
}
