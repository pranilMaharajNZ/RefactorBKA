using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe
{
    public class ProductDataBuilder
    {
        private static IReadOnlyRepository<Lawnmower> _lawnMowerRepository;
        private static IReadOnlyRepository<PhoneCase> _phoneCaseRepository;
        private static IReadOnlyRepository<TShirt> _tShirtRepository;

        public ProductDataBuilder(IReadOnlyRepository<Lawnmower> lawnMowerRepository,
            IReadOnlyRepository<PhoneCase> phoneCaseRepository,
            IReadOnlyRepository<TShirt> tShirtRepository
            )
        {
            _lawnMowerRepository = lawnMowerRepository;
            _phoneCaseRepository = phoneCaseRepository;
            _tShirtRepository = tShirtRepository;
        }

        public ProductData GetProductList()
        {
            return new ProductData
            {
                LawnMowers = _lawnMowerRepository.GetAll(),
                PhoneCases = _phoneCaseRepository.GetAll(),
                TShirts = _tShirtRepository.GetAll()
            };
        }
    }
}
