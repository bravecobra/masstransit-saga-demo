﻿using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MassTransit.Saga.Demo.TripService.Tests.Logging;

internal sealed class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly LoggerExternalScopeProvider _scopeProvider = new();

    public XUnitLoggerProvider(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new XUnitLogger(_testOutputHelper, _scopeProvider, categoryName);
    }

    public void Dispose()
    {
    }
}