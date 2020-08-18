using Microsoft.Extensions.Options;
using Moq;

namespace JurosService.Api.UnitTests
{
    public static class OptionsHelper
    {
        public static IOptionsSnapshot<T> CreateOptionSnapshotMock<T>(T value)
            where T : class, new()
        {
            var mock = new Mock<IOptionsSnapshot<T>>();
            mock.Setup(m => m.Value).Returns(value);

            return mock.Object;
        }
    }
}
