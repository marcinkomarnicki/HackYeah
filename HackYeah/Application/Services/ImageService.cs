using HackYeah.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Python.Runtime;
using System.Reflection;

namespace HackYeah.Application.Services
{
    public class ImageService
    {
        private readonly PyObject _script;

        public ImageService(IOptions<PythonSection> options)
        {
            Runtime.PythonDLL = options.Value.DllPath;

            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();

            var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var modelPath = Path.Combine(dir, "FinalModel.h5");

            var predictPath = Path.Combine(dir, "predict");

            using (Py.GIL())
            {
                dynamic os = Py.Import("os");
                dynamic sys = Py.Import("sys");
                sys.path.append(os.path.dirname(os.path.expanduser($"{predictPath}.py")));

                _script = Py.Import("predict");
                _script.InvokeMethod("loadModel", new PyObject[] { new PyString(modelPath) });
            }
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

            using (Py.GIL())
            {
                var result = int.Parse(_script.InvokeMethod("predict", new PyObject[] { new PyString(tempDir.FullName) }).ToString());

                Directory.Delete(tempDir.FullName, true);

                return result;
            }
        }
    }
}
