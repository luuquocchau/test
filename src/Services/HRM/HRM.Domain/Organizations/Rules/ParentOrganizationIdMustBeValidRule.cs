using BuildingBlocks.SharedKernel;

namespace HRM.Domain.Organizations.Rules;

public sealed class ParentOrganizationIdMustBeValidRule : IBusinessRule
{
    private int _id;
    private int? _parentOrganizationId;
    private IOrganizationRepository _organizationRepository;

    internal ParentOrganizationIdMustBeValidRule(int id, int? parentOrganizationId, IOrganizationRepository organizationRepository)
    {
        _id = id;
        _parentOrganizationId = parentOrganizationId;
        _organizationRepository = organizationRepository;
    }


    public string Message => "Parent Organization Id must be valid";

    public bool IsBroken() => !_organizationRepository.CheckValidParentOrganizationId(_id, _parentOrganizationId);
}