namespace datasheetapi.Services;

public interface ITagDataService
{
    Task<ITagData> GetTagDataByTagNo(string tagNo);
    Task<List<ITagData>> GetAllTagData();
}
