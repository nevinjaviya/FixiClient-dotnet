using System;
using System.Linq;
using System.Threading.Tasks;
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
  }
}