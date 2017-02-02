using System;
using System.Threading.Tasks;

namespace redis4net.Redis
{
	using StackExchange.Redis;

	public class Connection : IConnection, IDisposable
	{
		private string _listName;
		private ConnectionMultiplexer redis;

		public void Open(string hostname, int port, string password, bool enableSSL, string listName)
		{
			_listName = listName;
			var redisConfigOptions = new ConfigurationOptions
			{
				Ssl = enableSSL,
				Password = password,
				EndPoints = {
					{ hostname + ":" + port }
				}
			};
			redis = ConnectionMultiplexer.Connect(redisConfigOptions);
		}

		public bool IsOpen()
		{
			return redis != null;
		}

		public Task<long> AddToList(string content)
		{
			var database = redis.GetDatabase();
			return database.ListRightPushAsync(_listName, new RedisValue[] { content });
		}

		public void Dispose()
		{
			if (redis == null)
			{
				return;
			}

			redis.Close(false);
			redis.Dispose();
		}
	}
}
