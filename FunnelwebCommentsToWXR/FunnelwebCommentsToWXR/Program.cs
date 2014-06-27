using Domain.Configuration;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnelwebCommentsToWXR
{
    class Program
    {
        static void Main(string[] args)
        {
            MySettingsSection config = (MySettingsSection)System.Configuration.ConfigurationManager.GetSection("mySettings");

            string connectionString = config.FunnelwebConnectionString.Value;
            string rootUrl = config.RootUrl.Value;
            var repository = new SqlRepository(connectionString);

            var entries = repository.Entries.ToList();

            foreach (var entry in entries)
            {
                entry.Url = rootUrl + entry.Name;
                entry.Comments = repository.Comments.Where(x => x.EntryId == entry.Id).ToList();
            }

            var writer = new WxrWriter();
            writer.Write(entries, "funnelweb_comments_wxr.xml");
        }
    }
}
