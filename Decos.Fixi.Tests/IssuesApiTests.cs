using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Decos.Fixi.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public class IssuesApiTests : FixiClientTest
  {
    [DataTestMethod]
    [DataRow(new[] { Status.Reported, Status.InProgress })]
    [DataRow(new[] { Status.InProgress, Status.Forwarded })]
    [DataRow(new[] { Status.Denied, Status.Handled })]
    public async Task IssuesReturnedHaveRequestedStatusesOnly(Status[] status)
    {
      var issues = await FixiClient.Issues.FindAsync(status: status, count: 200);

      Assert.That.All(issues.Results, x => status.Contains(x.Status));
    }

    [TestMethod]
    public async Task AllIssuesAreReturnedWhenFilteringOnAllStatuses()
    {
      var statusFilter = (Status[])Enum.GetValues(typeof(Status));

      var issues = await FixiClient.Issues.FindAsync(status: statusFilter, count: 0);

      var allIssues = await FixiClient.Issues.FindAsync(count: 0);
      Assert.AreEqual(allIssues.Count, issues.Count);
    }

    [TestMethod]
    public async Task IssuesReturnedAreWithinDateRange()
    {
      var dateStart = DateTimeOffset.Now.AddDays(-14);
      var dateEnd = dateStart.AddDays(7);
      var issues = await FixiClient.Issues.FindAsync(from: dateStart, to: dateEnd);

      Assert.That.All(issues.Results, x => x.Created >= dateStart && x.Created <= dateEnd);
    }

    [TestMethod]
    public async Task NoIssuesAreReturnedWhenGettingZeroIssues()
    {
      var issues = await FixiClient.Issues.FindAsync(count: 0);

      Assert.AreEqual(0, issues.Results.Count);
    }

    [TestMethod]
    public async Task TotalCountIsReturnedWhenGettingZeroIssues()
    {
      var issues = await FixiClient.Issues.FindAsync(count: 0);

      Assert.IsTrue(issues.Count > 0);
    }

    [TestMethod]
    public async Task MapIssuesAreReturnedWhenSpecifyingBounds()
    {
      var issues = await FixiClient.Issues.GetMapIssuesAsync(89.9, 179.9, -89.9, -179.9);

      Assert.IsTrue(issues.Results.Count > 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ApiException), AllowDerivedTypes = true)]
    public async Task TeamIssuesFailsWhenNotLoggedIn()
    {
      var issues = await FixiClient.Issues.GetTeamIssuesAsync();
    }

    [TestMethod]
    public async Task NearbyIssuesAreNearSpecifiedLocation()
    {
      const double lat = 52.215191;
      const double lng = 4.427408;

      var issues = await FixiClient.Issues.GetNearbyIssuesAsync(lat, lng, 100);

      foreach (var issue in issues.Results)
      {
        Assert.AreEqual(lat, issue.Location.Latitude, 0.01);
        Assert.AreEqual(lng, issue.Location.Longitude, 0.01);
      }
    }

    [TestMethod]
    public async Task ExportIssuesWritesResultToStream()
    {
      using (var stream = new MemoryStream())
      {
        await FixiClient.Issues.ExportToStreamAsync(stream);

        Assert.IsTrue(stream.Length > 0);
      }
    }

    [TestMethod]
    [ExpectedException(typeof(ApiException), AllowDerivedTypes = true)]
    public async Task ExportTeamIssuesFailsWhenNotLoggedIn()
    {
      using (var stream = new MemoryStream())
      {
        await FixiClient.Issues.ExportTeamIssuesToStreamAsync(stream);

        Assert.Fail();
      }
    }

    [TestMethod]
    [ExpectedException(typeof(ApiException))]
    public async Task CreateIssueFailsWithoutLocation()
    {
      var issue = await FixiClient.Issues.CreateAsync(new IssueData
      {
        Location = null
      });
    }

    [TestMethod]
    public async Task CreatedIssueCanBeFoundUpdatedAndDeleted()
    {
      var regionName = Parameter("region") ?? "decos";
      var categoryName = Parameter("category");


      var newIssue = await FixiClient.Issues.CreateAsync(new IssueData
      {
        Description = "Issue created for Fixi Client test " + nameof(CreatedIssueCanBeFoundUpdatedAndDeleted) + ". This issue will be updated and deleted shortly. If the issue is not deleted shortly after creation, the test will have failed.",
        Location = new Point(52.215191, 4.427408),
        Address = "Huygensstraat 30, 2201 DK Noordwijk",
        Region = regionName,
        Category = categoryName,
        ReportedBy = new Person
        {
          Name = "Automated Test",
          EmailAddress = "info@example.com"
        }
      });

      Assert.IsNotNull(newIssue, "Created issue should be returned.");
      Assert.IsNotNull(newIssue.ID, "Created issue should have an automatically assigned ID.");

      var issue = await FixiClient.Issues.GetAsync(newIssue.ID);
      Assert.AreEqual(DateTime.Today, newIssue.Created.Value.Date);

      const string source = "test";
      var updatedIssue = await FixiClient.Issues.UpdateAsync(issue.ID, new IssueData
      {
        Source = source
      });
      Assert.AreEqual(source, updatedIssue.Source);
      Assert.AreEqual(DateTime.Today, updatedIssue.Modified.Value.Date);

      await FixiClient.Issues.DeleteIssueAsync(updatedIssue.ID);
    }

    [TestMethod]
    public async Task GetIssueFailsWithoutID()
    {
      try
      {
        await FixiClient.Issues.GetAsync(null);
      }
      catch (ArgumentNullException ex)
      {
        var methodInfo = FixiClient.Issues.GetType().GetMethod(nameof(IssuesApi.GetAsync));
        var idParameter = methodInfo.GetParameters()[0].Name;
        if (ex.ParamName != idParameter)
          throw new AssertFailedException($"The name of the parameter that caused the ArgumentNullExpection does not match. Expected: <{idParameter}>. Actual: <{ex.ParamName}>.", ex);
      }
    }

    [TestMethod]
    public async Task DeleteIssueFailsWithoutID()
    {
      try
      {
        await FixiClient.Issues.DeleteIssueAsync(null);
      }
      catch (ArgumentNullException ex)
      {
        var methodInfo = FixiClient.Issues.GetType().GetMethod(nameof(IssuesApi.DeleteIssueAsync));
        var idParameter = methodInfo.GetParameters()[0].Name;
        if (ex.ParamName != idParameter)
          throw new AssertFailedException($"The name of the parameter that caused the ArgumentNullExpection does not match. Expected: <{idParameter}>. Actual: <{ex.ParamName}>.", ex);
      }
    }

    [TestMethod]
    public async Task UpdateIssueFailsWithoutID()
    {
      try
      {
        await FixiClient.Issues.UpdateAsync(null, new IssueData());
      }
      catch (ArgumentNullException ex)
      {
        var methodInfo = FixiClient.Issues.GetType().GetMethod(nameof(IssuesApi.DeleteIssueAsync));
        var idParameter = methodInfo.GetParameters()[0].Name;
        if (ex.ParamName != idParameter)
          throw new AssertFailedException($"The name of the parameter that caused the ArgumentNullExpection does not match. Expected: <{idParameter}>. Actual: <{ex.ParamName}>.", ex);
      }
    }
  }
}