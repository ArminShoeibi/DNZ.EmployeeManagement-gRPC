using DNZ.EmployeeManagement.GrpcServer.Data;
using DNZ.EmployeeManagement.GrpcServer.Domain;
using DNZ.EmployeeManagement.GrpcServer.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace DNZ.EmployeeManagement.GrpcServer.GrpcServices
{
    public class UserServiceGrpcServer : UserService.UserServiceBase
    {
        private readonly ApplicationContext _db;

        public UserServiceGrpcServer(ApplicationContext db)
        {
            _db = db;
        }
        public async override Task<CreateUserResultDto> CreateUser(CreateUserDto request, ServerCallContext context)
        {
            ApplicationUser applicationUser = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            };

            await _db.ApplicationUsers.AddAsync(applicationUser);
            await _db.SaveChangesAsync();

            return new CreateUserResultDto() { IsSucceeded = true };
        }
    }
}
