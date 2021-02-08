using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch08
{
    static class Program
    {
        static void Main()
        {
            List<string> list = new();
            ImmutableList<string> immutableList = ImmutableList.Create<string>();
            ConcurrentStack<string> concurrentStack = new();

            string name = "Samantha Jones";
            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - lengthOfFirst - 1;
            string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);
            string lastName = name.Substring(startIndex: name.Length - lengthOfLast);

            WriteLine($"First name: {firstName}, Last name: {lastName}");
            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];
            WriteLine("First name: {0}, Last name: {1}", arg0: firstNameSpan.ToString(), arg1: lastNameSpan.ToString());

            Write("Enter a valid web address: ");
            string url = ReadLine() ?? "https://world.episerver.com/cms/?q=pagetype";
            var uri = new Uri(url);

            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }

            try
            {
                var ping = new Ping();
                WriteLine("Pinging server. Please wait...");
                PingReply reply = ping.Send(uri.Host);
                WriteLine($"{uri.Host} was pinged and replied: {reply.Status}.");
                if (reply.Status == IPStatus.Success)
                {
                    WriteLine("Reply from {0} took {1:N0}ms",
                        reply.Address, reply.RoundtripTime);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
            }

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                WriteLine($@"{nameof(drive.Name)} {drive.Name}
    {nameof(drive.DriveFormat)} {drive.DriveFormat}
    {nameof(drive.DriveType)} {drive.DriveType}
    {nameof(drive.IsReady)} {drive.IsReady}
    {nameof(drive.RootDirectory)} {drive.RootDirectory}
    {nameof(drive.TotalSize)} {drive.TotalSize}
    {nameof(drive.VolumeLabel)} {drive.VolumeLabel}
    {nameof(drive.AvailableFreeSpace)} {drive.AvailableFreeSpace}
    {nameof(drive.TotalFreeSpace)} {drive.TotalFreeSpace}");
            }
        }
    }
}