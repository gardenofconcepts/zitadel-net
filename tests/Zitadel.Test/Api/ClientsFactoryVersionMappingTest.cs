using AwesomeAssertions;

using Xunit;

using Zitadel.Api;
using Zitadel.Application.V2;

using AuthorizationServiceV2 = Zitadel.Authorization.V2.AuthorizationService;
using AuthorizationServiceV2Beta = Zitadel.Authorization.V2beta.AuthorizationService;
using InstanceServiceV2 = Zitadel.Instance.V2.InstanceService;
using InstanceServiceV2Beta = Zitadel.Instance.V2beta.InstanceService;
using InternalPermissionServiceV2 = Zitadel.InternalPermission.V2.InternalPermissionService;
using InternalPermissionServiceV2Beta = Zitadel.InternalPermission.V2beta.InternalPermissionService;
using ProjectServiceV2 = Zitadel.Project.V2.ProjectService;
using ProjectServiceV2Beta = Zitadel.Project.V2beta.ProjectService;

namespace Zitadel.Test.Api;

public class ClientsFactoryVersionMappingTest
{
    private static readonly Clients.Options LocalOptions = new("https://localhost", null);

    [Fact]
    public void Uses_Expected_Beta_And_Stable_Client_Mappings()
    {
        Clients.ProjectService(LocalOptions).Should().BeOfType<ProjectServiceV2Beta.ProjectServiceClient>();
        Clients.ProjectServiceV2(LocalOptions).Should().BeOfType<ProjectServiceV2.ProjectServiceClient>();

        Clients.AuthorizationService(LocalOptions).Should().BeOfType<AuthorizationServiceV2Beta.AuthorizationServiceClient>();
        Clients.AuthorizationServiceV2(LocalOptions).Should().BeOfType<AuthorizationServiceV2.AuthorizationServiceClient>();

        Clients.InstanceService(LocalOptions).Should().BeOfType<InstanceServiceV2Beta.InstanceServiceClient>();
        Clients.InstanceServiceV2(LocalOptions).Should().BeOfType<InstanceServiceV2.InstanceServiceClient>();

        Clients.InternalPermissionService(LocalOptions)
            .Should().BeOfType<InternalPermissionServiceV2Beta.InternalPermissionServiceClient>();
        Clients.InternalPermissionServiceV2(LocalOptions)
            .Should().BeOfType<InternalPermissionServiceV2.InternalPermissionServiceClient>();
    }

    [Fact]
    public void Uses_Stable_Application_Service_Client()
    {
        Clients.ApplicationService(LocalOptions).Should().BeOfType<ApplicationService.ApplicationServiceClient>();
    }
}
