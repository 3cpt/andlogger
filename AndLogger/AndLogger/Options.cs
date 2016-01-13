using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AndLogger
{
    public class Options
    {
        private string _optionsFileName = "LoggerOptions.xml";

        private string _partialpath;
        private string _extension;
        private string _filename;

        [XmlElement("path")]
        public string Partialpath
        {
            get
            {
                if (_partialpath != null && !_partialpath.EndsWith("/"))
                    _partialpath += "/";
                return _partialpath;
            }

            set
            {
                _partialpath = value;
            }
        }

        [XmlElement("extension")]
        public string Extension
        {
            get
            {
                return _extension ?? ".txt";
            }

            set
            {
                _extension = value;
            }
        }

        [XmlElement("filename")]
        public string Filename
        {
            get
            {
                return _filename ?? "logger";
            }

            set
            {
                _filename = value;
            }
        }

        public string Path
        {
            get
            {
                return Partialpath + Filename + Extension;
            }
        }

        public Options Load()
        {
            if (!File.Exists(_optionsFileName))
            {
                var op = new Options();
                Serialize(op);
            }

            Options _options = null;
            _options = DeSerialize();

            return _options;
        }

        private string Serialize(Options value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(Options));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    WriteForFile(stringWriter.ToString());
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        private Options DeSerialize()
        {
            try
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(_optionsFileName))
                {
                    string s = "";
                    s = sr.ReadToEnd();
                    XmlSerializer serializer = new XmlSerializer(typeof(Options));

                    Options token = null;
                    StreamReader reader = new StreamReader(_optionsFileName);
                    token = (Options)serializer.Deserialize(reader);
                    reader.Close();
                    return token;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        private void WriteForFile(string newLine)
        {
            try
            {
                if (!File.Exists(_optionsFileName))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(_optionsFileName))
                    {
                        sw.Write(newLine);
                    }
                }
                else
                {
                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    using (StreamWriter sw = File.CreateText(_optionsFileName))
                    {
                        sw.Write(newLine);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}