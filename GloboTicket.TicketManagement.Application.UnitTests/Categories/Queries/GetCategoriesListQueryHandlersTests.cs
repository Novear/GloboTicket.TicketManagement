using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlersTests
    {
        private readonly IMapper _mapper;
        // here I am using the mock representaion here to provide an implementation for the IAsyncRepository
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        public GetCategoriesListQueryHandlersTests()
        {
            // I've written a static GetCategoryRepository on a RepositoryMocks class

            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            // here I am creating an instance of AutoMapper, passing it our MappingProfile class 
            // so it knows how to do the mappings 
            var configuartionProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuartionProvider.CreateMapper();
        }
        // it is attributed with the fact attribute meaning that this is a unit test
        //
        [Fact]
        public async Task GetCategoriesListTest()
        {
            // so now we are ready with the setup so now we can create the GetCategoriesListQueryHandler
            // passing it our mapper and CategoryRepository
            var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object, _mapper);
            // I can then call the Handle method which expects a GetCategoriesLidtQuery, that will then return
            // a list of CategoryListVM 
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            // assert that the returned object is of type List<CategoryListVm>
            result.ShouldBeOfType<List<CategoryListVm>>();
            // here we assert that the count of categories is 4
            result.Count.ShouldBe(4);
        }
    }
}
