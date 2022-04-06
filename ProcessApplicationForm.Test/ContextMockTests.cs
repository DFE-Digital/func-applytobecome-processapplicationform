using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProcessApplicationFormFunction.Database;
using ProcessApplicationFormFunction.Database.Models;
using Xunit;

namespace ProcessApplicationForm.Test;

public class ContextMockTests
{
    [Fact]
    public void Test1()
    {
        var mockContext = new Mock<SipDbContext>();

        var application = new A2BApplication();

        var dynamicsApplicationId = Guid.NewGuid();
        var dynamicsApplyingSchoolId = Guid.NewGuid();
        
       


        mockContext.SetupGet(x => x.DynamicsApplications).Returns()

    }
}