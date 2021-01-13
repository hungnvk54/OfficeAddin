using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class RepresentativeEntity
    {
        public RepresentativeEntity()
        {
            idRepresentative = 0;
            name = "";
            duty = "";
            legislature = "";
            fullTitle = "";
        }
        public long idRepresentative
        {
            get;set;
        }

        public string name
        {
            get;set;
        }

        public string duty
        {
            get;set;
        }

        public string legislature
        {
            get;set;
        }

        public string fullTitle
        {
            get;set;
        }
    }
    
}
