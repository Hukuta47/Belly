using Belly.Enums;

namespace Belly.Objects
{
    public class MediaData
    {
        public TypeData typeData { get; set; }
        public string Name { get; set; }
        public MediaData(TypeData type) 
        {
            typeData = type;
        }
    }
}
