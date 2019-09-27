using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackManager.Common.DtoModel.Model.RouterDto
{
    public class RouterDto
    {
        [JsonProperty("data")]
        public RouterInfo Data { get; set; }
    }

    public class RouterInfo
    {
        [JsonProperty("router")]
        public List<MenuInfo> Router { get; set; }
    }

    public class MenuInfo
    {

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("component")]
        public string Component { get; set; }

        [JsonProperty("redirect")]
        public string Redirect { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("hidden")]
        //public bool Hidden { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("children")]
        public List<MenuInfo> Children { get; set; }
    }

    public class Meta
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("menuId")]
        public long MenuID { get; set; }
    }
}
