using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMembership
{
    public class GetMembershipQueryHandler : IRequestHandler<GetMembershipQuery, MembershipDto>
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public GetMembershipQueryHandler(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository ?? throw new ArgumentNullException(nameof(membershipRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MembershipDto> Handle(GetMembershipQuery request, CancellationToken cancellationToken)
        {
            var membership = await _membershipRepository.GetByIdAsync(request.MembershipId);
            return _mapper.Map<MembershipDto>(membership);
        }
    }
}
