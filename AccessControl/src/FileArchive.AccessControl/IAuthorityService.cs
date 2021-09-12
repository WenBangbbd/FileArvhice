using FileArchive.AccessControl.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IAuthorityService
    {
        Task CreateAsync(Authority authority);
        Task<IEnumerable<Authority>> GetAuthoritiesAsync();
        Task<Authority> GetAuthorityAsync(string authorityCode);
    }
    public class AuthorityService : IAuthorityService
    {
        private readonly IAuthorityRepository _authorityRepository;

        public AuthorityService(IAuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
        }

        public async Task CreateAsync(Authority authority)
        {
            await _authorityRepository.InsertAsync(authority);
        }

        public async Task<IEnumerable<Authority>> GetAuthoritiesAsync()
        {
            return await _authorityRepository.FindAllAsync();
        }

        public async Task<Authority> GetAuthorityAsync(string authorityCode)
        {
            return await _authorityRepository.FindAsync(authorityCode);
        }
    }
}
