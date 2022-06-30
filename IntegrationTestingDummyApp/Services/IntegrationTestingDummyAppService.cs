namespace IntegrationTestingDummyApp.Services
{
    public class IntegrationTestingDummyAppService
    {

        private readonly IDummyService _dummyService;
        public IntegrationTestingDummyAppService(IDummyService dummyService)
        {
            _dummyService = dummyService;
        }

        public int GetValue()
        {
            return _dummyService.GetValue();
        }
    }
}
