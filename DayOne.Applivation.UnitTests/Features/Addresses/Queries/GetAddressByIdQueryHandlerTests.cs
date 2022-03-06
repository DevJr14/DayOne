using Application.Features.Addressess.Queries;
using Application.Interfaces;
using Moq;
using Shared.Responses.Address;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DayOne.Applivation.UnitTests.Features.Addresses.Queries
{
    public class GetAddressByIdQueryHandlerTests
    {
        [Fact]
        public async Task GetAddressByIdQueryHandler_AddressExists_ReturnsAddress()
        {
            #region Arrange          
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository(1);
            #endregion

            #region Act
            var handler = new GetAddressByIdQueryHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAddressByIdQuery() { Id = 1 }, CancellationToken.None);
            #endregion

            #region Assert
            result.Data.ShouldBeEquivalentTo(Address());
            result.Messages.Any().ShouldBeFalse();
            result.Succeeded.ShouldBeTrue();
            #endregion

            #region Core Setup
            static List<AddressResponse> Addresess()
            {
                return new List<AddressResponse>
                {
                    new AddressResponse{ Id= 1, Email = "Junior1@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 2, Email = "Junior2@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 3, Email = "Junior3@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 4, Email = "Junior4@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 5, Email = "Junior5@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 6, Email = "Junior6@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 7, Email = "Junior7@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"}
                };
            }
            static AddressResponse Address()
            {
                return new AddressResponse { Id = 1, Email = "Junior1@gmail.com", CellphoneNo = "029292", Street = "277 Bulang", Suburb = "Mamelodi East", City = "Pretoria", PostCode = "0122" };
            };

            static Mock<IAddressRepo> GetAddressRepository(int id)
            {             
                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAddressById(id)).ReturnsAsync(Addresess().Where(a => a.Id == id).FirstOrDefault());

                return mockAddressRepository;
            }
            #endregion
        }

        [Fact]
        public async Task GetAddressByIdQueryHandler_AddressNotExists_ReturnsResultDataNull()
        {
            #region Arrange          
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository(10);
            #endregion

            #region Act
            var handler = new GetAddressByIdQueryHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAddressByIdQuery() { Id = 10 }, CancellationToken.None);
            #endregion

            #region Assert
            result.Data.ShouldBeNull();
            result.Messages.ShouldNotBeNull();
            result.Succeeded.ShouldBeFalse();
            #endregion

            #region Core Setup
            static List<AddressResponse> Addresess()
            {
                return new List<AddressResponse>
                {
                    new AddressResponse{ Id= 1, Email = "Junior1@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 2, Email = "Junior2@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 3, Email = "Junior3@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 4, Email = "Junior4@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 5, Email = "Junior5@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 6, Email = "Junior6@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 7, Email = "Junior7@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"}
                };
            }

            static Mock<IAddressRepo> GetAddressRepository(int id)
            {
                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAddressById(id)).ReturnsAsync(Addresess().Where(a => a.Id == id).FirstOrDefault());

                return mockAddressRepository;
            }
            #endregion
        }
    }
}
