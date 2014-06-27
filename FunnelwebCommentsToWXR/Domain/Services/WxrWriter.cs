using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class WxrWriter
    {
        public void Write(List<Entry> entries, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                writer.WriteLine("<rss version=\"2.0\" xmlns:content=\"http://purl.org/rss/1.0/modules/content/\" xmlns:dsq=\"http://www.disqus.com/\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:wp=\"http://wordpress.org/export/1.0/\">");
                writer.WriteLine("<channel>");

                foreach (var entry in entries)
                {
                    writer.WriteLine("<item>");
                    writer.WriteLine("<title>" + entry.Title + "</title>");
                    writer.WriteLine("<link>" + entry.Url + "</link>");
                    writer.WriteLine("<content:encoded><![CDATA[" + entry.Body + "]]></content:encoded>");
                    writer.WriteLine("<dsq:thread_identifier>" + entry.Id + "</dsq:thread_identifier>");
                    writer.WriteLine("<wp:post_date_gmt>" + entry.Published.ToString("yyyy-MM-dd HH:mm:ss") + "</wp:post_date_gmt>");
                    writer.WriteLine("<wp:comment_status>" + (entry.IsDiscussionEnabled ? "open" : "closed") +  "</wp:comment_status>");

                    foreach (var comment in entry.Comments)
                    {
                        writer.WriteLine("<wp:comment>");
                        writer.WriteLine("<wp:comment_id>" + comment.Id +"</wp:comment_id>  ");
                        writer.WriteLine("<wp:comment_author>" + comment.AuthorName + "</wp:comment_author> ");
                        writer.WriteLine("<wp:comment_author_email>" + comment.AuthorEmail + "</wp:comment_author_email>");
                        writer.WriteLine("<wp:comment_author_url>" + comment.AuthorUrl + "</wp:comment_author_url>  ");
                        writer.WriteLine("<wp:comment_author_IP>" + comment.AuthorIp + "</wp:comment_author_IP>");
                        writer.WriteLine("<wp:comment_date_gmt>" + comment.Posted.ToString("yyyy-MM-dd HH:mm:ss") + "</wp:comment_date_gmt>");
                        writer.WriteLine("<wp:comment_content><![CDATA[" + comment.Body + "]]></wp:comment_content>");
                        writer.WriteLine("<wp:comment_approved>" + comment.Status +  "</wp:comment_approved>");
                        writer.WriteLine("<wp:comment_parent>0</wp:comment_parent>");
                        writer.WriteLine("</wp:comment>");
                    }

                    writer.WriteLine("</item>");
                }

                writer.WriteLine("</channel>");
                writer.WriteLine("</rss>");
            }
        }
    }
}
