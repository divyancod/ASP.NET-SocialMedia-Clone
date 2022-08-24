using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiasedSocialMedia.Web.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueSqlAttribute : Attribute
    {
        public string DefaultValueSql { get; private set; } = "";

        public DefaultValueSqlAttribute(string defaultValueSql)
        {
            DefaultValueSql = defaultValueSql;
        }
    }
}