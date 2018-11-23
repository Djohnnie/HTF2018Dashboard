namespace Assets.Domain
{
    public class OverviewStatus : ICreatableFromJson<OverviewStatus>
    {
        public Status Challenge01Status { get; set; }
        public Status Challenge02Status { get; set; }
        public Status Challenge03Status { get; set; }
        public Status Challenge04Status { get; set; }
        public Status Challenge05Status { get; set; }
        public Status Challenge06Status { get; set; }
        public Status Challenge07Status { get; set; }
        public Status Challenge08Status { get; set; }
        public Status Challenge09Status { get; set; }
        public Status Challenge10Status { get; set; }
        public Status Challenge11Status { get; set; }
        public Status Challenge12Status { get; set; }
        public Status Challenge13Status { get; set; }
        public Status Challenge14Status { get; set; }
        public Status Challenge15Status { get; set; }
        public Status Challenge16Status { get; set; }
        public Status Challenge17Status { get; set; }
        public Status Challenge18Status { get; set; }
        public Status Challenge19Status { get; set; }
        public Status Challenge20Status { get; set; }

        public OverviewStatus FromJson(JSONObject json)
        {
            Challenge01Status = json.getEnumValue<Status>("challenge01Status");
            Challenge02Status = json.getEnumValue<Status>("challenge02Status");
            Challenge03Status = json.getEnumValue<Status>("challenge03Status");
            Challenge04Status = json.getEnumValue<Status>("challenge04Status");
            Challenge05Status = json.getEnumValue<Status>("challenge05Status");
            Challenge06Status = json.getEnumValue<Status>("challenge06Status");
            Challenge07Status = json.getEnumValue<Status>("challenge07Status");
            Challenge08Status = json.getEnumValue<Status>("challenge08Status");
            Challenge09Status = json.getEnumValue<Status>("challenge09Status");
            Challenge10Status = json.getEnumValue<Status>("challenge10Status");
            Challenge11Status = json.getEnumValue<Status>("challenge11Status");
            Challenge12Status = json.getEnumValue<Status>("challenge12Status");
            Challenge13Status = json.getEnumValue<Status>("challenge13Status");
            Challenge14Status = json.getEnumValue<Status>("challenge14Status");
            Challenge15Status = json.getEnumValue<Status>("challenge15Status");
            Challenge16Status = json.getEnumValue<Status>("challenge16Status");
            Challenge17Status = json.getEnumValue<Status>("challenge17Status");
            Challenge18Status = json.getEnumValue<Status>("challenge18Status");
            Challenge19Status = json.getEnumValue<Status>("challenge19Status");
            Challenge20Status = json.getEnumValue<Status>("challenge20Status");
            return this;
        }
    }
}