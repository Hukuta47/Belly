using Belly.Enums;

namespace Belly.Objects
{
    public class MediaData
    {
        public TypeData typeData { get; set; }
        public MediaData(TypeData type) 
        {
            typeData = type;
        }
    }
}
