using Microsoft.AspNetCore.SignalR.Client;

namespace ExemploSignalR.Server
{
	public class ClienteStart
	{
		public async Task IniciarConexao()
		{
			const string url = "https://localhost:55822/chat";

			await using var connection = new HubConnectionBuilder()
				.WithUrl(url)
				.Build();

			await connection.StartAsync();

			await foreach (var date in connection.StreamAsync<DateTime>("Streaming"))
			{
				Console.WriteLine(date);
			}
		}
	}
}
