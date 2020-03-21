using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Threading.Tasks;


public class Program
{
    private const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=asyncstormalon;AccountKey=Ch8azSwLreZdUb2pR7rYW2f9Bei9qC+kUp9eZLy+Bhg4dkoVRhWSmCtd05V2hiU//uscbto/0vh9hAM90gnIXQ==;EndpointSuffix=core.windows.net";
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        QueueClient client = new QueueClient(storageConnectionString, queueName);
        await client.CreateAsync();

        Console.WriteLine($"---Account Metadata---");
        Console.WriteLine($"Account Uri:\t{client.Uri}");

        // ---Account Metadata-- -
        // Account Uri: https://asyncstormalon.queue.core.windows.net/messagequeue

        Console.WriteLine($"---Existing Messages---");

        int batchSize = 10;
        TimeSpan visibilityTimeout = TimeSpan.FromSeconds(2.5d);

        Response<QueueMessage[]> messages = await client.ReceiveMessagesAsync(batchSize, visibilityTimeout);
        foreach (QueueMessage message in messages?.Value)
        {
            Console.WriteLine($"[{message.MessageId}]\t{message.MessageText}");
            await client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }

        Console.WriteLine($"---New Messages---");

        string greeting = "Hi, Developer!";
        await client.SendMessageAsync(greeting);

        Console.WriteLine($"Sent Message:\t{greeting}");

    }
}

