using PAW.Services.Models;

namespace PAW.Services
{
    public interface ITestService
    {
        Test CreateTest();
        string GetMeTheUtcDateTime();
    }

    public class TestService : ITestService
    {
        public Test CreateTest()
        {
            return new Test
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                Description = "Test",
            };
        }

        public string GetMeTheUtcDateTime() => DateTime.UtcNow.ToString();
    }
}
