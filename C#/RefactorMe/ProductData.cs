using RefactorMe.DontRefactor.Models;
using System.Linq;

namespace RefactorMe
{
    public class ProductData
    {
        public IQueryable<Lawnmower> LawnMowers { get; set; }
        public IQueryable<TShirt> TShirts { get; set; }
        public IQueryable<PhoneCase> PhoneCases { get; set; }
    }
}
