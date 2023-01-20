
using System.IO;
using System.Linq;
using System.Reflection;

namespace Persistance
{
    internal static class ResourceManager
    {
        private static string GetString(string name, Assembly assembly)
        {
            string data = null;
            string[] resName = assembly.GetManifestResourceNames();
            
            var file_Data = resName.FirstOrDefault(mf => mf.EndsWith("." + name));
            if (file_Data != null)
            {
                using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(file_Data)))
                {
                    data = sr.ReadToEnd();
                    sr.Close();
                }
            }

            return data;
        }
        public static string GetString(string name)
        {
            var assembly_Data = Assembly.GetCallingAssembly();
           return GetString(name, assembly_Data);
            //return GetString(name, Assembly.);
        }

    }
}
