namespace TuneSearch.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.Text.Json.Serialization;
    using ExplicitArchitecture.TuneSearchExample.Core.Ports;

    public partial class SearchApiResults
    {
        [JsonPropertyName("resultCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ResultCount { get; set; }

        [JsonPropertyName("results")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<SearchApiResult> Results { get; set; }
    }

    public partial class SearchApiResult { 
        [JsonPropertyName("wrapperType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WrapperType { get; set; }

        [JsonPropertyName("kind")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Kind { get; set; }

        [JsonPropertyName("artistId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ArtistId { get; set; }

        [JsonPropertyName("collectionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? CollectionId { get; set; }

        [JsonPropertyName("trackId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? TrackId { get; set; }

        [JsonPropertyName("artistName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ArtistName { get; set; }

        [JsonPropertyName("collectionName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CollectionName { get; set; }

        [JsonPropertyName("trackName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TrackName { get; set; }

        [JsonPropertyName("collectionCensoredName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CollectionCensoredName { get; set; }

        [JsonPropertyName("trackCensoredName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TrackCensoredName { get; set; }

        [JsonPropertyName("artistViewUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri ArtistViewUrl { get; set; }

        [JsonPropertyName("collectionViewUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri CollectionViewUrl { get; set; }

        [JsonPropertyName("trackViewUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri TrackViewUrl { get; set; }

        [JsonPropertyName("previewUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri PreviewUrl { get; set; }

        [JsonPropertyName("artworkUrl30")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri ArtworkUrl30 { get; set; }

        [JsonPropertyName("artworkUrl60")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri ArtworkUrl60 { get; set; }

        [JsonPropertyName("artworkUrl100")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri ArtworkUrl100 { get; set; }

        [JsonPropertyName("collectionPrice")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? CollectionPrice { get; set; }

        [JsonPropertyName("trackPrice")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TrackPrice { get; set; }

        [JsonPropertyName("releaseDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeOffset? ReleaseDate { get; set; }

        [JsonPropertyName("collectionExplicitness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CollectionExplicitness { get; set; }

        [JsonPropertyName("trackExplicitness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TrackExplicitness { get; set; }

        [JsonPropertyName("discCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? DiscCount { get; set; }

        [JsonPropertyName("discNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? DiscNumber { get; set; }

        [JsonPropertyName("trackCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? TrackCount { get; set; }

        [JsonPropertyName("trackNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? TrackNumber { get; set; }

        [JsonPropertyName("trackTimeMillis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? TrackTimeMillis { get; set; }

        [JsonPropertyName("country")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Country { get; set; }

        [JsonPropertyName("currency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Currency { get; set; }

        [JsonPropertyName("primaryGenreName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PrimaryGenreName { get; set; }

        [JsonPropertyName("isStreamable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsStreamable { get; set; }
    }

    /*public partial class SearchApiResults
    {
        public static SearchApiResults FromJson(string json) => JsonConvert.DeserializeObject<SearchApiResults>(json, TuneSearch.Infrastructure.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchApiResults self) => JsonConvert.SerializeObject(self, TuneSearch.Infrastructure.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }*/
}
