using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Domain
{
    public class Team : ICreatableFromJson<Team>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public Team FromJson(JSONObject json)
        {
            Id = json.getGuid("id");
            Name = json.getStringValue("name");
            return this;
        }
    }
}