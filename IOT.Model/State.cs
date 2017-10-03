using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class State
    {
        public int Id { get; set; }
        public bool On { get; set; }
        public byte Brightness { get; set; }
        public int? Hue { get; set; }
        public int? Saturation { get; set; }
        public double[] ColorCoordinates { get; set; }
        public int? ColorTemperature { get; set; }
        public Alert Alert { get; set; }
        public Effect? Effect { get; set; }
        public string ColorMode { get; set; }
        public bool? IsReachable { get; set; }
        public TimeSpan? TransitionTime { get; set; }
    }
}
