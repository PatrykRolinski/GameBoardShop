using FluentValidation.TestHelper;
using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Data.Validators;
using GameBoardShop.ViewModels.ProducerModels;
using Moq;

namespace UnitTests.Validators;

public class NewProducerVMValidatorTests
{
    private readonly Mock<IProducerRepository> _mockRepository;
    private const string moreThan100chars = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean ma";

    public NewProducerVMValidatorTests()
    {
        _mockRepository = new Mock<IProducerRepository>();
    }

    public static IEnumerable<object[]> GetValidSampleData()
    {
        var list = new List<object>()
        {
            new NewProducerVM() {Name="Valid Name", Description="Valid Description", ImageURL="someURL"}
        };
        return list.Select(c => new object[] { c });
    }

    public static IEnumerable<object[]> GetInvalidSampleData()
    {
        var list = new List<object>()
        {
            //Name with too many char
            new NewProducerVM() {Name=moreThan100chars, Description="Valid Description", ImageURL="someURL"}
        };
        return list.Select(c => new object[] { c });
    }

    [Theory]
    [MemberData(nameof(GetValidSampleData))]
    public void Validate_ForCorrectVM_ReturnSuccess(NewProducerVM newProducerVM)
    {
        //arrange 
        var validator = new NewProducerVMValidator(_mockRepository.Object);

        //act
        var result = validator.TestValidate(newProducerVM);

        //assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [MemberData(nameof(GetInvalidSampleData))]
    public void Validate_ForIncorrectVM_ReturnFailure(NewProducerVM newProducerVM)
    {
        //arrange 
        var validator = new NewProducerVMValidator(_mockRepository.Object);

        //act
        var result = validator.TestValidate(newProducerVM);

        //assert
        result.ShouldHaveAnyValidationError();
    }
}
