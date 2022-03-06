using Application.Interfaces;
using Dapper;
using Infrastructure.Context;
using Shared.Responses.Address;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Infrastructure.Constants.StoredProcedures;

namespace Infrastructure.Repositories
{
    public class AddressRepo : IAddressRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(AddressResponse item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddressResponse>> GetAllAsync()
        {
            using var connection = _dbContext.CreateConnection();
            var addresses = await connection.QueryAsync<AddressResponse>(sql: AddressProcedures.GetAllAddresses, commandType: CommandType.StoredProcedure);
            return addresses == null ? new List<AddressResponse>() : addresses.ToList();
        }

        public async Task<AddressResponse> GetByIdAsync(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using var connection = _dbContext.CreateConnection();
            var address = await connection.QueryFirstOrDefaultAsync<AddressResponse>(sql: AddressProcedures.GetAddressById, param: parameter, commandType: CommandType.StoredProcedure);
            return address;
        }

        public Task<int> UpdateAsync(AddressResponse item)
        {
            throw new NotImplementedException();
        }
    }
}
