using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  public abstract class FixiClientTest
  {
    public FixiClient FixiClient { get; private set; }

    [TestCleanup]
    public void OnTestFinished()
    {
      FixiClient.Dispose();
    }

    [TestInitialize]
    public void OnTestStarting()
    {
      FixiClient = new FixiClient(Configuration.ApiKey, Configuration.ApiSecret, Configuration.BaseAddress);
    }
  }
}