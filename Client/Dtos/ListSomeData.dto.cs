using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ListSomeData : BaseResponse
    {
        public ListSomeData() : base()
        {
            m_Data = new List<SomeData>();
        }

        public List<SomeData> Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }
        public override string ToString()
        {
            string data = "";
            m_Data.ForEach(delegate (SomeData d) { data += $"{d.ToString()}\n" ; });
            return $"{base.ToString()}\n{data}";
        }

        private List<SomeData> m_Data;
    }
}
