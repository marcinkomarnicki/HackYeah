using HackYeah.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Python.Runtime;
using System.Reflection;
using static Python.Runtime.Py;

namespace HackYeah.Application.Services
{
    public class ImageService : IDisposable
    {
        private GILState? _gilState;
        private readonly PyObject _script;

        public ImageService(IOptions<PythonSection> options)
        {
            Runtime.PythonDLL = options.Value.DllPath;

            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();

            var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var modelPath = Path.Combine(dir, "FinalModel.h5");

            _gilState = Py.GIL();

            _script = Py.Import("predict");
            _script.InvokeMethod("loadModel", new PyObject[] { new PyString(modelPath) }); ;
        }

        public int Predict(Stream stream, string fileExtension)
        {
            var tempDir = Directory.CreateTempSubdirectory();
            var tempSubdirImages = Directory.CreateDirectory(Path.Combine(tempDir.FullName, "images"));
            var filePath = Path.Combine(tempSubdirImages.FullName, $"image{fileExtension}");

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            var result = int.Parse(_script.InvokeMethod("predict", new PyObject[] { new PyString(tempDir.FullName) }).ToString());

            Directory.Delete(tempDir.FullName, true);

            return result;
        }

        public void Dispose()
        {
            _gilState?.Dispose();
            _gilState = null;
        }
    }
}
