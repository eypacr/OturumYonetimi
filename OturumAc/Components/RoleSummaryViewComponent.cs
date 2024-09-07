using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace OturumAc.Components
{
    public class RoleSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public RoleSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .AuthService
                .Roles.ToList()
                .Count()
                .ToString();
        }
    }
}
