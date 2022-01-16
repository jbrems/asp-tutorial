using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace asp_tutorial.Models {
    public class Product {
        public string Id { get; set; }

        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string URL { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public void AddRating(int rating) {
            if (Ratings == null) Ratings = new int[] { };

            List<int> ratingList = Ratings.ToList();
            ratingList.Add(rating);
            Ratings = ratingList.ToArray();
        }

        public override string ToString() {
            return JsonSerializer.Serialize<Product>(this);
        }
    }
}
