﻿using System;

namespace redis4net.Redis
{
	using System.Threading;

	public class ConnectionFactory : IConnectionFactory
	{
		private static readonly object Lock = new object();

		private readonly string _hostname;
		private readonly string _password;
		private readonly int _portNumber;
		private readonly bool _enableSSL;
		private readonly int _failedConnectionRetryTimeoutInSeconds;
		private readonly string _listName;
		private readonly IConnection _connection;

		public ConnectionFactory(IConnection connection, string hostName, int portNumber, string password, bool enableSSL, int failedConnectionRetryTimeoutInSeconds, string listName)
		{
			_connection = connection;

			_hostname = hostName;
			_portNumber = portNumber;
			_password = password;
			_enableSSL = enableSSL;
			_failedConnectionRetryTimeoutInSeconds = failedConnectionRetryTimeoutInSeconds;
			_listName = listName;
		}

		public IConnection GetConnection()
		{
			InitializeConnection();
			return _connection;
		}

		private void InitializeConnection()
		{
			if (_connection.IsOpen())
			{
				return;
			}

			lock (Lock)
			{
				try
				{
					OpenConnection();

					if (!_connection.IsOpen())
					{
						Thread.Sleep(TimeSpan.FromSeconds(_failedConnectionRetryTimeoutInSeconds));
						OpenConnection();
					}
				}
				catch
				{
					// Nothing to do if this fails
				}
			}
		}

		private void OpenConnection()
		{
			if (!_connection.IsOpen())
			{
				_connection.Open(_hostname, _portNumber, _password, _enableSSL, _listName);
			}
		}
	}
}
