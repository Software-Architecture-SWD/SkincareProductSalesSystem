namespace SPSS.Service.Services.FirebaseStorageService
{
    public interface IFirebaseStorageService
    {
        Task<string> UploadImageAsync(Stream fileStream, string fileName);
    }
}
