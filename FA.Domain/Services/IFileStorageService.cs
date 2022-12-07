using System.IO;

namespace FA.Domain.FileStorage
{
    public interface IFileStorageService
    {
        void SaveFile(Stream fileStream, string destinationFilePath);

        void RemoveFile(string filePath);

        string GetSafeFileName(string fileName);

        string GetFullFilePath(string relativeFilePath);

    }
}
