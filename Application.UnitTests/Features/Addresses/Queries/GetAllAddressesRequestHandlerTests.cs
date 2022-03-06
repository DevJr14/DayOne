using Application.Features.Addressess.Queries;
using Application.Interfaces;
using Moq;
using Shared.Responses.Address;
using Shared.Wrappers;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.Addresses.Queries
{
    public class GetAllAddressesRequestHandlerTests
    {
        [Fact]
        public async Task GetAllAddressesRequestHandler_ListOfAddresses_ReturnsResultDataWithListOfAddresses()
        {
            //Arrange
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository();

            //Act
            var handler = new GetAllAddressesRequestHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAllAddressesRequest(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Result<List<AddressResponse>>>();

            #region Core Setup
            static Mock<IAddressRepo> GetAddressRepository()
            {
                var addreses = new List<AddressResponse>
                {
                    new AddressResponse{ Id= 1, Email = "Junior1@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 2, Email = "Junior2@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 3, Email = "Junior3@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 4, Email = "Junior4@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 5, Email = "Junior5@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 6, Email = "Junior6@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 7, Email = "Junior7@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 8, Email = "Junior8@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 9, Email = "Junior9@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 10, Email = "Junior10@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 11, Email = "Junior11@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 12, Email = "Junior12@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 13, Email = "Junior12@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                };

                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(addreses);

                return mockAddressRepository;
            }
            #endregion
        }

        [Fact]
        public async Task GetAllAddressesRequestHandler_EmptyAddresses_ReturnsResultDataWithNull()
        {
            //Arrange
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository();

            //Act
            var handler = new GetAllAddressesRequestHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAllAddressesRequest(), CancellationToken.None);

            //Assert
            result.Data.ShouldBeNull();

            #region Core Setup
            static Mock<IAddressRepo> GetAddressRepository()
            {
                var addreses = new List<AddressResponse>();

                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<AddressResponse>());

                return mockAddressRepository;
            }
            #endregion
        }

        [Fact]
        public async Task GetAllAddressesRequestHandler_ListOfAddresses_ReturnsCorrectCountOfAddresses()
        {
            //Arrange
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository();

            //Act
            var handler = new GetAllAddressesRequestHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAllAddressesRequest(), CancellationToken.None);

            //Assert
            result.Data.Count.ShouldBe(7);

            #region Core Setup
            static Mock<IAddressRepo> GetAddressRepository()
            {
                var addreses = new List<AddressResponse>
                {
                    new AddressResponse{ Id= 1, Email = "Junior1@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 2, Email = "Junior2@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 3, Email = "Junior3@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 4, Email = "Junior4@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 5, Email = "Junior5@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 6, Email = "Junior6@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 7, Email = "Junior7@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"}
                };

                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(addreses);

                return mockAddressRepository;
            }
            #endregion
        }

        [Fact]
        public async Task GetAllAddressesRequestHandler_EmptyAddresses_ReturnsResultNoAddressFoundMessage()
        {
            //Arrange
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository();

            //Act
            var handler = new GetAllAddressesRequestHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAllAddressesRequest(), CancellationToken.None);

            //Assert
            result.Messages[0].ShouldBe("No Addresses Found.");

            #region Core Setup
            static Mock<IAddressRepo> GetAddressRepository()
            {
                var addreses = new List<AddressResponse>();

                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<AddressResponse>());

                return mockAddressRepository;
            }
            #endregion
        }

        [Fact]
        public async Task GetAllAddressRequestHandler_ListOfAddresses_ReturnsResultDataWithAddresses()
        {
            //Arrange
            Mock<IAddressRepo> mockAddressRepository = GetAddressRepository();

            //Act
            var handler = new GetAllAddressesRequestHandler(mockAddressRepository.Object);
            var result = await handler.Handle(new GetAllAddressesRequest(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Result<List<AddressResponse>>>();
            #region Core Setup
            static Mock<IAddressRepo> GetAddressRepository()
            {
                var addreses = new List<AddressResponse>
                {
                    new AddressResponse{ Id= 1, Email = "Junior1@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 2, Email = "Junior2@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 3, Email = "Junior3@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 4, Email = "Junior4@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 5, Email = "Junior5@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 6, Email = "Junior6@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 7, Email = "Junior7@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 8, Email = "Junior8@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 9, Email = "Junior9@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 10, Email = "Junior10@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 11, Email = "Junior11@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 12, Email = "Junior12@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                    new AddressResponse{ Id= 13, Email = "Junior12@gmail.com", CellphoneNo = "029292",Street="277 Bulang", Suburb ="Mamelodi East", City = "Pretoria", PostCode ="0122"},
                };

                var mockAddressRepository = new Mock<IAddressRepo>();

                mockAddressRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(addreses);

                return mockAddressRepository;
            }
            #endregion
        }
    }
}
