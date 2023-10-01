using System.Reflection;

namespace HackYeah.Application.Services
{
    public class ImageService
    {
        private const string DirName = "Images";

        public void Save(Stream stream, string fileName) 
        {
            var filePath = Path.Combine(GetAbsoluteDirPath(), fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }

        public Stream Load(string fileName) 
        {
            var filePath = Path.Combine(GetAbsoluteDirPath(), fileName);

            return File.OpenRead(filePath);
        }

        private static string GetAbsoluteDirPath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), DirName);
        }
    }
}
