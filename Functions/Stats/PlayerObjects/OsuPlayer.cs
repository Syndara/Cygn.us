using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class holds the JSON structure for a call to osu's get_player API.  It's built so JSON Deserialize Object can fill every field
 * when it is given a valid JSON file.
 */
namespace Cygnus
{
    class OsuPlayer
    {
        [JsonProperty("user_id")]
        public string User_id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("count300")]
        public string Count300 { get; set; }
        [JsonProperty("count100")]
        public string Count100 { get; set; }
        [JsonProperty("count50")]
        public string Count50 { get; set; }
        [JsonProperty("playcount")]
        public string Playcount { get; set; }
        [JsonProperty("ranked_score")]
        public string Ranked_score { get; set; }
        [JsonProperty("total_score")]
        public string Total { get; set; }
        [JsonProperty("pp_rank")]
        public string PP_rank { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("pp_raw")]
        public string PP_raw { get; set; }
        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }
        [JsonProperty("count_rank_ss")]
        public string Count_rank_ss { get; set; }
        [JsonProperty("count_rank_s")]
        public string Count_rank_s { get; set; }
        [JsonProperty("count_rank_a")]
        public string Count_rank_a { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("pp_country_rank")]
        public string PP_country_rank { get; set; }
        [JsonProperty("events")]
        public List<object> Events { get; set; }
    }
}

