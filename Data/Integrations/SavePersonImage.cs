using Domain.Integrations;

namespace Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _path;

        public SavePersonImage()
        {
            _path = "/Users/campos/www/chicktosa-api/Images";
        }

        public string Save(string imgBase64)
        {
            var fileExt = imgBase64.Substring(imgBase64.IndexOf("/") + 1,
                imgBase64.IndexOf("/") - imgBase64.IndexOf("/") - 1); // remove png ou jpeg

            var base64Code = imgBase64.Substring(imgBase64.IndexOf(",") + 1);
            var imgBytes = Convert.FromBase64String(base64Code);

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;

            using (var imgFile = new FileStream(_path + "/" + fileName, FileMode.Create))
            {
                imgFile.Write(imgBytes, 0, imgBytes.Length);
                imgFile.Flush();
            }

            return _path + "/" + fileName;
        }
    }
}