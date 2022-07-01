using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebixDhtmlxDemos.Models.Dhtmlx
{
    /// <summary>
    /// Columns Data for the KANBAN of dhtmlx
    /// An array of objects containing the columns data
    /// https://docs.dhtmlx.com/kanban/api/config/js_kanban_columns_config/
    /// </summary>
    /// <![CDATA[
    /// const columns = [
    ///     { 
    ///         label: "Backlog", 
    ///         id: "backlog",
    ///         collapsed: true,
    ///         limit: 3,
    ///         strictLimit: true 
    ///     },
    ///     { 
    ///         label: "In progress", 
    ///         id: "inprogress",
    ///         collapsed: false,
    ///         limit: {
    ///             // limit the number of cards for the "Feature" and "Task" rows of the "In progress" column
    ///             feature: 3, 
    ///             task: 2
    ///         },
    ///         strictLimit: false
    ///     },
    ///     { label: "Done", id: "done" }
    /// ];
    /// 
    /// new kanban.Kanban("#root", {
    ///     columns,
    ///     cards,
    ///     rows,
    ///     // other parameters
    /// });
    /// ]]>
    public class Column
    {
        // id - (required) a column ID.
        // It is used for managing the column via the corresponding methods
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public string Id { get; set; }

        // label - (optional) a column label.
        // It is displayed in the column section
        [JsonProperty("label")]
        [FromForm(Name = "label")]
        public string Label { get; set; }

        // collapsed - (optional) a current state of the column.
        // If true, the column is collapsed initially.
        // Default value is false (expanded state)
        [JsonProperty("collapsed")]
        [FromForm(Name = "collapsed")]
        public bool? IsCollapsed { get; set; }

        // limit - (optional) this parameter may take one of the two types of values:
        //  number - a limit of cards in the current column
        //  object - an object with the limits of cards for each row(swimlane) by its ID
        [JsonProperty("limit")]
        [FromForm(Name = "limit")]
        public int? Limit { get; set; }

        // strictLimit - (optional) a strict limit mode.
        // If true, a user will not be able to create new cards over the specified number via the limit parameter.
        // Default value is false
        [JsonProperty("strictLimit")]
        [FromForm(Name = "strictLimit")]
        public int? IsStrictLimit { get; set; }

        // Order of the columns
        public int? Order { get; set; }
    }
}