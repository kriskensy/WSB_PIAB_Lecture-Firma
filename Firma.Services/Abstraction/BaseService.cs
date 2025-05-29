using Firma.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.Abstraction
{
    //to jest tylko klasa do dziedziczenia. nie mozna tworzyc obiektow tej klasy
    public abstract class BaseService
    {
        protected readonly FirmaContext _context;
        //protected readonly IServiceProvider serviceProvider; 
        //protected readonly Lazy uzytkownik; 
        //protected readonly Lazy cacheProvider; 
        //protected readonly Lazy dapperProvider; 
        //protected readonly Lazy configuration; 
        //protected readonly Lazy wyjatekObslugaService;
        public BaseService(FirmaContext context) 
        {
            _context = context; 
        }
    }
}
