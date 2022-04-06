using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using Moq;
using ProcessApplicationFormFunction.Database.Models;
using ProcessApplicationFormFunction.Extensions;
using ProcessApplicationFormFunction.Mappers;
using Xunit;

namespace ProcessApplicationForm.Test.MapperTests;

public class ApplicationMapperTests
{
    private readonly Mock<IMapper<StagingApplyingSchool, A2BApplicationApplyingSchool>> _mockApplyingSchoolMapper;
    private readonly Mock<IMapper<StagingKeyPerson, A2BApplicationKeyPerson>> _mockKeyPersonMapper;
    private readonly Fixture _fixture = new();

    public ApplicationMapperTests()
    {
        _mockApplyingSchoolMapper = new();
        _mockApplyingSchoolMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingApplyingSchool>>()))
            .Returns(new List<A2BApplicationApplyingSchool>());

        _mockKeyPersonMapper = new();
        _mockKeyPersonMapper
            .Setup(m => m.Map(It.IsAny<ICollection<StagingKeyPerson>>()))
            .Returns(new List<A2BApplicationKeyPerson>());
    }
    
    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplication_ShouldReturnCollectionOfTypeA2BApplication()
    {
        ApplicationMapper mapper = new(_mockApplyingSchoolMapper.Object, _mockKeyPersonMapper.Object);

        List<StagingApplication> source = new();

        var result = mapper.Map(source);

        result.Should().BeAssignableTo<IEnumerable<A2BApplication>>();
    }

    [Fact]
    public void Map_WhenGivenCollectionOfStagingApplication_ShouldReturnMappedCollectionOfA2BApplication()
    {
        var stagingApplication = _fixture.Create<StagingApplication>();
        
        A2BApplication expectedApplication = new()
        {
            ApplicationLeadAuthorId = stagingApplication.ApplicationLeadAuthorId,
            ApplicationLeadAuthorName = stagingApplication.ApplicationLeadAuthorName,
            ApplicationLeadEmail = stagingApplication.ApplicationLeadEmail,
            ApplicationRole = stagingApplication.ApplicationRole.ConvertApplicationRole(),
            ApplicationRoleOtherDescription = stagingApplication.ApplicationRoleOtherDescription,
            ApplicationStatusId = stagingApplication.ApplicationStatusId,
            ApplicationSubmitted = stagingApplication.ApplicationSubmitted,
            ApplicationType = stagingApplication.ApplicationType.ConvertApplicationType(),
            ApplicationVersion = stagingApplication.ApplicationVersion.ToString(),
            ChangesToLaGovernance = stagingApplication.ChangesToLaGovernance.ConvertDynamicsIntBool(),
            ChangesToLaGovernanceExplained = stagingApplication.ChangesToLaGovernanceExplained,
            ChangesToTrust = stagingApplication.ChangesToTrust.ConvertDynamicsIntBool(),
            ChangesToTrustExplained = stagingApplication.ChangesToTrustExplained,
            FormTrustGrowthPlansYesNo = stagingApplication.FormTrustGrowthPlansYesNo.ConvertDynamicsIntBool(),
            FormTrustImprovementApprovedSponsor = stagingApplication.FormTrustImprovementApprovedSponsor,
            FormTrustImprovementStrategy = stagingApplication.FormTrustImprovementStrategy,
            FormTrustImprovementSupport = stagingApplication.FormTrustImprovementSupport,
            FormTrustOpeningDate = stagingApplication.FormTrustOpeningDate,
            FormTrustPlanForGrowth = stagingApplication.FormTrustPlanForGrowth,
            FormTrustPlansForNoGrowth = stagingApplication.FormTrustPlansForNoGrowth,
            FormTrustProposedNameOfTrust = stagingApplication.FormTrustProposedNameOfTrust,
            FormTrustReasonApprovalToConvertAsSat = stagingApplication.FormTrustReasonApprovalToConvertAsSat.ConvertDynamicsIntBool(),
            FormTrustReasonApprovedPerson = stagingApplication.FormTrustReasonApprovedPerson,
            FormTrustReasonForming = stagingApplication.FormTrustReasonForming,
            FormTrustReasonFreedom = stagingApplication.FormTrustReasonFreedom,
            FormTrustReasonGeoAreas = stagingApplication.FormTrustReasonGeoAreas,
            FormTrustReasonImproveTeaching = stagingApplication.FormTrustReasonImproveTeaching,
            FormTrustReasonVision = stagingApplication.FormTrustReasonVision,
            Name = stagingApplication.Name,
            TrustApproverEmail = stagingApplication.TrustApproverEmail,
            TrustApproverName = stagingApplication.TrustApproverName,
            TrustId = stagingApplication.TrustId,
            ApplyingSchools = new List<A2BApplicationApplyingSchool>(),
            KeyPersons = new List<A2BApplicationKeyPerson>()            
        };
        List<StagingApplication> stagingApplications = new() { stagingApplication };
        List<A2BApplication> expectedApplications = new() { expectedApplication };

        ApplicationMapper mapper = new(_mockApplyingSchoolMapper.Object, _mockKeyPersonMapper.Object);
        var result = mapper.Map(stagingApplications);

        result.Should().BeEquivalentTo(expectedApplications);
    }
}