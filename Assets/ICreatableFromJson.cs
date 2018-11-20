namespace Assets
{
    public interface ICreatableFromJson<out T> where T : new()
    {
        T FromJson(JSONObject json);
    }
}