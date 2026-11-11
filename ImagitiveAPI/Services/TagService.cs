using ImagitiveAPI.Data;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class TagService : ITagService
    {
        private readonly AppDBContext _context;
        public TagService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<TagModel>?> GetAllTagsAsync()
        {
            return await _context.Tags
                .Select(t => new TagModel
                {
                    TagId = t.TagId,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
