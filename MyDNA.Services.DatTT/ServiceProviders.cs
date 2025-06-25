using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDNA.Services.DatTT
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        ServiceDatTTService ServiceDatTTService { get; }
        IFeedBackRatingDatTTService FeedBackRatingDatTTService { get; }
    }
    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private IFeedBackRatingDatTTService _feedBackRatingDatTTService;
        private ServiceDatTTService _serviceDatTTService;

        public ServiceProviders() { }

        public SystemUserAccountService UserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }
        public IFeedBackRatingDatTTService FeedBackRatingDatTTService
        {
            get { return _feedBackRatingDatTTService ??= new FeedBackRatingDatTTService(); }
        }
        public ServiceDatTTService ServiceDatTTService
        {
            get { return _serviceDatTTService ??= new ServiceDatTTService(); }
        }
    }
}
