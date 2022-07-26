namespace MovieECommerce.Contract
{
    public interface IImageService
    {
        Task<string> UploadImage(string imagePath);
    }
}
