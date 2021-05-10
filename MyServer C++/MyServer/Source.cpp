#pragma comment(lib, "Ws2_32.lib")
#include <WinSock2.h>
#include <iostream>
#include <Ws2tcpip.h>

SOCKET Connect;
SOCKET* Connections;
SOCKET Listen;

int ClientCount = 0;

void SendMessageToClient(int ID)
{
	setlocale(LC_ALL, "");
	char* buffer;
	for (; ; Sleep(750))
	{
		buffer = new char[1024];
		memset(buffer, 0, sizeof(buffer)); //заполняет буфер символами "0"

		if (recv(Connections[ID], buffer, 1024, NULL))
		{
			printf("%s", buffer);
			for (int i = 0; i <= ClientCount; i++) //Отправка каждому подключенному клиенту
			{
				send(Connections[i], buffer, strlen(buffer), NULL);
			}
		}
	}
	free(buffer);
}

int main()
{
	setlocale(LC_ALL, "");
	WSAData data;
	WORD version = MAKEWORD(2, 2);
	int res = WSAStartup(version, &data); // инициализация сокетов

	if (res != 0)
	{
		return 0;
	}

	struct addrinfo hints;
	struct addrinfo* result;

	// инициализация сокетов и пользователей
	Connections = (SOCKET*)calloc(64, sizeof(SOCKET));

	ZeroMemory(&hints, sizeof(hints));

	// настройка сокетов
	hints.ai_family = AF_INET;
	hints.ai_flags = AI_PASSIVE;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	getaddrinfo(NULL, "5919", &hints, &result); // информация о сервере

	Listen = socket(result->ai_family, result->ai_socktype, result->ai_protocol);

	// запуск серевера и макс. количество пользователей
	bind(Listen, result->ai_addr, result->ai_addrlen);
	listen(Listen, SOMAXCONN);

	freeaddrinfo(result);

	printf("Server started successfully...\n");
	char m_connect[] = "Connected...\n";

	// обработка клиентов
	for (;; Sleep(75))
	{
		if (Connect = accept(Listen, NULL, NULL))
		{
			printf("Client connected...\n"); // клиент подключился
			Connections[ClientCount] = Connect;
			send(Connections[ClientCount], m_connect, strlen(m_connect), NULL); // сообщение об успешном подключении
			ClientCount++; // количество пользователей +1
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)SendMessageToClient, (LPVOID)(ClientCount - 1), NULL, NULL);
		}
	}
	return 1;
}