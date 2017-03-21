# SSL Labs API client for .NET
This is an SSL Labs API client wrapper for [SSLLabs asssesment tool](https://www.ssllabs.com/), based on the official [SSL Labs API Documentation](https://github.com/ssllabs/ssllabs-scan/blob/master/ssllabs-api-docs-v3.md)

[![Generic Build](https://github.com/LordMike/MBW.Client.SslLabsLib/actions/workflows/dotnet.yml/badge.svg)](https://github.com/LordMike/MBW.Client.SslLabsLib/actions/workflows/dotnet.yml) [![Nuget](https://img.shields.io/nuget/v/SslLabsLib)](https://nuget.org/packages/SslLabsLib)


# Installation
The easiest way to get the library is to use Nuget. The library has been published [here](https://www.nuget.org/packages/SslLabsLib/), and is also available [at Github](https://github.com/LordMike/MBW.Client.SslLabsLib) in source form. The following Nuget command will fetch the package for you.

    Install-Package SslLabsLib

# Example usage
The SSL Labs API is built up around a polling method, where you regularly poll the API for the status on an ongoing assesment. An example client that fetches a result for Google.com is below:

    SslLabsClient client = new SslLabsClient();
    HostInfo analysis = await client.Analyze("google.com");

    Console.WriteLine("TLS Grade of Google.com");
    Console.WriteLine(analysis.Endpoints.First().Grade);

A simple client that will initiate a new scan, and poll for the results is below.

    SslLabsClient client = new SslLabsClient();
    TimeSpan waitTime = TimeSpan.FromSeconds(20);
    string target = "www.dr.dk";

    HostInfo analysis = await client.Analyze(target, startNew: true);
    while (analysis.Status != AnalysisStatus.READY)
    {
        Console.WriteLine($"Last status was {analysis.Status}, waiting {waitTime}");
        await Task.Delay(waitTime);

        // Note that Ssllabs tracks progress per endpoint that a domain resolves to
        analysis = await client.Analyze(target, all: AnalysisAll.WhenDone);
        Console.WriteLine($"Current status: {analysis.Status}, progresses: {string.Join(", ", analysis.Endpoints.Select(x => x.Progress + "%"))}");

        if (analysis.Endpoints.Select(s => s.Progress).Min() > 80)
            waitTime = TimeSpan.FromSeconds(5);
    }

    Console.WriteLine($"TLS Grade of {target}: {analysis.Endpoints.First().Grade}");
