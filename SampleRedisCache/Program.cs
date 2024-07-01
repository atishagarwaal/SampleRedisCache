using StackExchange.Redis;
using System;

class Program
{
    static void Main(string[] args)
    {
        //*******Uncomment these lines*******
        // Replace these values with your Azure Redis Cache connection details
        //string redisCacheName = "<your-redis-cache-name>";
        //string redisCacheKey = "<your-redis-cache-key>";
        //string redisCacheEndpoint = "<your-redis-cache-endpoint.redis.cache.windows.net>";

        // Create the connection to Azure Redis Cache
        var redisConnStr = $"{redisCacheName}.redis.cache.windows.net:6380,password={redisCacheKey},ssl=True,abortConnect=False";
        var redis = ConnectionMultiplexer.Connect(redisConnStr);

        // Get a reference to the Redis database
        var db = redis.GetDatabase();

        // Example: Set a key-value pair
        string key = "myKey";
        string value = "myValue";
        db.StringSet(key, value);

        // Example: Get a value by key
        string retrievedValue = db.StringGet(key);
        Console.WriteLine($"Value for key '{key}': {retrievedValue}");

        // Example: Remove a key
        db.KeyDelete(key);
        Console.WriteLine($"Key '{key}' deleted.");

        // Example: Check if a key exists
        bool keyExists = db.KeyExists(key);
        Console.WriteLine($"Does key '{key}' exist? {keyExists}");

        // Close the Redis connection (usually done at the end of your application)
        redis.Close();
    }
}
