using Domain.Integrations;

namespace Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string Path = "/Users/campos/www/chicktosa-api/Images";
        public string Save(string base64)
        {
            throw new NotImplementedException();
        }
    }
}