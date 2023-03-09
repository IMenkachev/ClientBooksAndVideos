using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMemberships
{
    public class GetMembershipsQueryHandler : IRequestHandler<GetMembershipsQuery, List<MembershipDto>>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public GetMembershipsQueryHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository ?? throw new ArgumentNullException(nameof(membershipRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MembershipDto>> Handle(GetMembershipsQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _membershipRepository.GetAllAsync();
            return _mapper.Map<List<MembershipDto>>(memberships);
        }
    }
}
