using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class Light
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ModelId { get; set; }
        public string ProductId { get; set; }
        public string SwConfigId { get; set; }
        public string UniqueId { get; set; }
        public string LuminaireUniqueId { get; set; }
        public string ManufacturerName { get; set; }
        public string SoftwareVersion { get; set; }
    }
}
