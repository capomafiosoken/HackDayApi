using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HackDayApi
{
    public class YandexResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class CsrfTokenResponse
    {
        [JsonProperty("csrfToken")]
        public string CsrfToken { get; set; }
    }
    public class Data
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("requestSerpId")]
        public string RequestSerpId { get; set; }

        [JsonProperty("requestContext")]
        public string RequestContext { get; set; }

        [JsonProperty("requestQuery")]
        public string RequestQuery { get; set; }

        [JsonProperty("requestCorrectedQuery")]
        public string RequestCorrectedQuery { get; set; }

        [JsonProperty("requestBounds")]
        public double[][] RequestBounds { get; set; }

        [JsonProperty("displayType")]
        public string DisplayType { get; set; }

        [JsonProperty("totalResultCount")]
        public long TotalResultCount { get; set; }

        [JsonProperty("requestResults")]
        public long RequestResults { get; set; }

        [JsonProperty("requestSkip")]
        public long RequestSkip { get; set; }

        [JsonProperty("items")]
        public ExactResult[] Items { get; set; }

        [JsonProperty("exactResult")]
        public ExactResult ExactResult { get; set; }

        [JsonProperty("bounds")]
        public double[][] Bounds { get; set; }

        [JsonProperty("filters")]
        public object[] Filters { get; set; }
    }

    public class ExactResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("analyticsId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AnalyticsId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("displayCoordinates")]
        public double[] DisplayCoordinates { get; set; }

        [JsonProperty("bounds")]
        public double[][] Bounds { get; set; }

        [JsonProperty("logId")]
        public string LogId { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("metro")]
        public Metro[] Metro { get; set; }

        [JsonProperty("stops")]
        public Metro[] Stops { get; set; }

        [JsonProperty("photos")]
        public Photos Photos { get; set; }

        [JsonProperty("entrances")]
        public Entrance[] Entrances { get; set; }

        [JsonProperty("routePoint")]
        public RoutePoint RoutePoint { get; set; }

        [JsonProperty("panorama")]
        public Panorama Panorama { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("seoname")]
        public string Seoname { get; set; }

        [JsonProperty("encodedCoordinates")]
        public string EncodedCoordinates { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("geoId")]
        public long GeoId { get; set; }

        [JsonProperty("compositeAddress")]
        public CompositeAddress CompositeAddress { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("businesses")]
        public Businesses Businesses { get; set; }
    }

    public class Businesses
    {
        [JsonProperty("totalResultCount")]
        public long TotalResultCount { get; set; }

        [JsonProperty("items")]
        public BusinessesItem[] Items { get; set; }
    }

    public class BusinessesItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("analyticsId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AnalyticsId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("displayCoordinates")]
        public double[] DisplayCoordinates { get; set; }

        [JsonProperty("bounds")]
        public double[][] Bounds { get; set; }

        [JsonProperty("logId")]
        public string LogId { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metro")]
        public Metro[] Metro { get; set; }

        [JsonProperty("stops")]
        public Metro[] Stops { get; set; }

        [JsonProperty("photos", NullValueHandling = NullValueHandling.Ignore)]
        public Photos Photos { get; set; }

        [JsonProperty("entrances")]
        public Entrance[] Entrances { get; set; }

        [JsonProperty("routePoint")]
        public RoutePoint RoutePoint { get; set; }

        [JsonProperty("panorama")]
        public Panorama Panorama { get; set; }

        [JsonProperty("shortTitle")]
        public string ShortTitle { get; set; }

        [JsonProperty("fullAddress")]
        public string FullAddress { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("businessLinks")]
        public object[] BusinessLinks { get; set; }

        [JsonProperty("ratingData")]
        public RatingData RatingData { get; set; }

        [JsonProperty("sources")]
        public Source[] Sources { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("phones", NullValueHandling = NullValueHandling.Ignore)]
        public Phone[] Phones { get; set; }

        [JsonProperty("businessProperties")]
        public BusinessProperties BusinessProperties { get; set; }

        [JsonProperty("seoname")]
        public string Seoname { get; set; }

        [JsonProperty("geoId")]
        public long GeoId { get; set; }

        [JsonProperty("workingTimeText", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkingTimeText { get; set; }

        [JsonProperty("workingTime", NullValueHandling = NullValueHandling.Ignore)]
        public WorkingTime[][] WorkingTime { get; set; }

        [JsonProperty("currentWorkingStatus", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentWorkingStatus CurrentWorkingStatus { get; set; }

        [JsonProperty("tzOffset", NullValueHandling = NullValueHandling.Ignore)]
        public long? TzOffset { get; set; }

        [JsonProperty("urls", NullValueHandling = NullValueHandling.Ignore)]
        public Uri[] Urls { get; set; }

        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        public Reference[] References { get; set; }

        [JsonProperty("subtitleItems", NullValueHandling = NullValueHandling.Ignore)]
        public SubtitleItem[] SubtitleItems { get; set; }

        [JsonProperty("modularSnippet", NullValueHandling = NullValueHandling.Ignore)]
        public ModularSnippet ModularSnippet { get; set; }
    }

    public class BusinessProperties
    {
        [JsonProperty("has_verified_owner")]
        public bool HasVerifiedOwner { get; set; }

        [JsonProperty("hide_claim_organization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideClaimOrganization { get; set; }

        [JsonProperty("geoproduct_poi_color", NullValueHandling = NullValueHandling.Ignore)]
        public string GeoproductPoiColor { get; set; }
    }

    public class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("seoname")]
        public string Seoname { get; set; }

        [JsonProperty("pluralName")]
        public string PluralName { get; set; }
    }

    public class CurrentWorkingStatus
    {
        [JsonProperty("isOpenNow")]
        public bool IsOpenNow { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("shortText")]
        public string ShortText { get; set; }

        [JsonProperty("tag")]
        public object[] Tag { get; set; }
    }

    public class Entrance
    {
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("azimuth")]
        public double Azimuth { get; set; }

        [JsonProperty("tilt")]
        public long Tilt { get; set; }
    }

    public class Metro
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("distanceValue")]
        public double DistanceValue { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public Color? Color { get; set; }
    }

    public class ModularSnippet
    {
        [JsonProperty("snippet_show_title")]
        public bool SnippetShowTitle { get; set; }

        [JsonProperty("snippet_show_category")]
        public string SnippetShowCategory { get; set; }

        [JsonProperty("snippet_show_address")]
        public bool SnippetShowAddress { get; set; }

        [JsonProperty("snippet_show_photo")]
        public string SnippetShowPhoto { get; set; }

        [JsonProperty("snippet_show_work_hours")]
        public bool SnippetShowWorkHours { get; set; }

        [JsonProperty("snippet_show_rating")]
        public bool SnippetShowRating { get; set; }

        [JsonProperty("snippet_show_eta")]
        public bool SnippetShowEta { get; set; }

        [JsonProperty("snippet_show_subline")]
        public string[] SnippetShowSubline { get; set; }
    }

    public class Panorama
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("direction")]
        public double[] Direction { get; set; }

        [JsonProperty("point")]
        public Point Point { get; set; }

        [JsonProperty("preview")]
        public Uri Preview { get; set; }
    }

    public class Point
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }

    public class Phone
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Photos
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("urlTemplate")]
        public Uri UrlTemplate { get; set; }

        [JsonProperty("items")]
        public PhotosItem[] Items { get; set; }
    }

    public class PhotosItem
    {
        [JsonProperty("urlTemplate")]
        public Uri UrlTemplate { get; set; }
    }

    public class RatingData
    {
        [JsonProperty("ratingCount")]
        public long RatingCount { get; set; }

        [JsonProperty("ratingValue")]
        public double RatingValue { get; set; }

        [JsonProperty("reviewCount")]
        public long ReviewCount { get; set; }
    }

    public class Reference
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }

    public class RoutePoint
    {
        [JsonProperty("context")]
        public string Context { get; set; }
    }

    public class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public class SubtitleItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("property")]
        public Property[] Property { get; set; }
    }

    public class Property
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class WorkingTime
    {
        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public From To { get; set; }
    }

    public class From
    {
        [JsonProperty("hours")]
        public long Hours { get; set; }

        [JsonProperty("minutes")]
        public long Minutes { get; set; }
    }

    public class CompositeAddress
    {
        [JsonProperty("house")]
        public string House { get; set; }
    }

    public class Region
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("hierarchy")]
        public long[] Hierarchy { get; set; }

        [JsonProperty("seoname")]
        public string Seoname { get; set; }

        [JsonProperty("bounds")]
        public double[][] Bounds { get; set; }

        [JsonProperty("names")]
        public Names Names { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("zoom")]
        public long Zoom { get; set; }
    }

    public class Names
    {
        [JsonProperty("ablative")]
        public string Ablative { get; set; }

        [JsonProperty("accusative")]
        public string Accusative { get; set; }

        [JsonProperty("dative")]
        public string Dative { get; set; }

        [JsonProperty("directional")]
        public string Directional { get; set; }

        [JsonProperty("genitive")]
        public string Genitive { get; set; }

        [JsonProperty("instrumental")]
        public string Instrumental { get; set; }

        [JsonProperty("locative")]
        public string Locative { get; set; }

        [JsonProperty("nominative")]
        public string Nominative { get; set; }

        [JsonProperty("preposition")]
        public string Preposition { get; set; }

        [JsonProperty("prepositional")]
        public string Prepositional { get; set; }
    }

    public enum Color { Cc0000 }

    public enum TypeEnum { Common, Metro }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ColorConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Color) || t == typeof(Color?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "#cc0000")
            {
                return Color.Cc0000;
            }
            throw new Exception("Cannot unmarshal type Color");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Color)untypedValue;
            if (value == Color.Cc0000)
            {
                serializer.Serialize(writer, "#cc0000");
                return;
            }
            throw new Exception("Cannot marshal type Color");
        }

        public static readonly ColorConverter Singleton = new ColorConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "common":
                    return TypeEnum.Common;
                case "metro":
                    return TypeEnum.Metro;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Common:
                    serializer.Serialize(writer, "common");
                    return;
                case TypeEnum.Metro:
                    serializer.Serialize(writer, "metro");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
