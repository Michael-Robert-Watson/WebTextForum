﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;

namespace WebTextForum.ViewModel
{
    public class BlogItemViewModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
        [JsonPropertyName("blogItemParent")]
        public virtual BlogItemViewModel BlogItemParent { get; set; }
        [JsonPropertyName("likes")]
        public int Likes { get; set; }
        [JsonPropertyName("tags")]
        public List<NameValue> Tags { get; set; }
        [JsonPropertyName("likedByUser")]
        public bool LikedByUser { get; set; }
        [JsonPropertyName("isYourComment")]
        public bool IsYourComment { get; set; }
        [JsonPropertyName("allTags")]
        public List<NameValue> AllTags { get; set; }
        [JsonPropertyName("replies")]
        public List<BlogItemViewModel> Replies { get; set; }
    }
}
