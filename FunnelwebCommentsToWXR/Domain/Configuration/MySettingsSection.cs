using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace Domain.Configuration
{

    public class MySettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("rootUrl")]
        public RootUrlElement RootUrl
        {
            get
            {
                return (RootUrlElement)this["rootUrl"];
            }
            set
            {
                this["rootUrl"] = value;
            }
        }

        [ConfigurationProperty("funnelwebConnectionString")]
        public FunnelwebConnectionStringElement FunnelwebConnectionString
        {
            get
            {
                return (FunnelwebConnectionStringElement)this["funnelwebConnectionString"];
            }
            set
            {
                this["funnelwebConnectionString"] = value;
            }
        }

        public class FunnelwebConnectionStringElement : ConfigurationElement
        {
            [ConfigurationProperty("value", IsRequired = true)]
            public string Value
            {
                get
                {
                    return (string)this["value"];
                }
                set
                {
                    this["value"] = value;
                }
            }
        }

        public class RootUrlElement : ConfigurationElement
        {
            [ConfigurationProperty("value", IsRequired = true)]
            public string Value
            {
                get
                {
                    return (string)this["value"];
                }
                set
                {
                    this["value"] = value;
                }
            }
        }
    }
}
