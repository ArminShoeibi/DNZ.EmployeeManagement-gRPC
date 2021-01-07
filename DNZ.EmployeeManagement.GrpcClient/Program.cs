using DNZ.EmployeeManagement.GrpcServer.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace DNZ.EmployeeManagement.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001/");

            var client = new UserService.UserServiceClient(channel);

            CreateUserDto createUserDto = new()
            {
                FirstName = "Armin",
                LastName = "Shoeibi",
                Email = "rmin@cyberservices.com",
                NationalId = "0123456789",
                PhoneNumber = "09100159987",
            };

            CreateUserResultDto createUserResultDto = await client.CreateUserAsync(createUserDto);

            Console.Write(createUserResultDto.IsSucceeded);

        }
    }
}
