using AutoMapper;
using FileArchive.AccessControl;
using FileArchive.AccessControl.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace FileArchive.Application
{
    public class AccessProfile : Profile
    {
        public AccessProfile()
        {            
            CreateMap<UserInput, User>()
                .ForMember(des=>des.Roles,opt=>opt.Ignore());
            CreateMap<RoleInput, Role>();
            CreateMap<IUser, UserOutput>()
                .ForMember(des => des.Roles, opt => opt.MapFrom<UserOutputResolver>());
            CreateMap<IRole, RoleOutput>()
                .ForMember(des => des.Authorities, opt => opt.MapFrom<RoleOutputResolver>());
            CreateMap<AuthorityInput, Authority>();
            CreateMap<IAuthority, AuthorityOutput>();
        }
        public class UserOutputResolver :IValueResolver<IUser, UserOutput,IEnumerable<IRole>>
        {
            private readonly IMapper _mapper;

            public UserOutputResolver(IMapper mapper)
            {
                _mapper = mapper;
            }

            public IEnumerable<IRole> Resolve(IUser source, UserOutput destination, IEnumerable<IRole> destMember, ResolutionContext context)
            {
                return _mapper.Map<IEnumerable<RoleOutput>>(source.Roles);
            }
        }
        public class RoleOutputResolver : IValueResolver<IRole, RoleOutput, IEnumerable<IAuthority>>
        {
            private readonly IMapper _mapper;

            public RoleOutputResolver(IMapper mapper)
            {
                _mapper = mapper;
            }

            public IEnumerable<IAuthority> Resolve(IRole source, RoleOutput destination, IEnumerable<IAuthority> destMember, ResolutionContext context)
            {
                return _mapper.Map<IEnumerable<AuthorityOutput>>(source.Authorities);
            }
        }
    }
}
