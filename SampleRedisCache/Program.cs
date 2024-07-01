using StackExchange.Redis;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Replace these values with your Azure Redis Cache connection details
        string redisCacheName = "myredistrial";
        string redisCacheKey = "YraG6KLKTXWgNNZgitRjkRduyamZ3dJR8AzCaPPUSX4=";
        string redisCacheEndpoint = "myredistrial.redis.cache.windows.net";

        // Create the connection to Azure Redis Cache
        var redisConnStr = $"{redisCacheName}.redis.cache.windows.net:6380,password={redisCacheKey},ssl=True,abortConnect=False";
        var redis = ConnectionMultiplexer.Connect(redisConnStr);

        // Get a reference to the Redis database
        var db = redis.GetDatabase();

        // Example: Set a key-value pair
        string key = "mydbpassword";
        string value = "Pass@word123";
        db.StringSet(key, value);

        // Example: Check if a key exists
        bool keyExists = db.KeyExists(key);
        Console.WriteLine($"Does key '{key}' exist? {keyExists}");

        // Example: Get a value by key
        string retrievedValue = db.StringGet(key);
        Console.WriteLine($"Value for key '{key}': {retrievedValue}");

        // Example: Remove a key
        db.KeyDelete(key);
        Console.WriteLine($"Key '{key}' deleted.");

        // Close the Redis connection (usually done at the end of your application)
        redis.Close();

    }
}
