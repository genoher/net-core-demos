using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebixDhtmlxDemos.Converters;

namespace WebixDhtmlxDemos.Models.Dhtmlx
{
    /// <summary>
    /// Cards Data for the KANBAN of dhtmlx
    /// An array of objects containing the cards data
    /// https://docs.dhtmlx.com/kanban/api/config/js_kanban_cards_config/
    /// </summary>
    /// <![CDATA[
    /// const cards = [
    ///    {
    ///        id: 1,
    ///        label: "Integration with React",
    ///        description: "Some description",
    ///        progress: 25,
    ///        start_date: new Date("01/05/2021"),
    ///        end_date: new Date("01/15/2021"),
    ///        color: "#65D3B3",
    ///        users: [1, 2],
    ///        priority: 1,
    ///        attached: [
    ///            {
    ///                id: 234,
    ///                    url: "../assets/img-1.jpg",
    ///                    previewURL: "../assets/img-1.jpg",
    ///                    coverURL: "../assets/img-1.jpg",
    ///                    name: "img-1.jpg",
    ///                    isCover: true
    ///            },
    ///            { ...} // other attached files data
    ///        ],    
    ///        // custom field to place the card into the "feature" row 
    ///        // the rowKey config needs to be set to the "type" value
    ///        type: "feature",
    ///        // custom field to place the card into the "backlog" column 
    ///        // the columnKey config needs to be set to the "stage" value
    ///        stage: "backlog"
    ///    },
    ///    { ...} // other cards data
    /// ];
    ///
    /// new kanban.Kanban("#root", {
    ///    columns,
    ///    cards,
    ///    // other parameters
    /// });
    /// ]]>
    public class Card
    {
        // id?: string | number, sample: 1
        // (optional) a card ID.
        // It is used for managing the card via the corresponding methods
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public int Id { get; set; }

        // label?: string, sample: "Integration with React"
        // (optional) a card label.
        // It is displayed in the Label field
        [JsonProperty("label")]
        [FromForm(Name = "label")]
        public string Label { get; set; }

        // description?: string, sample: "Some description"
        // (optional) a card description.
        // It is displayed in the Description field
        [JsonProperty("description")]
        [FromForm(Name = "description")]
        public string Description { get; set; }

        // progress?: number, sample: 25
        // (optional) a progress bar value.
        // You can specify the value in the range from 0 to 100 points.
        // It is displayed in the Progress bar field
        [JsonProperty("progress")]
        [FromForm(Name = "progress")]
        [Range(0, 100)]
        public int? Progress { get; set; }

        // start_date?: Date, sample: new Date("01/05/2021")
        // (optional) a start date value.
        // It is displayed in the Start date field
        [JsonProperty("start_date")]
        [FromForm(Name = "start_date")]
        [JsonConverter(typeof(DhtmlxDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        // end_date?: Date, sample: new Date("01/15/2021")
        // (optional) an end date value.
        // It is displayed in the End date field
        [JsonProperty("end_date")]
        [FromForm(Name = "end_date")]
        [JsonConverter(typeof(DhtmlxDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        // color?: string, sample: #65D3B3
        // (optional) a valid HEX color code.
        // It is the color of the card top line
        [JsonProperty("color")]
        [FromForm(Name = "color")]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Invalid Format")]
        public string Color { get; set; }

        // users?: array,
        // (optional) an array with the assigned users IDs.
        // To specify the assigned users, you need to define
        // an array with users data in the cardShape property
        // (see the users parameter). The users are displayed
        // in the Users field
        [JsonProperty("users")]
        [FromForm(Name = "users")]
        public List<CardUser> CardUsers { get; set; }

        // priority?: string | number,
        // (optional) a card priority ID.
        // To specify the card priority, you need to define an
        // array with priorities data in the cardShape property
        // (see the priority parameter).
        // It is displayed in the Priority field
        [JsonProperty("priority")]
        [FromForm(Name = "priority")]
        public int? Priority { get; set; }

        //[custom_key: string]?: any

        /* Any other custom fields */

        // sample: "feature"
        // custom field to place the card into the "feature" row 
        // the rowKey config needs to be set to the "type" value        
        [JsonProperty("type")]
        [FromForm(Name = "type")]
        public string RowKey { get; set; } // or CardType

        // sample: "backlog"
        // custom field to place the card into the "backlog" column 
        // the columnKey config needs to be set to the "stage" value

        [JsonProperty("stage")]
        [FromForm(Name = "stage")]
        public string RowColumn { get; set; } // or CardState

        // Order of the cards in the column
        public int? Order { get; set; }

        //attached?: [
        //    id: string | number,
        //    url?: string,
        //    previewURL?: string,
        //    coverURL?: string,
        //    name?: string,
        //    isCover?: boolean
        //],
        [JsonProperty("attached")]
        [FromForm(Name = "attached")]
        public List<CardAttachment> Attachments { get; set; }
    }

    public class CardUser
    {
        // id - (required) an ID of the attached file
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public int Id { get; set; }

        // Foreing Key Property
        public int? CardId { get; set; }
        // Reference Property
        public Card Card { get; set; }

        // Foreing Key Property
        public int? UserId { get; set; }
        // Reference Property
        public User User { get; set; }
    }

    public class CardAttachment
    {
        // id - (required) an ID of the attached file
        [JsonProperty("id")]
        [FromForm(Name = "id")]
        public int Id { get; set; }

        // name - (optional) a file name
        [JsonProperty("name")]
        [FromForm(Name = "name")]
        public string Name { get; set; }

        // url - (optional) a path to the file to be attached
        [JsonProperty("url")]
        [FromForm(Name = "url")]
        public string Url { get; set; }

        // previewURL - (optional) a path to the preview image
        [JsonProperty("previewURL")]
        [FromForm(Name = "previewURL")]
        public string PreviewUrl { get; set; }

        // coverURL - (optional) a path to the image to be set as a cover
        [JsonProperty("coverURL")]
        [FromForm(Name = "coverURL")]
        public string CoverUrl { get; set; }        

        // isCover - (optional) enables a cover image.
        // If true, the cover image will be downloaded via the "coverURL" url
        [JsonProperty("isCover")]
        [FromForm(Name = "isCover")]
        public bool IsCover { get; set; }

        // Order of the attachment in the card
        public int? Order { get; set; }

        // Foreing Key Property
        public int? CardId { get; set; }
        // Reference Property
        public Card Card { get; set; }
    }
}