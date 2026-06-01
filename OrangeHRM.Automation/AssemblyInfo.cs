using Xunit;

[assembly: CollectionBehavior(
    DisableTestParallelization = false,
    MaxParallelThreads = 6)]