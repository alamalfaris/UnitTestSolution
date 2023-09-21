using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Dns;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        private readonly IDns _dns;

        public NetworkServiceTests()
        {
            _dns = A.Fake<IDns>();
            _networkService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            bool sendDnsResult = true;

            // Mocking/Faking function SendDns()            
            A.CallTo(() => _dns.SendDns()).Returns(sendDnsResult);

            // Act
            var result = _networkService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping sent");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            

            // Act
            var result = _networkService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(1);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]
        public void NetworkService_LastPingSent_ReturnDate()
        {
            // Arrange

            // Act
            var result = _networkService.LastPingSent();

            //Assert
            result.Should().BeBefore(1.January(2024));
            result.Should().BeAfter(1.January(2020));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _networkService.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(expected.Ttl);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnObjects()
        {
            //Arrange
            
            //Act
            var result = _networkService.MostRecentPings();

            //Assert
            result.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.ContainItemsAssignableTo<PingOptions>();
        }
    }
}
