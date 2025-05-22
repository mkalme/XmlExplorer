using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Xml;
using System.Diagnostics;

namespace XmlExplorer
{
    class Methods
    {
        public static void WaitTillFileIsReady(string filename) {
            while (!Methods.IsFileReady(filename)) {
                Thread.Sleep(30);
            }
        }
        public static bool IsFileReady(string filename) {
            try{
                using (Stream stream = new FileStream(filename, FileMode.Open)){
                    return true;
                }
            }catch{
                return false;
            }
        }

        public static string GetDateTimeShow(string fileTime)
        {

            return DateTime.FromFileTime(Int64.Parse(fileTime)).ToString(Settings.DateTime_Format);
        }
        public static string GetShowSize(string sizeInBytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = (double)Int32.Parse(sizeInBytes);
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }
        public static string GetShowExtension(string extension)
        {
            string text = "";

            text = extension.ToUpper();

            if (string.IsNullOrEmpty(text)){
                text = "File";
            }
            else{
                if (Settings.CommonExtensions.ContainsKey(text)){
                    text = Settings.CommonExtensions[text] + " File";
                }
                else{
                    text += " File";
                }
            }

            return text;
        }
        public static bool DirectoryContainsFiles(string path) {
            string[] files = Explorer.xmlCommands.GetAllFiles(path);

            if (files.Length > 0){
                return true;
            }else {
                return false;
            }
        }

        public static bool IfValueMatchesInArray(string[] array, string value){
            bool ifSame = false;

            for (int i = 0; i < array.Length; i++){
                if (array[i].Equals(value)){
                    ifSame = true;

                    goto after_loop;
                }
            }
            after_loop:

            return ifSame;
        }
        public static string GetDirectoryName(string parentPath, string name, int type){
            string newName = name;

            string[] directories = Explorer.xmlCommands.GetAllDirectories(parentPath);

            for (int i = 0; i < directories.Length; i++){
                directories[i] = Path.GetFileName(directories[i]);
            }

            string valueCompare = "";

            bool cont = true;
            int loops = 1;
            while (cont){
                valueCompare += (type == 0 ?
                                        (loops == 1 ? "" : "(" + loops.ToString() + ")") :
                                        (loops == 1 ? "" : " - copy")
                                      );

                cont = IfValueMatchesInArray(directories, name + valueCompare);
                if (!cont){
                    newName += valueCompare;
                }
                loops++;
            }

            return newName;
        }
        public static string GetFileName(string parentPath, string name, int type){
            string newName = Path.GetFileNameWithoutExtension(name);

            string[] files = Explorer.xmlCommands.GetAllFiles(parentPath);

            for (int i = 0; i < files.Length; i++){
                files[i] = Path.GetFileName(files[i]);
            }

            string valueCompare = "";

            bool cont = true;
            int loops = 1;
            while (cont){
                valueCompare += (type == 0 ?
                                        (loops == 1 ? "" : "(" + loops.ToString() + ")") :
                                        (loops == 1 ? "" : " - copy")
                                      );

                cont = IfValueMatchesInArray(files, Path.GetFileNameWithoutExtension(name) + valueCompare + "." + GetExtension(name).ToLower());
                if (!cont){
                    newName += valueCompare + "." + GetExtension(name).ToLower();
                }
                loops++;
            }

            return newName;
        }

        public static string GetExtension(string name)
        {
            string extension = "";
            string[] array = name.Split('.');

            if (array.Length > 1)
            {
                extension = array[1].ToUpper();
            }

            return extension;
        }
        public static string GetPathTextBox()
        {
            return " " + Explorer.path.Replace("\\", " > ");
        }
        public static string GetProgramAttributes(string extension, int type) {
            string value = "";

            if (Settings.AllPrograms.ContainsKey(extension.ToUpper())) {
                if (Settings.AllPrograms[extension.ToUpper()].Count > 0) {
                    value = Settings.AllPrograms[extension.ToUpper()][0][type];
                }
            }

            return value;
        }
        public static string GetExtensionIconPath(string extension) {
            string path = Explorer.ExplorerPath + "/Storage/Icons/" + extension + ".png";

            if (!File.Exists(path)) {
                path = "";
            }
            return path;
        }

        public static void SetCommonFileExtensions()
        {
            XmlDocument extensionDocument = new XmlDocument();
            extensionDocument.LoadXml(Properties.Resources.CommonExtensions);

            XmlNodeList allExtensionNodes = extensionDocument.SelectNodes("/root/file");
            for (int i = 0; i < allExtensionNodes.Count; i++)
            {
                Settings.CommonExtensions.Add(
                    allExtensionNodes[i].Attributes["extension"].Value,
                    allExtensionNodes[i].Attributes["description"].Value
                );
            }
        }
        public static void SetPrograms()
        {
            XmlDocument programDocument = new XmlDocument();
            programDocument.Load(Explorer.ExplorerPath + "/Storage/Programs/programList.xml");

            XmlNodeList allNodes = programDocument.SelectNodes("/root/program");

            for (int i = 0; i < allNodes.Count; i++)
            {
                XmlNodeList allExtensions = programDocument.SelectNodes("/root/program[@path='" + allNodes[i].Attributes["path"].Value + "']/extension");

                for (int b = 0; b < allExtensions.Count; b++)
                {
                    string extensionInner = allExtensions[b].InnerText.ToUpper();

                    if (Settings.AllPrograms.ContainsKey(extensionInner)){
                        Settings.AllPrograms[extensionInner].Add(new string[] { allNodes[i].Attributes["path"].Value, allNodes[i].Attributes["name"].Value });
                    }
                    else {
                        Settings.AllPrograms.Add(extensionInner, new List<string[]> { new string[] { allNodes[i].Attributes["path"].Value, allNodes[i].Attributes["name"].Value } });
                    }
                }

                Settings.ListOfPrograms.Add(new string[] { allNodes[i].Attributes["path"].Value, allNodes[i].Attributes["name"].Value });
            }
        }
    }
}
