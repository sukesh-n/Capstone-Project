using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace HotelBookingApp.Services.BlobService
{
    public class HotelImageBlobService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public HotelImageBlobService(IConfiguration configuration)
        {
            _connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _containerName = configuration["AzureBlobStorage:ContainerName"];
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            // Ensure the container exists
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            try
            {
                await blobClient.UploadAsync(imageStream, true);
                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Error uploading image to Blob Storage", ex);
            }
        }
    }
}
