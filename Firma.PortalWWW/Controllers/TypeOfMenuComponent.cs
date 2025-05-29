using Firma.Data.Data;
using Firma.Interfaces.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class TypeOfMenuComponent : ViewComponent
    {
        private readonly ITypeOfService _typeOfService;
        public TypeOfMenuComponent(ITypeOfService typeOfService)
        {
            _typeOfService = typeOfService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("TypeOfMenuComponent", await _typeOfService.GetTypeOfs());
        }
    }
}
