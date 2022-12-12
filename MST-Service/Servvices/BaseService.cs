using MST_Service.UnitOfWorks;

namespace MST_Service.Servvices
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
