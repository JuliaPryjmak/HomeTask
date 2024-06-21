using ApiProject.Initialization;
using ApiProject.Requests;
using System.Net;

namespace Task3.Tests
{
    [TestFixture]
    public class FailedLoginTests : ApiTrackingInitialization
    {
        // We need to make sure that we have at least two test users with different failed attempt

        // Case: All values are added
        [Test]
        public void GetUsersWithFailedLoginAttempt200AllValuesAreAdded()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(Configuration.Username, 1, 1);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 1, "There are no users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(2));
        }

        // Case: Null value for All parameters
        [Test]
        public void GetUsersWithFailedLoginAttempt200()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(null, null, null);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count >= 1, "There are no users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(2));
        }

        // Case: Null only for Username parameter
        // Expected Result: Api works if Username is null + it works if there are less than 5 records in response (althought fetchLimit is 5)
        [Test]
        public void GetUsersWithFailedLoginAttempt200NullUsername()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(null, 1, 5);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 2, "There are not such amount of users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(2));
            Assert.That(response.HttpContentObject[1].Username, Is.EqualTo(Configuration.Username2));
            Assert.That(response.HttpContentObject[1].FailedAttemptCount, Is.EqualTo(4));
        }

        // Case: Null only for Count parameter
        // Expected Result: Api works if FailCount is null + it works and returns empty list when fetch limit is 0
        [Test]
        public void GetUsersWithFailedLoginAttempt200NullFailCount()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(Configuration.Username, null, 0);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 0, "There are more than 0 results in Response.");
        }

        // Case: Null only for FetchLimit parameter
        // Expected Result: Api works if FetchLimit is null + it works with 0 value for FailCount
        [Test]
        public void GetUsersWithFailedLoginAttempt200NullFetchLimit()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(Configuration.Username, 0, null);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 2, "There are not such amount of users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(2));
            Assert.That(response.HttpContentObject[1].Username, Is.EqualTo(Configuration.Username2));
            Assert.That(response.HttpContentObject[1].FailedAttemptCount, Is.EqualTo(4));
        }

        // Case: Combination of null for FailCount and FetchLimit
        // Expected Result: Api works with combination of null for two fields + To see all users
        [Test]
        public void GetUsersWithFailedLoginAttempt200OnlyUsernameAvailbale()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(Configuration.Username, null, null);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 2, "There are not such amount of users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(2));
            Assert.That(response.HttpContentObject[1].Username, Is.EqualTo(Configuration.Username2));
            Assert.That(response.HttpContentObject[1].FailedAttemptCount, Is.EqualTo(4));
        }

        // Case: Combination of null for Username and FetchLimit
        // Expected Result: Api works with combination of null for two fields + To see all users that have fail count more than 2
        [Test]
        public void GetUsersWithFailedLoginAttempt200OnlyFailCountAvailbale()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(null, 2, null);

            // Assert
            Assert.IsTrue(response.HttpContentObject.Count == 1, "There are not such amount of users with Failed login attemt.");
            Assert.That(response.HttpContentObject[0].Username, Is.EqualTo(Configuration.Username2));
            Assert.That(response.HttpContentObject[0].FailedAttemptCount, Is.EqualTo(4));
        }

        // Case: Combination of null for Username and FailCount
        // Expected Result: Api works with combination of null for two fields + To see 400 response/api works with random result
        [Test]
        public void GetUsersWithFailedLoginAttempt400OnlyFetchLimitAvailbale()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal(null, null, 1, statusCode: HttpStatusCode.BadRequest);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("There are more than 1 returned result."));


            // or if it's a positive case for our application and it returns value


            // Act
            var response2 = TrackingRequests.GetLoginFailTotal(null, null, 1);

            // Assert
            Assert.IsTrue(response2.HttpContentObject.Count == 1, "There are not such amount of users with Failed login attemt.");
            Assert.IsNotNull(response2.HttpContentObject[0].Username, "The fields is null.");
            Assert.IsNotNull(response2.HttpContentObject[0].FailedAttemptCount, "The fields is null.");
        }

        // Case: User doesn't exist
        [Test]
        public void GetUsersWithFailedLoginAttempt404NotExistingUser()
        {
            // Act
            var response = TrackingRequests.GetLoginFailTotal("WrongUserName", 1, 1, statusCode: HttpStatusCode.NotFound);

            // Assert
            Assert.That(response.HttpContent, Is.EqualTo("There are not such Username in database."));
        }
    }
}