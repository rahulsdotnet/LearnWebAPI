using System.Collections.Generic;

namespace LearnWebAPI.OptionModels
{
    public class AppsettingGroupOptions
    {
        public List<Region> Regions { get; set; }
    }

    public class Region
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
}
