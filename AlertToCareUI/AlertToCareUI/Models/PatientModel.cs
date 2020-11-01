using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlertToCareUI.Models
{
    [DataContract]
    class PatientModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string IcuId { get; set; }
        [DataMember]
        public string BedId { get; set; }
        [DataMember]
        public string ContantNumber { get; set; }

    }
}
