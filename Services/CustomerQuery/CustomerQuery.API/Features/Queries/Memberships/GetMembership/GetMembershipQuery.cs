using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMembership
{
    public class GetMembershipQuery : IRequest<MembershipDto>
    {
        public GetMembershipQuery(Guid membershipId) 
        { 
            MembershipId = membershipId;
        }

        public Guid MembershipId { get; set; }
    }
}
