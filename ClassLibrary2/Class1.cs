using System;

namespace ClassLibrary2
{
    public class Class1
    {
        public class Book
        {
            public String title;
            public List<string> gg { get; set; }
        }
        static public string Save(List<string> vs)
        {
            try
            {

                Book overview = new Book();
                overview.title = "Serialization Overview";
                overview.gg = vs;
                System.Xml.Serialization.XmlSerializer writer =
              new System.Xml.Serialization.XmlSerializer(typeof(Book));
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "//SerializationOverview.xml";
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, overview);
                file.Close();
                return "Ок";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
