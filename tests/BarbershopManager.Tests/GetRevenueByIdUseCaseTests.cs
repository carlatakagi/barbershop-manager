using System;
using System.Threading.Tasks;
using AutoMapper;
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Communication.Responses;
using Braintree.Exceptions;

namespace GetRevenueByIdUseCaseTests
{
    public class GetRevenueByIdUseCaseTests
    {
        [Fact]
        public async Task Execute_WhenFound_ReturnsMappedResponse()
        {
            // Arrange
            var repoMock = new Mock<IRevenueRepository>();
            var id = Guid.NewGuid();
            var response = new ResponseRevenue
            {
                Id = id,
                Title = "Haircut",
                Description = "Test",
                Date = new DateTime(2025, 1, 1),
                Amount = 50m,
                PaymentType = BarbershopManager.BarbershopManager.Domain.Enum.PaymentType.Cash
            };

            repoMock.Setup(r => r.GetById(id)).ReturnsAsync(response);

            var useCase = new GetRevenueByIdUseCase(repoMock.Object);

            // Act
            var result = await useCase.Execute(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(response.Id);
            result.Title.Should().Be(response.Title);
            result.Amount.Should().Be(response.Amount);
            result.Date.Should().Be(response.Date);
            result.Description.Should().Be(response.Description);
            result.PaymentType.Should().Be(response.PaymentType);
        }

        [Fact]
        public async Task Execute_WhenNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var repoMock = new Mock<IRevenueRepository>();
            var id = Guid.NewGuid();

            repoMock.Setup(r => r.GetById(id)).ReturnsAsync((ResponseRevenue?)null);

            var useCase = new GetRevenueByIdUseCase(repoMock.Object);

            // Act
            var act = async () => await useCase.Execute(id);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(act);
        }
    }
}