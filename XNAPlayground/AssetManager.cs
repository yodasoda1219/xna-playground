using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Content;

namespace XNAPlayground
{
    public class AssetManager
    {
        public AssetManager(XNAPlaygroundGame game, string assetDirectory = "Content")
        {
            mContentManager = game.Content;
            ExtractResources(assetDirectory);
            mContentManager.RootDirectory = assetDirectory;
        }
        private void ExtractResources(string assetDirectory)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                var names = assembly.GetManifestResourceNames();
                foreach (string name in names)
                {
                    var sections = name.Split('.');
                    string assetPath = Path.Join(".", assetDirectory);
                    for (int i = 0; i < sections.Length; i++)
                    {
                        if (i != sections.Length - 1)
                        {
                            assetPath = Path.Join(assetPath, sections[i]);
                        }
                        else
                        {
                            assetPath += "." + sections[i];
                        }
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(assetPath) ?? assetDirectory);
                    var fileStream = new FileStream(assetPath, FileMode.Create);
                    Stream? resourceStream = assembly.GetManifestResourceStream(name);
                    if (resourceStream == null)
                    {
                        throw new NullReferenceException();
                    }
                    var buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer);
                    fileStream.Write(buffer);
                    resourceStream.Close();
                    fileStream.Close();
                }
            }
        }
        public string GetAssetName(Type type)
        {
            return type.FullName?.Replace('.', '/') ?? throw new TypeAccessException();
        }
        public string GetAssetName<T>()
        {
            return GetAssetName(typeof(T));
        }
        private ContentManager mContentManager;
        public ContentManager Assets => mContentManager;
    }
}