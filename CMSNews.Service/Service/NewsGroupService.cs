using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSNews.Models.Context;
using CMSNews.Models.Models;
using CMSNews.Repository.Repository;

namespace CMSNews.Service.Service
{
    public class NewsGroupService : GenericService<NewsGroup>, INewsGroupService
    {
        private INewsGroupRepository _newsGroupRepository;
        public NewsGroupService(DbCMSNewsContext context) : base(context)
        {
            _newsGroupRepository=new NewsGroupRepository(context);
        }

        public int NextNewsGroupId()
        {
            int max = 1;
            var newsGroups = _newsGroupRepository.GetAll().ToList();
            if (newsGroups.Count > 0)
            {
                max=newsGroups.Max(t => t.NewsGroupId)+1;
            }
            return max;
        }
    }
}
