using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMemberships
{
    public class GetMembershipsQuery : IRequest<List<MembershipDto>>
    {
        public GetMembershipsQuery() { }
    }
}
