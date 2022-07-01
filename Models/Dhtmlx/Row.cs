using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebixDhtmlxDemos.Models.Dhtmlx
{
    /// <summary>
    /// Rows Data for the KANBAN of dhtmlx
    /// An array of objects containing the rows (swimlanes) data
    /// https://docs.dhtmlx.com/kanban/api/config/js_kanban_rows_config/
    /// </summary>
    /// <![CDATA[
    /// const rows = [
    ///     { label: "Feature", id: "feature", collapsed: false },
    ///     { label: "Task", id: "task", collapsed: true }
    /// ];
    /// 
    /// new kanban.Kanban("#root", {
    ///     columns,
    ///     cards,
    ///     rows, // swimlanes data
    ///     // other parameters
    /// });
    /// ]]>
    public class Row
    {
        // id - (required) a row (swimlane) ID.
        // It is used for managing the row via the corresponding methods        
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public string Id { get; set; }

        // label - (optional) a row (swimlane) label.
        // It is displayed in the row section
        [JsonProperty("label")]
        [FromForm(Name = "label")]
        public string Label { get; set; }

        // collapsed - (optional) a current state of the row (swimlane).
        // If true, the row is collapsed initially.
        // Default value is false (expanded state)
        [JsonProperty("collapsed")]
        [FromForm(Name = "collapsed")]
        public bool? IsCollapsed { get; set; }

        // Order of the rows
        public int? Order { get; set; }
    }
}