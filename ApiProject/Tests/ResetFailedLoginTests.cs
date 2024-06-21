using ApiProject.Initialization;
using ApiProject.Models.Serialize;
using System.Net;

namespace ApiProject.Tests
{
    [TestFixture]
    public class ResetFailedLoginTests : ApiTrackingInitialization
    {
        [Test]
        public void PutResetLoginFailTotal200()
        {
            // Arrange
            var requestBody = RequestBuilder.ResetLoginFailBody(Configuration.Username);

            // Act
            var response = TrackingRequests.PutResetLoginFailTotal(requestBody);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("true"));
        }

        [Test]
        public void PutResetLoginFailTotal404NotExistingUsername()
        {
            // Arrange
            var requestBody = RequestBuilder.ResetLoginFailBody("WrongUserName");

            // Act
            var response = TrackingRequests.PutResetLoginFailTotal(requestBody, statusCode: HttpStatusCode.NotFound);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("This user doesn't exist."));
        }

        [Test]
        public void PutResetLoginFailTotal400EmptyUsername()
        {
            // Arrange
            var requestBody = RequestBuilder.ResetLoginFailBody("");

            // Act
            var response = TrackingRequests.PutResetLoginFailTotal(requestBody, statusCode: HttpStatusCode.BadRequest);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("The username field can not be empty or null."));
        }

        [Test]
        public void PutResetLoginFailTotal400NullUsername()
        {
            // Arrange
            var requestBody = RequestBuilder.ResetLoginFailBody(null);

            // Act
            var response = TrackingRequests.PutResetLoginFailTotal(requestBody, statusCode: HttpStatusCode.BadRequest);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("The username field can not be empty or null."));
        }

        [Test]
        public void PutResetLoginFailTotal400NoBody()
        {
            // Arrange
            var requestBody = new SResetLoginFailTotal() { };

            // Act
            var response = TrackingRequests.PutResetLoginFailTotal(requestBody, statusCode: HttpStatusCode.BadRequest);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("There is no body in request."));
        }
    }
}
