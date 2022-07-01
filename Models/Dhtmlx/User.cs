using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebixDhtmlxDemos.Models.Dhtmlx
{
    /// <summary>
    /// Users Data for the KANBAN of dhtmlx
    /// </summary>    
    public class User
    {   
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public int Id { get; set; }
                
        [JsonProperty("label")]
        [FromForm(Name = "label")]
        public string Label { get; set; }

        [JsonProperty("avatarUrl")]
        [FromForm(Name = "avatarUrl")]
        public string AvatarUrl { get; set; }
                
        [JsonIgnore]
        public List<CardUser> CardUsers { get; set; }
    }
}